﻿using TaskManagement.Application;
using TaskManagement.Persistence;
using Microsoft.OpenApi.Models;
using TaskManagement.API.Middleware;
using TaskManagement.Persistence.Scheduler;
using TaskManagement.Identity;
using TaskManagement.Infrastructure;
using TaskManagement.Application.Team.Queries.TeamHelper;
using TaskManagement.Application.Contracts.Services;
using TaskManagement.Application.Translation;
using TaskManagement.Common.OperationFilter;

namespace TaskManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            AddSwaggerDoc(services);

            services.ConfigureApplicationServices();

            services.ConfigureIdentityServices(Configuration);
            services.ConfigureApplicationServices();
            services.ConfigurePersistenceServices(Configuration);
            services.ConfigureInfrastructureServices(Configuration);
            services.AddControllers();

            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // Add API versioning configuration
            services.AddApiVersioning(setupAction =>
            {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;
            });

            services.AddScoped<ITeamAuthorizationService, TeamAuthorizationService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHostedService<TaskDeadlineCheckerService>();
            services.AddHostedService<BlockedTeamMembersChecker>();
            services.AddScoped<LanguageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseMiddleware<TimingMiddleware>();

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManagement.Api v1"));


            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                // Default
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void AddSwaggerDoc(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                    Enter 'Bearer' [space] and then your token in the text input below.
                    Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.DocumentFilter<AcceptLanguageOperationFilter>();

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                        {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                    }
                });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Task Management API",

                });
            });
        }      
    }
}

