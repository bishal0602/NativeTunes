using NativeTunes.API.Models.Users;

namespace NativeTunes.API.Models.Podcasts
{
    public class PodcastDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Language { get; set; }
        public string CoverImageUrl { get; set; }
        public string PodcastUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserDto? CreatedBy { get; set; }
    }
}
