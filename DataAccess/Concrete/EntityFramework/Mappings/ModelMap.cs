using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class ModelMap : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("models").HasKey(x => x.Id);
            
            builder.Property(x => x.Id).HasColumnName("model_id");
            builder.Property(x => x.BrandId).HasColumnName("brand_id");
            builder.Property(x => x.ColorId).HasColumnName("color_id");
            builder.Property(x => x.GearType).HasColumnName("gear_type");
            builder.Property(x => x.DailyPrice).HasColumnName("daily_price");
            builder.Property(x => x.ModelName).HasColumnName("model_name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.IsAirConditioner).HasColumnName("is_air_conditioner").HasDefaultValue(true);
            builder.Property(x => x.IsGps).HasColumnName("is_gps").HasDefaultValue(true);

            builder.HasOne(x => x.Brand);
            builder.HasOne(x => x.Color);

            builder.HasMany(x => x.ModelImages);

            
        }
    }
}