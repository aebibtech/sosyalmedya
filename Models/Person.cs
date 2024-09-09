using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace jsonapisample.Models
{
    [Resource]
    public class Person : Identifiable<int>
    {
        [Attr]
        public string Name { get; set; } = null!;
    }
}
