using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("blogs").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("blog_id");
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.Title).HasColumnName("title");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Date).HasColumnName("date").HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.ImageUrl).HasColumnName("image_url");

        }
    }
}