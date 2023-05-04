using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class CreditCardMap : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            
            builder.ToTable("credit_cards").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CustomerId).HasColumnName("customer_id");
            builder.Property(x => x.CardHolderName).HasColumnName("card_holder_name");
            builder.Property(x => x.CardNumber).HasColumnName("card_number");
            builder.Property(x => x.State).HasColumnName("state");
            builder.Property(x => x.CreatedDate).HasColumnName("created_date").HasDefaultValue( DateTime.UtcNow);
        }
    }
}