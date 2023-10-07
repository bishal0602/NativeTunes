using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NativeTunes.Domain.ForumAggregate;
using NativeTunes.Domain.ForumAggregate.ValueObjects;

namespace NativeTunes.Infrastructure.Configurations
{
    public class ForumConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasConversion(id => id.Value, value => PostId.Create(value));
        }
    }
}
