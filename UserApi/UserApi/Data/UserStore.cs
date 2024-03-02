using UserApi.Models.Dto;

namespace UserApi.Data
{
    public static class UserStore
    {
        public static List<UserDto> userList = new List<UserDto>()
            {
                new UserDto{ Id=1, FirstName="FirstName1", LastName="LastName1", Email="email1@email.com"},
                new UserDto{ Id=2, FirstName="FirstName2", LastName="LastName2", Email="email2@email.com"}
            };
    }
}
