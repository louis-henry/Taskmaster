using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Taskmaster.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taskmaster.Models;
using Microsoft.AspNetCore.Http;

namespace Taskmaster
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<TaskmasterContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<TaskmasterContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                options.LoginPath = new PathString("/Secure/Login");
                options.AccessDeniedPath = new PathString("/Secure/Logout");
                options.AccessDeniedPath = new PathString("/Secure/AccessDenied");

                options.SlidingExpiration = true;
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seeding roles into database.
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
            if (!roleManager.RoleExistsAsync("Permanent").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Permanent";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            // Seeding permanent administrators to database.
            if (userManager.FindByEmailAsync("administrator@taskmaster.com.au").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = user.Email = "administrator@taskmaster.com.au";
                user.EmailConfirmed = true;
                user.User = new User() { Name = "Administrator", Email = user.UserName, PublicProfile = false };
                IdentityResult result = userManager.CreateAsync(user, "Password1!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Permanent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("s3742247@student.rmit.edu.au").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = user.Email = "s3742247@student.rmit.edu.au";
                user.EmailConfirmed = true;
                user.User = new User() { Name = "Phillip Bawden", Email = user.UserName, PublicProfile = false };
                IdentityResult result = userManager.CreateAsync(user, "Password1!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Permanent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("s3694199@student.rmit.edu.au").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = user.Email = "s3694199@student.rmit.edu.au";
                user.EmailConfirmed = true;
                user.User = new User() { Name = "Henry Han", Email = user.UserName, PublicProfile = false };
                IdentityResult result = userManager.CreateAsync(user, "Password1!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Permanent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("s3294034@student.rmit.edu.au").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = user.Email = "s3294034@student.rmit.edu.au";
                user.EmailConfirmed = true;
                user.User = new User() { Name = "Peter McAlister", Email = user.UserName, PublicProfile = false };
                IdentityResult result = userManager.CreateAsync(user, "Password1!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Permanent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("s3422731@student.rmit.edu.au").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = user.Email = "s3422731@student.rmit.edu.au";
                user.EmailConfirmed = true;
                user.User = new User() { Name = "Louis Henry", Email = user.UserName, PublicProfile = false };
                IdentityResult result = userManager.CreateAsync(user, "Password1!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Permanent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("s3694308@student.rmit.edu.au").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = user.Email = "s3694308@student.rmit.edu.au";
                user.EmailConfirmed = true;
                user.User = new User() { Name = "Mehdi Ebrahimi", Email = user.UserName, PublicProfile = false };
                IdentityResult result = userManager.CreateAsync(user, "Password1!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Permanent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("s3731977@student.rmit.edu.au").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = user.Email = "s3731977@student.rmit.edu.au";
                user.EmailConfirmed = true;
                user.User = new User() { Name = "Jenny Caruso", Email = user.UserName, PublicProfile = false };
                IdentityResult result = userManager.CreateAsync(user, "Password1!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Permanent").Wait();
                }
            }
            if (userManager.FindByEmailAsync("shaahin.madani@rmit.edu.au").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = user.Email = "shaahin.madani@rmit.edu.au";
                user.EmailConfirmed = true;
                user.User = new User() { Name = "Shaahin Madani", Email = user.UserName, PublicProfile = false };
                IdentityResult result = userManager.CreateAsync(user, "Password1!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Permanent").Wait();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
