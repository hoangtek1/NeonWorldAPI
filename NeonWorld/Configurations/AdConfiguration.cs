using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Configurations
{
    public class AdConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.ToTable("Ads");

            builder.HasKey(x => x.AdID);

            builder.Property(x => x.AdID).UseIdentityColumn();

            builder.Property(x => x.Link).IsRequired().HasMaxLength(300);

            builder.Property(x => x.Image).IsRequired().HasMaxLength(300);
        }
    }
}
