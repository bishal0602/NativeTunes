namespace NativeTunes.API.Models.Podcasts
{
    public class PodcastForCreationDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public IFormFile AudioFile { get; set; }
        public IFormFile CoverImage { get; set; }
        public string Language { get; set; }
    }
}
