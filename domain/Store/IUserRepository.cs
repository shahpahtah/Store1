using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IUserRepository
    {
        User[] GetAll();
        User GetById(int id);
        User GetByEmail(string email);
        User Create(string Name, string Email, string password, string cellphone="");
        public void Update(User user);

    }
}
