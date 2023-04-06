using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("user_id");
            builder.Property(x => x.UserName).HasColumnName("user_name");
            builder.Property(x => x.FirstName).HasColumnName("first_name");
            builder.Property(x => x.LastName).HasColumnName("last_name");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.PasswordHash).HasColumnName("password_hash");
            builder.Property(x => x.PasswordSalt).HasColumnName("password_salt");
            builder.Property(x => x.Status).HasColumnName("status").HasDefaultValue(true);
            
            builder.HasMany(x => x.UserOperationClaims);
        }
    }
}