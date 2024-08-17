using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sanctuary.Data.Models.PicturesTables;

namespace Sanctuary.Data.Seeding.Configurations
{
    internal class PictureStorageConfiguration : IEntityTypeConfiguration<ImageStorage>
    {
        public void Configure(EntityTypeBuilder<ImageStorage> builder)
        {
            builder.Property(x => x.Id).HasColumnType("uniqueidentifier ROWGUIDCOL UNIQUE").IsRequired();

            builder.Property(x => x.Photo).HasColumnType("VARBINARY(MAX) FILESTREAM");
        }
    }
}
