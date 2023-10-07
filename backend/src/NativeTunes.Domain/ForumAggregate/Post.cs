using NativeTunes.Domain.Common;
using NativeTunes.Domain.ForumAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Domain.ForumAggregate
{
    public class Post : AuditableAggregate<PostId>
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public int Likes { get; set; }
        private Post() { }

        private Post(PostId id, string title, string? description, int likes)
        {
            Id = id;
            Title = title;
            Description = description;
            Likes = likes;
        }
        public static Post Create(PostId id, string title, string? description, int likes) => new(id, title, description, likes);
        public static Post CreateNew(string title, string? description) => new(PostId.CreateNew(), title, description, 0);
    }
}
