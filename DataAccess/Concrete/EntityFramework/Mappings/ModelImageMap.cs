using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class ModelImageMap : IEntityTypeConfiguration<ModelImage>
    {
        public void Configure(EntityTypeBuilder<ModelImage> builder)
        {
            builder.ToTable("model_images").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("model_image_id");
            builder.Property(x => x.ModelId).HasColumnName("model_id");
            builder.Property(x => x.ImageUrl).HasColumnName("image_url");
            builder.Property(x => x.UploadDate).HasColumnName("upload_date");

            builder.HasOne(x => x.Model);
        }
    }
}