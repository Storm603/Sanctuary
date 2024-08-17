using Sanctuary.Data.Models.LocationTables;

namespace Sanctuary.Data.Seeding
{
    internal class PostalCodesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            await dbContext.Set<PostalCodesCoordinates>().AddRangeAsync(new PostalCodesCoordinates()
            {
                Id = new Guid("44509afe-295a-47cd-8d70-6c2adc71e65f"),
                PostalCode = "7002",
                lat = 43.8591784686576,
                lng = 25.964857058055326,
            }, new PostalCodesCoordinates()
            {
                Id = new Guid("b8fc3d41-f2ee-413d-a3de-c5dca6a81f90"),
                PostalCode = "7001",
                lat = 43.83136314105843,
                lng = 25.952169342932194,
            }, new PostalCodesCoordinates()
            {
                Id = new Guid("5fc7d011-06ea-4bf0-88b4-fab13ccfbd30"),
                PostalCode = "7005",
                lat = 43.85265514176504,
                lng = 25.986182862216683,
            }, new PostalCodesCoordinates()
            {
                Id = new Guid("d3c5cd52-f443-4690-a07a-e29e23357e94"),
                PostalCode = "1000",
                lat = 42.695116040439785,
                lng = 23.325710712880685,
            }, new PostalCodesCoordinates()
            {
                Id = new Guid("0d021468-c037-4ce1-97be-829c9cf87b6b"),
                PostalCode = "8000",
                lat = 42.48660611346847,
                lng = 27.3940244292835,
            }, new PostalCodesCoordinates()
            {
                Id = new Guid("25ed1503-0e8a-4ba8-9897-2161d00f1272"),
                PostalCode = "7003",
                lat = 43.86714157413165,
                lng = 25.99008778376263,
            }, new PostalCodesCoordinates()
            {
                Id = new Guid("56d71ae8-260f-401b-a881-e17dff340582"),
                PostalCode = "7010",
                lat = 43.77887472659794,
                lng = 25.907197226451803,
            }, new PostalCodesCoordinates()
            {
                Id = new Guid("861e8a04-659c-48fb-883f-f4791df50d06"),
                PostalCode = "7009",
                lat = 43.87545078072681,
                lng = 26.01226373975237,
            }, new PostalCodesCoordinates()
            {
                Id = new Guid("ccf3a2a9-c45d-4973-be56-41ee074f4e3a"),
                PostalCode = "7012",
                lat = 43.839399504754326,
                lng = 25.955211729994247,
            }, new PostalCodesCoordinates()
            {
                Id = new Guid("e1b05bcf-cf22-4552-8cd6-5977f730cc81"),
                PostalCode = "1504",
                lat = 42.69457404850715,
                lng = 23.340769242128196,
            });
        }
    }
}
