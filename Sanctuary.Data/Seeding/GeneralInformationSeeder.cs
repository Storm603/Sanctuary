using Sanctuary.Common;
using Sanctuary.Data.Models.LocationTables;
using Sanctuary.Data.Models.PetTables;
using Sanctuary.Data.Models.ClinicTables;
using Sanctuary.Data.Models.UserTables;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Sanctuary.Data.Seeding
{
    // This class seeds information in this specific order: Breeds -> Clinics -> Users.

    // This class seeds Breeds in the SeedBreedsAsync method,
    // creates Clinics and assigns addresses to them in the SeedClinicsAndAddressesAsync method,
    // creates Users and assigns them the proper sub-table(Client, Veterinary), Clinic ID, creates them new Address and seeds the corresponding users to their appropriate roles in the SeedUsersTheirAddressesPetsClinicIdsAndRolesAsync method


    // IMPORTANT!!!!!!

    // Every new record(User, Vet, Clinic, Pet) needs to have an image added in the appropriate folder in the following directory "C:\Users\Kristiyan\Documents\SanctuaryPhotos" for the PhotoSeeder class

    // Total Entity Counts with photos:
    // Clinics: 7, Veterinarians: 4, Clients: 7, Pets: 8

    internal class GeneralInformationSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            await SeedBreedsAsync(context);
            await SeedClinicsAndAddressesAsync(context);
            await SeedUsersTheirAddressesPetsClinicIdsAndRoleAssignmentAsync(context, serviceProvider);
        }

        private async Task SeedUsersTheirAddressesPetsClinicIdsAndRoleAssignmentAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<BaseApplicationUser>>();

            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            List<BaseApplicationUser> users = new List<BaseApplicationUser>()
            {
                // Four Veterinarians
                new BaseApplicationUser()
                {
                    // has appointment with clientUserId = c6482797-412d-451d-aab9-cf3d1ac39a39
                    //                                      1146fc2b-09cd-424e-a2d8-20e8e1836731
                    //                                      30b0a024-61d0-4a17-b610-231df2b6c560
                    //                                      ab3012dd-3e21-4a69-92ef-a21983868159
                    //                                      3e76e2bf-f936-4106-90f4-60a411a346e9
                    // 7002
                    // has 2 appointments 
                    Id = "56a56a66-c781-4131-ade8-c38fcb53907b",
                    FirstName = "Kristiyan",
                    LastName = "Stoyanov",
                    Email = "kristiyan@abv.bg",
                    UserName = "kristiyan@abv.bg",
                    PhoneNumber = "709543584375",
                    Veterinary = new ClinicStaffUser()
                    {
                        Id = "c1f4eece-e448-40a6-8ce0-b2d7e823c7c5",
                        CabinetNumber = "101",
                        TotalPaidDaysLeave = 22,
                        UserId = "56a56a66-c781-4131-ade8-c38fcb53907b",
                        ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a")
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("61abcb25-ed6d-4d9c-890e-25aa39216974"),
                        UserId = "56a56a66-c781-4131-ade8-c38fcb53907b",
                        District = "Ruse",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        PostalCodeInfoId = Guid.Parse("25ed1503-0e8a-4ba8-9897-2161d00f1272"),
                        StreetName = "Iskar",
                        lat = (float?) 43.864387,
                        lon = (float?) 25.985327
                    }
                },
                new BaseApplicationUser()
                {
                    // 7002
                    Id = "7655b339-1170-4f7b-9dbc-4b93ddbb2500",
                    FirstName = "Dimictrichko",
                    LastName = "Stoyanov",
                    Email = "Dimictrichko@abv.bg",
                    UserName = "Dimictrichko@abv.bg",
                    PhoneNumber = "7092324384375",
                    Veterinary = new ClinicStaffUser()
                    {
                        Id = "7a16b0f2-16a6-483c-934f-7ce6eb9e93bb",
                        CabinetNumber = "102",
                        TotalPaidDaysLeave = 20,
                        UserId = "7655b339-1170-4f7b-9dbc-4b93ddbb2500",
                        ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a")
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("bead4b72-d0da-4f90-b28f-bb37e56515f3"),
                        UserId = "7655b339-1170-4f7b-9dbc-4b93ddbb2500",
                        District = "Ruse",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        PostalCodeInfoId = Guid.Parse("56d71ae8-260f-401b-a881-e17dff340582"),
                        StreetName = "Han Telerig",
                        lat = (float?) 43.797872,
                        lon = (float?) 25.927210
                    }
                },
                new BaseApplicationUser()
                {
                    Id = "ea1605d5-042c-4f92-9635-cf29c38ce67c",
                    FirstName = "Stoyan",
                    LastName = "Shopov",
                    Email = "stoyans@abv.bg",
                    UserName = "stoyans@abv.bg",
                    PhoneNumber = "709155485652",
                    Veterinary = new ClinicStaffUser()
                    {
                        Id = "e49762dc-9b08-48ac-a365-541ff94bdeba",
                        CabinetNumber = "103",
                        TotalPaidDaysLeave = 22,
                        UserId = "ea1605d5-042c-4f92-9635-cf29c38ce67c",
                        ClinicId = Guid.Parse("c370d263-f095-4888-9f0e-5a2fdd49b8f3")
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("9a3513e4-980e-4d46-81f5-7d6cc6a34777"),
                        UserId = "ea1605d5-042c-4f92-9635-cf29c38ce67c",
                        District = "Sofia",
                        Country = "Bulgaria",
                        Town = "Sofia",
                        PostalCodeInfoId = Guid.Parse("e1b05bcf-cf22-4552-8cd6-5977f730cc81"),
                        StreetName = "Veliko Tarnovo",
                        lat = (float?) 42.693959,
                        lon = (float?) 23.341269
                    }
                },
                new BaseApplicationUser()
                {
                    Id = "d54a0540-4c35-431f-96aa-4cc7dc9d58ed",
                    FirstName = "Boris",
                    LastName = "Gerganov",
                    Email = "BorisG@abv.bg",
                    UserName = "BorisG@abv.bg",
                    PhoneNumber = "7092324384375",
                    Veterinary = new ClinicStaffUser()
                    {
                        Id = "5837e3e9-6211-4616-9481-b813c6aca527",
                        CabinetNumber = "104",
                        TotalPaidDaysLeave = 20,
                        UserId = "d54a0540-4c35-431f-96aa-4cc7dc9d58ed",
                        ClinicId = Guid.Parse("c370d263-f095-4888-9f0e-5a2fdd49b8f3")
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("94192e7f-f92c-4d32-8142-cda9837dbe89"),
                        UserId = "d54a0540-4c35-431f-96aa-4cc7dc9d58ed",
                        District = "Sofia",
                        Country = "Bulgaria",
                        Town = "Sofia",
                        PostalCodeInfoId = Guid.Parse("e1b05bcf-cf22-4552-8cd6-5977f730cc81"),
                        StreetName = "Marin Drimov",
                        lat = (float?) 42.695500,
                        lon = (float?) 23.342677
                    }
                },
                // Three Users
                new BaseApplicationUser()
                {
                    Id = "bbd03955-6fa8-4992-a4f2-323eba8ce492",
                    FirstName = "Dimictrichka",
                    LastName = "Stoyanova",
                    Email = "Dimictrichka@abv.bg",
                    UserName = "Dimictrichka@abv.bg",
                    PhoneNumber = "7023432984375",
                    Client = new ClientUser()
                    {
                        Id = "cdb171a1-2b49-47ff-9fab-555297bf25a4",
                        UserId = "bbd03955-6fa8-4992-a4f2-323eba8ce492",
                        PetOwnerships = new List<Pet>()
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
                                Weight = (float) 3.76,
                                EyeColor = "black",
                                FurColor = "blue",
                                Microchip = false,
                                Description = "A very good parrot!",
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
                            }
                        },
                        ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a")
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("530daa79-ee72-42ad-bc91-d2c64d942f91"),
                        UserId = "bbd03955-6fa8-4992-a4f2-323eba8ce492",
                        District = "Ruse",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        PostalCodeInfoId = Guid.Parse("861e8a04-659c-48fb-883f-f4791df50d06"),
                        StreetName = "TEC iztok",
                        lat = (float?) 43.870046,
                        lon = (float?) 26.014576
                    }
                },
                new BaseApplicationUser()
                {
                    Id = "44ef7ffb-e7fa-44d1-9140-743258f2e15f",
                    FirstName = "Ivancho",
                    LastName = "Stoyanov",
                    Email = "Ivancho@abv.bg",
                    UserName = "Ivancho@abv.bg",
                    PhoneNumber = "7098324234375",
                    Client = new ClientUser()
                    {
                        Id = "c6482797-412d-451d-aab9-cf3d1ac39a39",
                        UserId = "44ef7ffb-e7fa-44d1-9140-743258f2e15f",
                        PetOwnerships = new List<Pet>()
                        {
                            new Pet()
                            {
                                Id = Guid.Parse("0eb8bcae-c1e7-41e4-8b4a-8646ef40dfa4"),
                                Name = "Rex",
                                BreedId = 4,
                                DateOfBirth = DateTime.Parse("2016-03-12"),
                                Sex = 'M',
                                Weight = (float) 11.21,
                                EyeColor = "black",
                                FurColor = "white",
                                Microchip = false,
                                Description = "A very good hamster!",
                                ClientUserId = "c6482797-412d-451d-aab9-cf3d1ac39a39"
                            }
                        },
                        ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a")
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("56799795-8f79-4ad2-8006-69a585e04acc"),
                        UserId = "44ef7ffb-e7fa-44d1-9140-743258f2e15f",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        District = "Ruse",
                        PostalCodeInfoId = Guid.Parse("ccf3a2a9-c45d-4973-be56-41ee074f4e3a"),
                        StreetName = "David",
                        lat = (float?) 43.840196,
                        lon = (float?) 25.952998
                    }
                },
                new BaseApplicationUser()
                {
                    Id = "e181f671-6d99-4bf3-ad18-dc3ce49fe848",
                    FirstName = "tes",
                    LastName = "tes",
                    Email = "tes@abv.bg",
                    UserName = "tes@abv.bg",
                    PhoneNumber = "7098324234375",
                    Client = new ClientUser()
                    {
                        Id = "30b0a024-61d0-4a17-b610-231df2b6c560",
                        UserId = "e181f671-6d99-4bf3-ad18-dc3ce49fe848",
                        ClinicId = Guid.Parse("c370d263-f095-4888-9f0e-5a2fdd49b8f3")
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("c1da48c5-9aed-4875-970c-ad584ffb4518"),
                        UserId = "e181f671-6d99-4bf3-ad18-dc3ce49fe848",
                        Country = "Bulgaria",
                        Town = "Sofia",
                        District = "Sofia",
                        PostalCodeInfoId = Guid.Parse("e1b05bcf-cf22-4552-8cd6-5977f730cc81"),
                        StreetName = "Skopie",
                        lat = (float?) 42.713445,
                        lon = (float?) 23.306986
                    }
                },
                ////////// new addition
                new BaseApplicationUser()
                {
                    Id = "d7b6b13c-bd39-468d-bd2a-ba796a19b8fe",
                    FirstName = "Martin",
                    LastName = "Martinov",
                    Email = "martincho@abv.bg",
                    UserName = "martincho@abv.bg",
                    PhoneNumber = "78954379543975",
                    Client = new ClientUser()
                    {
                        Id = "1146fc2b-09cd-424e-a2d8-20e8e1836731",
                        UserId = "d7b6b13c-bd39-468d-bd2a-ba796a19b8fe",
                        ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a"),
                        PetOwnerships = new List<Pet>()
                        {
                            new Pet()
                            {
                                Id = Guid.Parse("ce19863b-ae5c-4f51-ab03-32dcf282b0cf"),
                                Name = "Pisan",
                                BreedId = 4,
                                DateOfBirth = DateTime.Parse("2016-03-12"),
                                Sex = 'M',
                                Weight = (float) 11.21,
                                EyeColor = "brown",
                                FurColor = "brown",
                                Microchip = false,
                                Description = "A very good cat!",
                                ClientUserId = "1146fc2b-09cd-424e-a2d8-20e8e1836731"
                            }
                        }
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("8c1d4d72-8973-4dc0-b8ee-8c25b3208245"),
                        UserId = "1146fc2b-09cd-424e-a2d8-20e8e1836731",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        District = "Ruse",
                        PostalCodeInfoId = Guid.Parse("e1b05bcf-cf22-4552-8cd6-5977f730cc81"),
                        StreetName = "SomeName1",
                        lat = (float?) 42.723445,
                        lon = (float?) 23.316986
                    }
                },
                new BaseApplicationUser()
                {
                    Id = "bb248e9d-2dd1-4f4b-b1af-aa687a66d802",
                    FirstName = "Svetoslav",
                    LastName = "Georgiev",
                    Email = "georgiev123@abv.bg",
                    UserName = "georgiev123@abv.bg",
                    PhoneNumber = "7893484948",
                    Client = new ClientUser()
                    {
                        Id = "878dd304-0a13-46d2-b679-ac4475b57c25",
                        UserId = "bb248e9d-2dd1-4f4b-b1af-aa687a66d802",
                        ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a"),
                        PetOwnerships = new List<Pet>()
                        {
                            new Pet()
                            {
                                Id = Guid.Parse("1f33e4d9-7b5d-421c-9b74-fc737973f48e"),
                                Name = "Pisana",
                                BreedId = 4,
                                DateOfBirth = DateTime.Parse("2018-03-12"),
                                Sex = 'F',
                                Weight = (float) 11.21,
                                EyeColor = "brown",
                                FurColor = "brown",
                                Microchip = false,
                                Description = "A very good cat!",
                                ClientUserId = "878dd304-0a13-46d2-b679-ac4475b57c25"
                            }
                        },
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("2bed8a42-58f0-41ec-bd91-ba5269fb1338"),
                        UserId = "878dd304-0a13-46d2-b679-ac4475b57c25",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        District = "Ruse",
                        PostalCodeInfoId = Guid.Parse("e1b05bcf-cf22-4552-8cd6-5977f730cc81"),
                        StreetName = "SomeName2",
                        lat = (float?) 42.703445,
                        lon = (float?) 23.296986
                    }
                },
                new BaseApplicationUser()
                {
                    Id = "f4b61bee-94ff-4076-8385-de70cf5e4944",
                    FirstName = "Yana",
                    LastName = "Yanova",
                    Email = "yana@abv.bg",
                    UserName = "yana@abv.bg",
                    PhoneNumber = "756746435",
                    Client = new ClientUser()
                    {
                        Id = "ab3012dd-3e21-4a69-92ef-a21983868159",
                        UserId = "f4b61bee-94ff-4076-8385-de70cf5e4944",
                        ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a"),
                        PetOwnerships = new List<Pet>()
                        {
                            new Pet()
                            {
                                Id = Guid.Parse("ed14f8d7-43d4-4958-b94f-95cffaa19f3c"),
                                Name = "Tigura",
                                BreedId = 4,
                                DateOfBirth = DateTime.Parse("2020-01-22"),
                                Sex = 'M',
                                Weight = (float) 11.21,
                                EyeColor = "brown",
                                FurColor = "brown",
                                Microchip = false,
                                Description = "A very good cat!",
                                ClientUserId = "ab3012dd-3e21-4a69-92ef-a21983868159"
                            }
                        },
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("6c362634-ad32-4e40-bcc2-4636a38b6287"),
                        UserId = "ab3012dd-3e21-4a69-92ef-a21983868159",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        District = "Ruse",
                        PostalCodeInfoId = Guid.Parse("e1b05bcf-cf22-4552-8cd6-5977f730cc81"),
                        StreetName = "SomeName3",
                        lat = (float?) 43.000000,
                        lon = (float?) 23.706986
                    }
                },
                new BaseApplicationUser()
                {
                    Id = "825ca698-6afc-41b3-99dd-d7bf462adc78",
                    FirstName = "Maria",
                    LastName = "Marijkova",
                    Email = "marijka@abv.bg",
                    UserName = "marijka@abv.bg",
                    PhoneNumber = "73654746853",
                    Client = new ClientUser()
                    {
                        Id = "3e76e2bf-f936-4106-90f4-60a411a346e9",
                        UserId = "825ca698-6afc-41b3-99dd-d7bf462adc78",
                        ClinicId = Guid.Parse("0545129a-bdb9-4c8d-885e-2d9844e57f4a"),
                        PetOwnerships = new List<Pet>()
                        {
                            new Pet()
                            {
                                Id = Guid.Parse("5970d47d-5892-482e-9beb-01020e519592"),
                                Name = "Rexi",
                                BreedId = 4,
                                DateOfBirth = DateTime.Parse("2016-03-12"),
                                Sex = 'M',
                                Weight = (float) 11.21,
                                EyeColor = "brown",
                                FurColor = "brown",
                                Microchip = false,
                                Description = "A very good cat!",
                                ClientUserId = "3e76e2bf-f936-4106-90f4-60a411a346e9"
                            }
                        },
                    },
                    Address = new Address()
                    {
                        Id = Guid.Parse("c81f1b2e-6469-4d4f-8e81-a02db90ca76a"),
                        UserId = "3e76e2bf-f936-4106-90f4-60a411a346e9",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        District = "Ruse",
                        PostalCodeInfoId = Guid.Parse("e1b05bcf-cf22-4552-8cd6-5977f730cc81"),
                        StreetName = "SomeName4",
                        lat = (float?) 42.513445,
                        lon = (float?) 23.206986
                    }
                }

            };

            string userPassword = "Testing1234#";

            foreach (BaseApplicationUser user in users)
            {
                var result = await userManager!.CreateAsync(user, userPassword);

                if (!result.Succeeded)
                {
                    throw new Exception($"User unsuccessfully created in the {nameof(GeneralInformationSeeder)} class method {nameof(SeedUsersTheirAddressesPetsClinicIdsAndRoleAssignmentAsync)}.");
                }
            }

            await context.SaveChangesAsync();
            //var users = context.BaseUser
            // Rough role assignment
            foreach (var appUser in users)
            {
                if (appUser.Client != null)
                {
                    await userManager!.AddToRoleAsync(appUser, ExistingIdentityRolesConstants.UserRoleName);
                }
                else
                {
                    await userManager!.AddToRoleAsync(appUser, ExistingIdentityRolesConstants.CommonVeterinaryRoleName);
                }
            }

            await context.SaveChangesAsync();
        }

        private async Task SeedClinicsAndAddressesAsync(ApplicationDbContext context)
        {
            await context.Clinics.AddRangeAsync(
                new Clinic()
                {
                    Id = new Guid("0545129a-bdb9-4c8d-885e-2d9844e57f4a"),
                    HospitalizedPetCagedNumber = 20,
                    ClinicName = "SanctuaryZdravetc",
                    Address = new Address()
                    {
                        Id = Guid.Parse("d306b5db-57b5-473b-902b-ac4f4b07b081"),
                        District = "Ruse",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        PostalCodeInfoId = Guid.Parse("44509afe-295a-47cd-8d70-6c2adc71e65f"),
                        StreetName = "Bolyarska",
                        lat = (float?)43.852756,
                        lon = (float?)25.960411
                    }
                },
                new Clinic()
                {
                    Id = new Guid("9757a7df-dbf4-403d-8d84-98440fb48393"),
                    HospitalizedPetCagedNumber = 20,
                    ClinicName = "SanctuaryRodina",
                    Address = new Address()
                    {
                        Id = Guid.Parse("4777bec3-ec39-4e56-a9ee-1195882998f0"),
                        District = "Ruse",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        PostalCodeInfoId = Guid.Parse("b8fc3d41-f2ee-413d-a3de-c5dca6a81f90"),
                        StreetName = "Ekzarh Yosif",
                        lat = (float?)43.831821,
                        lon = (float?)25.948962
                    }
                },
                new Clinic()
                {
                    Id = new Guid("41adba76-20a4-4b2f-9c0a-edf8346b8f80"),
                    HospitalizedPetCagedNumber = 20,
                    ClinicName = "SanctuaryDrujba",
                    Address = new Address()
                    {
                        Id = Guid.Parse("ef794fee-f857-4efb-a331-235b5604c40b"),
                        District = "Ruse",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        PostalCodeInfoId = Guid.Parse("5fc7d011-06ea-4bf0-88b4-fab13ccfbd30"),
                        StreetName = "Zahari Stoyanov",
                        lat = (float?)43.848259,
                        lon = (float?)25.980315
                    }
                },
                new Clinic()
                {
                    Id = new Guid("dbdb0654-0b2b-46a7-8262-7d23a5cbbb90"),
                    HospitalizedPetCagedNumber = 20,
                    ClinicName = "SanctuaryTest1",
                    Address = new Address()
                    {
                        Id = Guid.Parse("f4aed029-1a31-4d09-b999-da4d3874ebf0"),
                        District = "Ruse",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        PostalCodeInfoId = Guid.Parse("5fc7d011-06ea-4bf0-88b4-fab13ccfbd30"),
                        StreetName = "Test Street 1",
                        lat = (float?)43.948259,
                        lon = (float?)26.00
                    }
                },
                new Clinic()
                {
                    Id = new Guid("ecfc7af7-bd61-4604-97e5-40cc6f5ca083"),
                    HospitalizedPetCagedNumber = 20,
                    ClinicName = "SanctuaryTest2",
                    Address = new Address()
                    {
                        Id = Guid.Parse("85529606-550b-4ee4-89c5-3ec8c55ac6f7"),
                        District = "Ruse",
                        Country = "Bulgaria",
                        Town = "Ruse",
                        PostalCodeInfoId = Guid.Parse("5fc7d011-06ea-4bf0-88b4-fab13ccfbd30"),
                        StreetName = "Test Street 2",
                        lat = (float?)43.748259,
                        lon = (float?)25.880315
                    }
                },
                new Clinic()
                {
                    Id = new Guid("c370d263-f095-4888-9f0e-5a2fdd49b8f3"),
                    HospitalizedPetCagedNumber = 20,
                    ClinicName = "SofiaCentral",
                    Address = new Address()
                    {
                        Id = Guid.Parse("c04f84c3-1ac8-4e2a-98cb-b00fdd446c78"),
                        District = "Sofia",
                        Country = "Bulgaria",
                        Town = "Sofia",
                        PostalCodeInfoId = Guid.Parse("d3c5cd52-f443-4690-a07a-e29e23357e94"),
                        StreetName = "Knyaz Boris I",
                        lat = (float?)42.6945152,
                        lon = (float?)23.3182411
                    }
                },
                new Clinic()
                {
                    Id = new Guid("092ab3fa-0088-491f-82a8-8cd7a65d408e"),
                    HospitalizedPetCagedNumber = 20,
                    ClinicName = "BurgasCentral",
                    Address = new Address()
                    {
                        Id = Guid.Parse("75f91efc-dcc0-49bd-8026-7eb6eea905b9"),
                        District = "Burgas",
                        Country = "Bulgaria",
                        Town = "Burgas",
                        PostalCodeInfoId = Guid.Parse("0d021468-c037-4ce1-97be-829c9cf87b6b"),
                        StreetName = "Vasil Levski",
                        lat = (float?)42.49863,
                        lon = (float?)27.4693336
                    }
                });

            await context.SaveChangesAsync();
        }

        private async Task SeedBreedsAsync(ApplicationDbContext context)
        {
            await context.Set<Breed>().AddRangeAsync(
                new Breed()
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

            await context.SaveChangesAsync();
        }
    }
}