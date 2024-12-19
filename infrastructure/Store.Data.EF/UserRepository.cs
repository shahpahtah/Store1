using Store.Data.EF;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Memory
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        public Dictionary<string, string> Errors = new Dictionary<string, string>();
        private readonly DbContextFactory dbContextFactory;
        public UserRepository(DbContextFactory dbcontextfactory)
        {
            this.dbContextFactory = dbcontextfactory;
        }
        public User Create(string Name, string Email, string password, string cellphone = "")
        {
            var dbContext = dbContextFactory.Create(typeof(UserRepository));

            var dto = User.DtoFactory.Create(Name, Email, password, cellphone, null);
            dbContext.Users.Add(dto);
            dbContext.SaveChanges();
            return User.Mapper.Map(dto);
        }

        public User[] GetAll()
        {
            var dbcontext = dbContextFactory.Create(typeof(UserRepository));
            try
            {
                var user = dbcontext.Users.Select(User.Mapper.Map).ToArray();
                return user;
            }
            catch
            {
                return new User[0];
            }

        }

        public User GetById(int id)
        {
            var dbcontext = dbContextFactory.Create(typeof(UserRepository));
            var dto = dbcontext.Users.Single(user => user.Id == id);
            return User.Mapper.Map(dto);
        }

        public User GetByEmail(string email)
        {

            var dbcontext = dbContextFactory.Create(typeof(UserRepository));
            var dto = dbcontext.Users.Single(user => user.Email == email);
            return User.Mapper.Map(dto);
        }
        public void Update(User user)
        {
            var dbcontext = dbContextFactory.Create(typeof(UserRepository));
            dbcontext.SaveChanges();
        }
    }
}