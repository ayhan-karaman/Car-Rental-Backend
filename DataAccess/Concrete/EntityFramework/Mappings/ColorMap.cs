using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class ColorMap : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("colors").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("color_id");
            builder.Property(x => x.Name).HasColumnName("color_name");
            builder.Property(x => x.Description).HasColumnName("description");
            
            builder.HasMany(x => x.Models);
        }
        
    }
}