using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.CategoryID);

            builder.Property(x => x.CategoryID).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Icon).IsRequired().HasMaxLength(200);

        }
    }
}
