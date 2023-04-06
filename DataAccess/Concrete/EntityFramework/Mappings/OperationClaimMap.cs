using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class OperationClaimMap : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("operation_claims").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("operation_claim_id");
            builder.Property(x => x.Name).HasColumnName("operation_claim_name");
            
            builder.HasMany(x => x.UserOperationClaims);
        }
    }
}