using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class RentalMap : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.ToTable("rentals").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CustomerId).HasColumnName("customer_id");
            builder.Property(x => x.ModelId).HasColumnName("model_id");
            builder.Property(x => x.TotalRentDay).HasColumnName("total_rent_day");
            builder.Property(x => x.RentStartDate).HasColumnName("rent_start_date");
            builder.Property(x => x.RentEndDate).HasColumnName("rent_end_date");
            builder.Property(x => x.ReturnDate).HasColumnName("return_date");
        }
    }
}