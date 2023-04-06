using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class TestimonialMap : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
             builder.ToTable("testimonials").HasKey(x => x.Id);
             builder.Property(x => x.Id).HasColumnName("testimonail_id");
             builder.Property(x => x.CustomerId).HasColumnName("customer_id");
             builder.Property(x => x.Comment).HasColumnName("comment");
             builder.Property(x => x.Status).HasColumnName("status").HasDefaultValue(true);
        }
    }
}