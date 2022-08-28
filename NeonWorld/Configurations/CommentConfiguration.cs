using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NeonWorld.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(x => x.CommentID);

            builder.Property(x => x.CommentID).UseIdentityColumn();

            builder.Property(x => x.UserComment).IsRequired().HasMaxLength(1000);
        }
    }
}
