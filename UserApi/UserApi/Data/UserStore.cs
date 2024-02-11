using UserApi.Models.Dto;

namespace UserApi.Data
{
    public static class UserStore
    {
        public static List<UserDto> userList = new List<UserDto>()
            {
                new UserDto{ Id=1, FirstName="FirstName1", LastName="LastName1"},
                new UserDto{ Id=2, FirstName="FirstName2", LastName="LastName2"}
            };
    }
}
