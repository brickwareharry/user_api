using System.Diagnostics.CodeAnalysis;

namespace UserApi.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
