using Microsoft.EntityFrameworkCore;
using NativeTunes.Application.Contracts.Persistence;
using NativeTunes.Domain.PodcastAggregate;
using NativeTunes.Domain.PodcastAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Infrastructure.Persistence.Repositories
{
    public class PodcastRepository : IPodcastRepository
    {
        private readonly NativeTunesDbContext _context;

        public PodcastRepository(NativeTunesDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Podcast>> GetPodcastListAsync()
        {
            return await _context.Podcasts.ToListAsync();
        }
        public async Task<Podcast?> GetPodcastByIdAsync(PodcastId podcastId)
        {
            return await _context.Podcasts.FirstOrDefaultAsync(p => p.Id == podcastId);
        }

        public void AddPodcast(Podcast podcast)
        {
            _context.Podcasts.Add(podcast);
        }
        public void DeletePodcast(Podcast podcast)
        {
            _context.Remove(podcast);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
