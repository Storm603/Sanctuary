using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Sanctuary.Data.Seeding
{
    internal class PhotoSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            await PictureSeeding(dbContext);
        }

        private async Task PictureSeeding(ApplicationDbContext context)
        {
            // UserId = BaseUserId
            string[] tSqlStatements = new[] {
                "INSERT INTO [Images] (Id, PhotoName, Photo, IsProfilePicture, CreatedOn, ClinicId) VALUES( '{0}', '{1}',(SELECT * FROM OPENROWSET(BULK N'{2}' ,SINGLE_BLOB) as ex), 'true', SYSDATETIME(), '{3}')",
                "INSERT INTO [Images] (Id, PhotoName, Photo, IsProfilePicture, CreatedOn, UserId) VALUES( '{0}', '{1}',(SELECT * FROM OPENROWSET(BULK N'{2}' ,SINGLE_BLOB) as ex), 'true', SYSDATETIME(), '{3}')",
                "INSERT INTO [Images] (Id, PhotoName, Photo, IsProfilePicture, CreatedOn, PetId) VALUES( '{0}', '{1}',(SELECT * FROM OPENROWSET(BULK N'{2}' ,SINGLE_BLOB) as ex), 'true', SYSDATETIME(), '{3}')"
            };

            var clinicIds = context.Clinics.Select(x => x.Id.ToString()).ToList();
            var userIds = context.BaseUser.Where(x => x.Client != null).Select(x => x.Id).ToList();
            var vetIds = context.BaseUser.Where(x => x.Veterinary != null).Select(x => x.Id).ToList();
            var petIds = context.Pets.Select(x => x.Id.ToString()).ToList();

            // item1 - dir path, item2 - id's
            List<Tuple<string, List<string>>> seedInformation = new List<Tuple<string, List<string>>>()
            {
                new Tuple<string, List<string>>(@"C:\Users\Kristiyan\Documents\SanctuaryPhotos\Clinics\", clinicIds),
                new Tuple<string, List<string>>(@"C:\Users\Kristiyan\Documents\SanctuaryPhotos\Users\", userIds),
                new Tuple<string, List<string>>(@"C:\Users\Kristiyan\Documents\SanctuaryPhotos\Veterinarian\", vetIds),
                new Tuple<string, List<string>>(@"C:\Users\Kristiyan\Documents\SanctuaryPhotos\Pets\", petIds),
            };

            await using (await context.Database.BeginTransactionAsync())
            {
                using (SqlConnection conn = new SqlConnection(context.Database.GetConnectionString()))
                {
                    await conn.OpenAsync();
                    try
                    {
                        for (int i = 0; i < seedInformation.Count; i++)
                        {
                            string tSql = String.Empty;

                            var path = Directory.GetFiles(seedInformation[i].Item1);

                            if (path.Length < seedInformation[i].Item2.Count)
                            {
                                throw new Exception($"Inconsistency found in Seeding Class {nameof(PhotoSeeder)}, the number of pictures found in directory {seedInformation[i].Item1} is lower than the {seedInformation[i].Item2.GetType().Name}");
                            }

                            if (i == 0)
                            {
                                tSql = tSqlStatements[0];
                            }
                            else if (i == seedInformation.Count - 1)
                            {
                                tSql = tSqlStatements[2];
                            }
                            else
                            {
                                tSql = tSqlStatements[1];
                            }

                            for (int j = 0; j < seedInformation[i].Item2.Count; j++)
                            {
                                var regexFileNameExtraction = Regex.Match(path[j], @"(?:[^\\\/](?!(\\|\/)))+$");

                                if (regexFileNameExtraction.Success)
                                {
                                    SqlCommand command = new SqlCommand(string.Format(tSql, Guid.NewGuid(), regexFileNameExtraction.Value, path[j], seedInformation[i].Item2[j]), conn);
                                    await command.ExecuteNonQueryAsync();
                                }
                            }
                        }

                        await context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
            }
        }
    }
}


