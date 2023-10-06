using NativeTunes.Domain.Common;
using NativeTunes.Domain.PodcastAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Domain.PodcastAggregate
{
    public class Podcast : AuditableAggregate<PodcastId>
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public string Language { get; private set; }
        public string CoverImageUrl { get; private set; }
        public string PodcastUrl { get; private set; }
        private Podcast() { } // ef core
        private Podcast(PodcastId id, string title, string description, string language, string coverImageUrl, string podcastUrl)
        {
            Id = id;
            Title = title;
            Description = description;
            Language = language;
            CoverImageUrl = coverImageUrl;
            PodcastUrl = podcastUrl;
        }
        public static Podcast Create(PodcastId id, string title, string description, string language, string coverImageUrl, string podcastUrl) => new(id, title, description, language, coverImageUrl, podcastUrl);
        public static Podcast CreateNew(string title, string description, string language, string coverImageUrl, string podcastUrl) => new(PodcastId.CreateNew(), title, description, language, coverImageUrl, podcastUrl);

    }
}
