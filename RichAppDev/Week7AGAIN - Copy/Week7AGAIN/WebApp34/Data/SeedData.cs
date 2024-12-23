﻿using Microsoft.EntityFrameworkCore;
using WebApp34.Data.Models;
using WebApp34.Data;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Identity;
using WebApp34.Authorization;
using Constants = WebApp34.Authorization.Constants;

// dotnet aspnet-codegenerator razorpage -m Contact -dc ApplicationDbContext -udl -outDir Pages\Contacts --referenceScriptLibraries

namespace WebApp34.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@contoso.com");
                await EnsureRole(serviceProvider, adminID, Constants.ContactAdministratorsRole);

                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, testUserPw, "manager@contoso.com");
                await EnsureRole(serviceProvider, managerID, Constants.ContactManagersRole);

                SeedDB(context, adminID);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                            string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string uid, string role)
        {
            // Get RoleManager from DI container
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager is null");
            }

            IdentityResult result;
            IdentityResult applicationResult = ApplicationResult.FromIdentityResult(result);

            // Check if the role already exists, and create it if it doesn't
            if (!await roleManager.RoleExistsAsync(role))
            {
                // Use the constructor that accepts a role name
                result = await roleManager.CreateAsync(new ApplicationRole(role));

                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to create role {role}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }

            // Get UserManager from DI container
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (userManager == null)
            {
                throw new Exception("userManager is null");
            }

            // Find the user by ID
            var user = await userManager.FindByIdAsync(uid);
            if (user == null)
            {
                throw new Exception($"User with ID {uid} not found");
            }

            // Add the user to the specified role
            result = await userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                //throw new Exception($"Failed to add user to role {role}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }

            return result;
        }



        public static void SeedDB(ApplicationDbContext context, string adminID)
        {
            if (context.Contact.Any())
            {
                return;   // DB has been seeded
            }

            context.Contact.AddRange(
                new Contact
                {
                    Name = "Debra Garcia",
                    Address = "1234 Main St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "debra@example.com",
                    Status = ContactStatus.Approved
                },
                new Contact
                {
                    Name = "Thorsten Weinrich",
                    Address = "5678 1st Ave W",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "thorsten@example.com",
                    Status = ContactStatus.Rejected
                },
                new Contact
                {
                    Name = "Yuhong Li",
                    Address = "9012 State st",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "yuhong@example.com",
                    Status = ContactStatus.Submitted
                },
                new Contact
                {
                    Name = "Jon Orton",
                    Address = "3456 Maple St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "jon@example.com",
                    Status = ContactStatus.Submitted
                },
                new Contact
                {
                    Name = "Diliana Alexieva-Bosseva",
                    Address = "7890 2nd Ave E",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "diliana@example.com",
                    Status = ContactStatus.Submitted
                }
             );
            context.SaveChanges();
        }

    }
}
