namespace Sanctuary.Data.Models.LocationTables
{
    public class PostalCodesCoordinates
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; } = null!;
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
