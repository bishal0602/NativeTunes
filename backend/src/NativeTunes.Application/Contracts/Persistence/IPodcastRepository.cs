using NativeTunes.Domain.PodcastAggregate;
using NativeTunes.Domain.PodcastAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Contracts.Persistence
{
    public interface IPodcastRepository
    {
        void AddPodcast(Podcast podcast);
        void DeletePodcast(Podcast podcast);
        Task<Podcast?> GetPodcastByIdAsync(PodcastId podcastId);
        Task<IEnumerable<Podcast>> GetPodcastListAsync();
        Task<bool> SaveChangesAsync();
    }
}
