using WebApplication1.Data.Models.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Data.Services
{
    public class UsersService
    {

        private AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserVM user)
        {
            var __user = _context.Users.FirstOrDefault(n => n.userId == user.userId);
            if (__user == null)
            {
                var _user = new User()
                {
                    userName = user.userName,

                    userProfile = user.userProfile,

                    firstName = user.firstName,

                    lastName = user.lastName,

                    password = user.password,

                    salt = user.salt,

                    email = user.email,

                    userId = user.userId
                };
                _context.Users.Add(_user);
                _context.SaveChanges();
            }
       
        }

        public List<User> GetAllUsers() => _context.Users.ToList();

        public User GetUserById(int Id) => _context.Users.FirstOrDefault(n => n.userId == Id);

        public User UpdateUserById(int Id, UserVM user)
        {
            var _user = _context.Users.FirstOrDefault(n => n.userId == Id);

            if(_user !=null)
            {
                _user.firstName = user.firstName;

                _user.userName = user.userName;

                _user.lastName = user.lastName;

                _user.password = user.password;

                _user.userProfile = user.userProfile;

                _user.salt = user.salt;

                _context.SaveChanges();
            }

            return _user;
        }


        public void DeleteUserById(int Id)
        {
            var _user = _context.Users.FirstOrDefault(n => n.userId == Id);
            if(_user !=null)
            {
                _context.Users.Remove(_user);
                _context.SaveChanges();
            }
        }

    }
}
