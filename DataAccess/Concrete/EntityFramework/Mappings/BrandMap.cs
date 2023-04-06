using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("brands").HasKey(c => c.Id);
            builder.Property(x => x.Id).HasColumnName("brand_id");
            builder.Property(x => x.Name).HasColumnName("brand_name");
            builder.Property(x => x.Description).HasColumnName("description");

            builder.HasMany(x => x.Models);

        }
    }
}