using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Configurations
{
    public class UserCofiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.UserID);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Email).IsRequired().IsUnicode(false).HasMaxLength(50);

            builder.Property(x => x.Phone).IsRequired().HasColumnType("varchar(10)");

            builder.Property(x => x.Password).IsRequired().HasMaxLength(500);

            builder.Property(x => x.Dob).IsRequired();

        }
    }
}
