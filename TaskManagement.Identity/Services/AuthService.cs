using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.Application.Constants;
using TaskManagement.Application.Contracts.Identity;
using TaskManagement.Application.Contracts.Infrastructure;
using TaskManagement.Application.Models.Identity;
using TaskManagement.Application.Models.Mail;
using TaskManagement.Domain.Entities;
using TaskManagement.Identity.Models;
using TaskManagement.Persistence.Context;

namespace TaskManagement.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly TaskManagementIdentityDbContext _identityDbContext;
        private readonly TaskManagementDbContext _taskManagementDbContext;
        public IEmailSender _emailSender;

        public AuthService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager,
            TaskManagementIdentityDbContext identityDbContext,
            TaskManagementDbContext taskManagementDbContext,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _identityDbContext = identityDbContext;
            _taskManagementDbContext = taskManagementDbContext;
            _emailSender = emailSender;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                throw new Exception($"Username '{request.UserName}' already exists.");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");

                    var domainUser = new DomainUserEntity
                    {
                        UserId = user.Id,
                        CreatedAt = DateTime.Now,
                    };

                    await _taskManagementDbContext.Users.AddAsync(domainUser);
                    _taskManagementDbContext.SaveChanges();

                    //await _emailSender.SendTemplatedEmailAsync(new TemplatedEmailModel
                    //{
                    //    IsBodyHtml = true,
                    //    Subject = "Account registered",
                    //    Body = $"Thank you {request.FirstName} {request.LastName} your Account registered successfully",
                    //    Receiver = request.Email,
                    //});

                    return new RegistrationResponse() { UserId = user.Id };
                }
                else
                {
                    var errorMessages = string.Join(", ", result.Errors.Select(error => error.Description));
                    throw new Exception($"User creation failed: {errorMessages}");
                }
            }
            else
            {
                throw new Exception($"Email {request.Email} already exists.");
            }
        }


        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            if(user.UserName == null)
            {
                throw new Exception($"User with {user.UserName} not found.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthResponse response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName,
                IsSucceed = true
            };

            return response;
        }

        public async Task<BaseAuthResponse> MakeAdminAsync(UpdatePermissionRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user is null)
                return new BaseAuthResponse() { IsSucceed = false, Message = "Invalid User name !!!" };

            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);

            await _userManager.AddToRoleAsync(user, "Administrator");

            return new BaseAuthResponse() { IsSucceed = true, Message = "Now user is an Admin" };
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim(CustomClaimTypes.Uid, user.Id.ToString(), ClaimValueTypes.Integer)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}