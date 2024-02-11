using System.Diagnostics.CodeAnalysis;

namespace UserApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}
