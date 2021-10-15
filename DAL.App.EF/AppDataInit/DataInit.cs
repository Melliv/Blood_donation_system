using System;
using System.Collections.Generic;
using System.Linq;
using DAL.App.DTO;
using Domain.App.Identity;
using Domain.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using BloodGroup = Domain.App.BloodGroup;

namespace DAL.App.EF.AppDataInit
{
    public static class DataInit
    {
        public static void DropDatabase(AppDbContext context, ILogger logger)
        {
            logger.LogInformation("DropDatabase");
            context.Database.EnsureDeleted();
        }

        public static void MigrateDatabase(AppDbContext context, ILogger logger)
        {
            logger.LogInformation("MigrateDatabase");
            context.Database.Migrate();
        }
        
        public static void SeedData(AppDbContext context, ILogger logger)
        {
            SeedInitial(context, logger);
        }

        private static void SeedInitial(AppDbContext context, ILogger logger)
        {
            if (context.Person.Any())
            {
                logger.LogInformation("Contests - existing data found");
                return;
            }

            foreach (var (contactTypeValue, culture) in InitialData.ContactTypes)
            {
                var langStringFirst = new LangString();

                for (int i = 0; i < culture.Length; i++)
                {
                    langStringFirst.SetTranslation(contactTypeValue[i], culture[i]);
                }

                var contactType = new Domain.App.ContactType()
                {
                    ContactTypeValue = langStringFirst
                };

                context.ContactType.Add(contactType);
                context.SaveChanges();
            }
            
            EntityEntry<BloodGroup> bg = default!;
            foreach (var bloodGroupInfo in InitialData.BloodGroups)
            {
                
                var bloodGroup = new Domain.App.BloodGroup()
                {
                    BloodGroupValue = new LangString(bloodGroupInfo, "en-GB")
                };

                bg = context.BloodGroup.Add(bloodGroup);
                context.SaveChanges();
            }
            
            EntityEntry<Domain.App.PersonType> pt = default!;
            foreach (var (personTypeValue, secondaryPersonTypeValue, culture) in InitialData.PersonTypes)
            {
                var langStringFirst = new LangString();
                var langStringSecond = new LangString();

                for (int i = 0; i < culture.Length; i++)
                {
                    langStringFirst.SetTranslation(personTypeValue[i], culture[i]);
                    langStringSecond.SetTranslation(secondaryPersonTypeValue[i], culture[i]);
                }

                var personType = new Domain.App.PersonType()
                {
                    PersonTypeValue = langStringFirst,
                    SecondaryPersonTypeValue = langStringSecond
                };

                pt = context.PersonType.Add(personType);
                context.SaveChanges();
            }
            
            foreach (var personInfo in InitialData.Persons)
            {
                var person = new Domain.App.Person()
                {
                    Firstname = personInfo.firstName,
                    Lastname = personInfo.lastName,
                    IdentificationCode = personInfo.identificationCode,
                    Comments = personInfo.comments,
                    BloodGroupId = bg!.Entity.Id,
                    PersonTypeId = pt!.Entity.Id,
                };

                context.Person.Add(person);
                context.SaveChanges();
            }

        }

        public static void SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,
            ILogger logger)
        {
            logger.LogInformation("SeedIdentity");
            foreach (var (roleName, displayName) in InitialData.Roles)
            {
                var role = roleManager.FindByNameAsync(roleName).Result;
                if (role == null)
                {
                    role = new AppRole()
                    {
                        Name = roleName,
                        DisplayName = displayName
                    };

                    var result = roleManager.CreateAsync(role).Result;
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("Role creation failed");
                    }
                    logger.LogInformation("Seeded role {Role}", roleName);
                }
            }

            foreach (var userInfo in InitialData.Users)
            {
                var user = userManager.FindByNameAsync(userInfo.name).Result;
                if (user == null)
                {
                    user = new AppUser()
                    {
                        Email = userInfo.name,
                        UserName = userInfo.name,
                        FirstName = userInfo.firstName,
                        LastName = userInfo.lastName,
                        DOB = userInfo.DOB,
                        EmailConfirmed = true
                    };

                    var result = userManager.CreateAsync(user, userInfo.password).Result;
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("User creation failed");
                    }
                    logger.LogInformation("Seeded user {User}", userInfo.name);

                }

                var roleResult = userManager.AddToRolesAsync(user, userInfo.roles).Result;
            }

        }


    }
}