using Store.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class User
    {

        UserDto dto;
        public int Id => dto.Id;
        public string Name
        {
            get => dto.Name; set
            {
                dto.Name = value;
            }
        }
        public string Email { get => dto.Email;set { dto.Email = value; } }
        public string Password { get=>dto.Password;set { dto.Password = value; } }
        public string? CellPhone { get=>dto.CellPhone; set {dto.CellPhone=value; } }
        public Dictionary<string, string>? Errors 
        {
            get {  return dto.Errors; }
            set { dto.Errors = value; }
        }
        internal User(UserDto dto)
        {
            this.dto = dto;
        }
        public static class DtoFactory
        {
            public static UserDto Create(string name, string email, string password,  string? cellphone, Dictionary<string,string>? errors)
            {
                return new UserDto
                {
                    Name = name, Email = email, Password = password, CellPhone = cellphone, Errors = errors
                };
            }
        }
        public static class Mapper
        {
            public static User Map(UserDto dto) => new User(dto);
            public static UserDto Map(User user) => user.dto;
        }

    }
}
