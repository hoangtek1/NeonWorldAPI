using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.OrderID);

            builder.Property(x => x.OrderDate).IsRequired();

            builder.Property(x => x.ShipName).IsRequired().HasMaxLength(200);

            builder.Property(x => x.ShipEmail).IsRequired().IsUnicode(false).HasMaxLength(50);

            builder.Property(x => x.ShipAddress).IsRequired().HasMaxLength(300);

            builder.Property(x => x.ShipPhoneNumber).IsRequired().HasColumnType("varchar(10)");

            builder.Property(x => x.ShipNote).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.Status).HasMaxLength(50);

            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserID);

        }
    }
}
