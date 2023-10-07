using NativeTunes.API.Models.Users;

namespace NativeTunes.API.Models.Forum
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserDto? CreatedBy { get; set; }
    }
}
