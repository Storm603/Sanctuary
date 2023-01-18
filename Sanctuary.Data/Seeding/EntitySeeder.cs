using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Models.PetTables;
using Sanctuary.Data.Models.UserTables;
using Sanctuary.Web.Data;

namespace Sanctuary.Data.Seeding
{
    public static class EntitySeeder
    {
        public static async Task SeedEntities(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            if (context.Clinics.Any())
            {
                return;
            }


            CreateClinics(context);

            CreateBreeds(context);

            CreateUsersAndTheirRoleTables(context, serviceProvider);

            CreateAddressesAndBindThemToClinicsAndUsers(context);

            CreatePetsAndBindThemToClientUsers(context);

        }


        private static void CreateBreeds(ApplicationDbContext context)
        {
            context.Breeds.AddRange(new Breed()
            {
                Name = "Dog"
            }, new Breed()
            {
                Name = "Winged"
            }, new Breed()
            {
                Name = "Cat"
            }, new Breed()
            {
                Name = "Hamster"
            });

            context.SaveChanges();
        }

        private static void CreateClinics(ApplicationDbContext context)
        {
            context.Clinics.AddRange(
                new Clinic()
                {
                    Id = new Guid("0545129a-bdb9-4c8d-885e-2d9844e57f4a"),
                    HospitalizedPetCagedNumber = 20,
                    ClinicName = "SanctuaryZdravetc",
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                },
                new Clinic()
                {
                    Id = new Guid("9757a7df-dbf4-403d-8d84-98440fb48393"),
                    HospitalizedPetCagedNumber = 20,
                    ClinicName = "SanctuaryRodina",
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                },
                new Clinic()
                {
                    Id = new Guid("41adba76-20a4-4b2f-9c0a-edf8346b8f80"),
                    HospitalizedPetCagedNumber = 20,
                    ClinicName = "SanctuaryDrujba",
                    CreatedOn = DateTime.UtcNow,
                    IsDeleted = false,
                },
            new Clinic()
            {
                Id = new Guid("c370d263-f095-4888-9f0e-5a2fdd49b8f3"),
                HospitalizedPetCagedNumber = 20,
                ClinicName = "SofiaCentral",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            },
            new Clinic()
            {
                Id = new Guid("092ab3fa-0088-491f-82a8-8cd7a65d408e"),
                HospitalizedPetCagedNumber = 20,
                ClinicName = "BurgasCentral",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            });
            context.SaveChanges();

        }

        private static void CreateUsersAndTheirRoleTables(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<BaseApplicationUser>>();

            string password = "Testing1234#";

            List<BaseApplicationUser> users = new List<BaseApplicationUser>()
            {
                new BaseApplicationUser()
                {
                    Id = "56a56a66-c781-4131-ade8-c38fcb53907b",

                    FirstName = "Kristiyan",
                    LastName = "Stoyanov",
                    UserName = "Kristiyan",
                    Email = "kristiyan@abv.bg",
                    PhoneNumber = "709543584375"
                },
                new BaseApplicationUser()
                {
                    Id = "7655b339-1170-4f7b-9dbc-4b93ddbb2500",
                    FirstName = "Dimictrichko",
                    LastName = "Stoyanov",
                    UserName = "Dimictrichko",
                    Email = "Dimictrichko@abv.bg",
                    PhoneNumber = "7092324384375"
                },
                new BaseApplicationUser()
                {
                    Id = "bbd03955-6fa8-4992-a4f2-323eba8ce492",
                    FirstName = "Dimictrichka",
                    LastName = "Stoyanova",
                    UserName = "Dimictrichka",
                    Email = "Dimictrichka@abv.bg",
                    PhoneNumber = "7023432984375"
                },
                new BaseApplicationUser()
                {
                    Id = "44ef7ffb-e7fa-44d1-9140-743258f2e15f",
                    FirstName = "Ivancho",
                    LastName = "Stoyanov",
                    UserName = "Ivancho",
                    Email = "Ivancho@abv.bg",
                    PhoneNumber = "7098324234375"
                }
                ,
                new BaseApplicationUser()
                {
                    Id = "e181f671-6d99-4bf3-ad18-dc3ce49fe848",
                    FirstName = "tes",
                    LastName = "tes",
                    UserName = "tes@abv.bg",
                    Email = "tes@abv.bg",
                    PhoneNumber = "7098324234375"
                }
            };


            foreach (BaseApplicationUser user in users)
            {
                userManager.CreateAsync(user, password).GetAwaiter().GetResult();
            }

            context.SaveChanges();

            context.ClientUsers.AddRange(
                new ClientUser()
                {
                    Id = "cdb171a1-2b49-47ff-9fab-555297bf25a4",
                    BaseUserId = "bbd03955-6fa8-4992-a4f2-323eba8ce492",
                    ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a")
                },
                new ClientUser()
                {
                    Id = "c6482797-412d-451d-aab9-cf3d1ac39a39",
                    BaseUserId = "44ef7ffb-e7fa-44d1-9140-743258f2e15f",
                    ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a")
                },
                new ClientUser()
                {
                    Id = "2567371c-82ef-45ad-a9be-616a2b3252fe",
                    BaseUserId = "e181f671-6d99-4bf3-ad18-dc3ce49fe848",
                    ClinicId = Guid.Parse("c370d263-f095-4888-9f0e-5a2fdd49b8f3")
                });

            var clientUserListForSeeding = new List<ClinicStaffUser>()
            {
                new ClinicStaffUser()
                {
                    TotalPaidDaysLeave = 22,
                    BaseUserId = "56a56a66-c781-4131-ade8-c38fcb53907b",
                    ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a")
                },
                new ClinicStaffUser()
                {
                    TotalPaidDaysLeave = 20,
                    BaseUserId = "7655b339-1170-4f7b-9dbc-4b93ddbb2500",
                    ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a")
                }
            };

            context.ClinicStaffUsers.AddRange(clientUserListForSeeding);

            context.SaveChanges();

            var clinic = context.Clinics.First();

            clinic.Doctor.AddRange(clientUserListForSeeding);

            context.SaveChanges();

            Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(users[0], "User");
            newUserRole.Wait();
            Task<IdentityResult> newUserRole1 = userManager.AddToRoleAsync(users[1], "User");
            newUserRole1.Wait();
            Task<IdentityResult> newUserRole2 = userManager.AddToRoleAsync(users[2], "Common Veterinary");
            newUserRole2.Wait();
            Task<IdentityResult> newUserRole3 = userManager.AddToRoleAsync(users[3], "Common Veterinary");
            newUserRole3.Wait();
        }

        private static void CreateAddressesAndBindThemToClinicsAndUsers(ApplicationDbContext context)
        {
            context.Addresses.AddRange(new Address()
            {
                Country = "Bulgaria",
                Town = "Rousse",
                PostalCode = "7002",
                StreetName = "Bolyarska",
                lon = (float?)43.852756,
                lat = (float?)25.960411
            }, new Address()
            {
                Country = "Bulgaria",
                Town = "Rousse",
                PostalCode = "7001",
                StreetName = "Ekzarh Yosif",
                lon = (float?)43.831821,
                lat = (float?)25.948962
            }, new Address()
            {
                Country = "Bulgaria",
                Town = "Rousse",
                PostalCode = "7005",
                StreetName = "Zahari Stoyanov",
                lon = (float?)43.848259,
                lat = (float?)25.980315
            }, new Address()
            {
                Country = "Bulgaria",
                Town = "Rousse",
                PostalCode = "7003",
                StreetName = "Iskar",
                lon = (float?)43.864387,
                lat = (float?)25.985327
            }, new Address()
            {
                Country = "Bulgaria",
                Town = "Rousse",
                PostalCode = "7010",
                StreetName = "Han Telerig",
                lon = (float?)43.797872,
                lat = (float?)25.927210
            }, new Address()
            {
                Country = "Bulgaria",
                Town = "Rousse",
                PostalCode = "7009",
                StreetName = "TEC iztok",
                lon = (float?)43.870046,
                lat = (float?)26.014576
            }, new Address()
            {
                Country = "Bulgaria",
                Town = "Rousse",
                PostalCode = "7012",
                StreetName = "David",
                lon = (float?)43.840196,
                lat = (float?)25.952998
            }, new Address()
            {
                Country = "Bulgaria",
                Town = "Sofia",
                PostalCode = "1000",
                StreetName = "Knyaz Boris I",
                lon = (float?)42.6945152,
                lat = (float?)23.3182411
            }, new Address()
            {
                Country = "Bulgaria",
                Town = "Burgas",
                PostalCode = "8000",
                StreetName = "Skopie",
                lon = (float?)42.49863,
                lat = (float?)27.4693336
            }, new Address()
            {
                Country = "Bulgaria",
                Town = "Sofia",
                PostalCode = "8000",
                StreetName = "Vasil Levski",
                lon = (float?)42.713445,
                lat = (float?)23.306986
            });

            context.MtClinicAddresses.AddRange(new MT_Clinic_Addresses()
            {
                AddressId = 1,
                ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a"),
            }, new MT_Clinic_Addresses()
            {
                AddressId = 2,
                ClinicId = Guid.Parse("9757a7df-dbf4-403d-8d84-98440fb48393"),
            }, new MT_Clinic_Addresses()
            {
                AddressId = 3,
                ClinicId = Guid.Parse("41adba76-20a4-4b2f-9c0a-edf8346b8f80"),
            }
                , new MT_Clinic_Addresses()
                {
                    AddressId = 8,
                    ClinicId = Guid.Parse("c370d263-f095-4888-9f0e-5a2fdd49b8f3"),
                }, new MT_Clinic_Addresses()
                {
                    AddressId = 9,
                    ClinicId = Guid.Parse("092ab3fa-0088-491f-82a8-8cd7a65d408e"),
                });

            context.SaveChanges();

            context.MtUserAddresses.AddRange(new MT_User_Addresses()
            {
                AddressId = 4,
                UserId = "56a56a66-c781-4131-ade8-c38fcb53907b"
            }, new MT_User_Addresses()
            {
                AddressId = 5,
                UserId = "7655b339-1170-4f7b-9dbc-4b93ddbb2500"
            }, new MT_User_Addresses()
            {
                AddressId = 6,
                UserId = "bbd03955-6fa8-4992-a4f2-323eba8ce492"
            }, new MT_User_Addresses()
            {
                AddressId = 7,
                UserId = "44ef7ffb-e7fa-44d1-9140-743258f2e15f"
            }, new MT_User_Addresses()
            {
                AddressId = 9,
                UserId = "e181f671-6d99-4bf3-ad18-dc3ce49fe848"
            });

            context.SaveChanges();

        }

        private static void CreatePetsAndBindThemToClientUsers(ApplicationDbContext context)
        {
            List<Pet> listOfPetsToBeSeeded = new List<Pet>()
            {
                new Pet()
                {
                    Id = Guid.Parse("59f3a075-c1c7-4e84-9d71-a76b39fcb2fd"),
                    Name = "Djonko",
                    BreedId = 1,
                    DateOfBirth = DateTime.Parse("2016-03-12"),
                    Sex = 'M',
                    Weight = (float) 11.21,
                    EyeColor = "blue",
                    FurColor = "white",
                    Microchip = false,
                    Description = "A very good boy!",
                    ClientUserId = "cdb171a1-2b49-47ff-9fab-555297bf25a4"
                },
                new Pet()
                {
                    Id = Guid.Parse("ef1ed0b9-bf87-461b-afbb-3e9d6dddbd1a"),
                    Name = "Blue",
                    BreedId = 2,
                    DateOfBirth = DateTime.Parse("2016-03-12"),
                    Sex = 'M',
                    Weight = (float) 11.21,
                    EyeColor = "blue",
                    FurColor = "blue",
                    Microchip = false,
                    Description = "A very good bird!",
                    ClientUserId = "cdb171a1-2b49-47ff-9fab-555297bf25a4"
                },
                new Pet()
                {
                    Id = Guid.Parse("579a8926-fa81-407b-8d5d-e684b100d7df"),
                    Name = "Fiona",
                    BreedId = 3,
                    DateOfBirth = DateTime.Parse("2016-03-12"),
                    Sex = 'F',
                    Weight = (float) 11.21,
                    EyeColor = "black",
                    FurColor = "black",
                    Microchip = false,
                    Description = "A very good cat!",
                    ClientUserId = "cdb171a1-2b49-47ff-9fab-555297bf25a4"
                }, new Pet()
                {
                    Id = Guid.Parse("0eb8bcae-c1e7-41e4-8b4a-8646ef40dfa4"),
                    Name = "Djonko",
                    BreedId = 4,
                    DateOfBirth = DateTime.Parse("2016-03-12"),
                    Sex = 'M',
                    Weight = (float) 11.21,
                    EyeColor = "blue",
                    FurColor = "white",
                    Microchip = false,
                    Description = "A very good boy!",
                    ClientUserId = "c6482797-412d-451d-aab9-cf3d1ac39a39"
                }
            };

            context.Pets.AddRange(listOfPetsToBeSeeded);

            context.SaveChanges();

        }
    }
}
