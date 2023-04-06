using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserOperationClaimMap : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("user_operation_claims").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("user_operation_claim_id");
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.OperationClaimId).HasColumnName("operation_claim_id");

            builder.HasOne(x => x.User);
            builder.HasOne(x => x.OperationClaim);
        }
    }
}