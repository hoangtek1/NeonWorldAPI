using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Configurations
{
    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");

            builder.HasKey(x => x.SlideID);

            builder.Property(x => x.SlideID).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);

            builder.Property(x => x.Url).IsRequired().HasMaxLength(300);

            builder.Property(x => x.Image).IsRequired().HasMaxLength(300);
        }
    }
}
