using System.Linq;
using DataAccess.Entity;
using DataAccess.Repository;

namespace DataAccess.Service
{
    public class AuthenticationService
    {
        public User LoggedUser { get; private set; }

        public void AuthenticateUser(string username, string password)
        {
            UsersRepository userRepo = new UsersRepository();
            LoggedUser = userRepo.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();
        }
    }
}
