using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Entities;

namespace TheSecondTestSolution.Infrastructure.EntityConfigurations
{
    internal class TopicEntityConfiguration : BaseEntityConfiguration<TopicEntity>
    {
        public override void Configure(EntityTypeBuilder<TopicEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.OwnsOne(o => o.Score);
            builder.OwnsOne(o => o.Link);

            builder.Property(o => o.Title)
                .HasMaxLength(512);

            builder.Property(o => o.UserName)
                .HasMaxLength(256);

            builder.Property(o => o.Type)
                .HasMaxLength(256);

            builder.HasIndex(o => o.UserName);
            builder.HasIndex(o => o.Type);

            base.Configure(builder);
        }
    }
}
