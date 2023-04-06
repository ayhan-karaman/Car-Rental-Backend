using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("customer_id");
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.CustomerNumber).HasColumnName("customer_number");
        }
    }
}