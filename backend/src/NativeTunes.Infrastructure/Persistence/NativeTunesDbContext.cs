using Microsoft.EntityFrameworkCore;
using NativeTunes.Domain.Common.Interfaces;
using NativeTunes.Domain.MarketplaceAggregate;
using NativeTunes.Domain.PodcastAggregate;
using NativeTunes.Domain.UserAggregate;
using NativeTunes.Infrastructure.Configurations;
using NativeTunes.Infrastructure.Interceptors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Infrastructure.Persistence
{
    public class NativeTunesDbContext : DbContext
    {
        private readonly PublishDomainEventInterceptor _publishDomainEventInterceptor;
        private readonly AuditableInterceptor _auditableInterceptor;
        public NativeTunesDbContext(DbContextOptions<NativeTunesDbContext> options, PublishDomainEventInterceptor publishDomainEventInterceptor, AuditableInterceptor auditableInterceptor) : base(options)
        {
            _publishDomainEventInterceptor = publishDomainEventInterceptor;
            _auditableInterceptor = auditableInterceptor;
        }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventInterceptor, _auditableInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(NativeTunesDbContext).Assembly);
            AuditableConfiguration.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
