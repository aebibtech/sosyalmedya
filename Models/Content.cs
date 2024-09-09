using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace jsonapisample.Models
{
    [Resource]
    public class Post : BaseEntity
    {
        // Post belongs to a user, can have many likes and comments
        [Attr]
        public string Content { get; set; } = string.Empty;
        [Attr]
        public DateTimeOffset TimeStamp { get; set; }
        [Attr]
        public DateTimeOffset ExpiryTimeStamp { get; set; }
        [HasOne]
        public User User { get; set; }
        [HasMany]
        public List<Like> Likes { get; set; } = [];
        [HasMany]
        public List<Comment> Comments { get; set; } = [];
    }

    [Resource]
    public class Like : BaseEntity
    {
        // A post can be liked, a like belongs to a user
        [Attr]
        public DateTimeOffset TimeStamp { get; set; }
        [HasOne]
        public User User { get; set; }
        [HasOne]
        public Post Post { get; set; }
    }

    [Resource]
    public class Comment : BaseEntity
    {
        // A comment belongs to a post, user
        [Attr]
        public string Content { get; set; } = string.Empty;
        public DateTimeOffset TimeStamp { get; set; }
        [HasOne]
        public User User { get; set; }
        [HasOne]
        public Post Post { get; set; }
    }
}