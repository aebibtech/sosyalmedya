using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System.ComponentModel.DataAnnotations;

namespace jsonapisample.Models
{
    [Resource]
    public class User : BaseEntity
    {
        // User has many accounts
        [Attr]
        [Required]
        public string UserName { get; set; } = null!;
        [Attr]
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        [Attr]
        public string LastName { get; set; } = null!;
        [Attr]
        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;
        [Attr(Capabilities = ~AttrCapabilities.AllowView)]
        public string Password { get; set; } = null!;
        [Attr]
        public bool IsVerified { get; set; }
        [HasMany]
        public List<Account> Accounts { get; set; } = [];
        [HasMany]
        public List<Post> Posts { get; set; } = [];
    }

    [Resource]
    public class Account : BaseEntity
    {
        // Account belongs to a user
        [Attr]
        [Required]
        public string AccountName { get; set; } = string.Empty;
        [HasOne]
        public User User { get; set; } = null!;
    }
}
