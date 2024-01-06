﻿using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Contracts.Identity;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userService.GetAllUsers();
            return Ok(user);
        }

        [HttpGet("get-administrators")]
        public async Task<IActionResult> GetAdministrators()
        {
            var user = await _userService.GetAdministrators();
            return Ok(user);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if(id == 0) 
            {
                throw new ArgumentException("Id is required");
            }

            var userToDelete = await _userService.DeleteUser(id);

            if (userToDelete)
            {
                return Ok("User deleted successfully.");
            }

            return BadRequest();
        }
    }
}
