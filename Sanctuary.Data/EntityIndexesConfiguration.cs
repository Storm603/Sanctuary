using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Common.Models;

namespace Sanctuary.Data
{
    internal static class EntityIndexesConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            var deletableEntityTypes = builder.Model.GetEntityTypes().Where(et => et.ClrType != null &&
                typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));

            foreach (var deletableEntityType in deletableEntityTypes)
            {
                builder.Entity(deletableEntityType.ClrType).HasIndex(nameof(IDeletableEntity.IsDeleted));
            }
        }
    }
}
