using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(x => x.CartID);

            builder.Property(x => x.CartID).UseIdentityColumn();

            builder.Property(x => x.Quantity).IsRequired().HasDefaultValue(1);

            builder.HasOne(x => x.Product).WithMany(x => x.Carts).HasForeignKey(x => x.ProductID);

            builder.HasOne(x => x.User).WithMany(x => x.Carts).HasForeignKey(x => x.UserID);
        }
    }
}
