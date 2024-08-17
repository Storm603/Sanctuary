using Sanctuary.Data.Common.Models;

namespace Sanctuary.Data.Models.Configurable
{
    public class Setting : BaseDeletableModel<int>
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
}
