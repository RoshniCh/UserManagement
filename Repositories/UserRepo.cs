using UserManagement.Models.Database;
using UserManagement.Models.Request;
using System.Linq;

namespace UserManagement.Repositories {
    public interface IUserRepo {
        public user Create (CreateUserRequest newUser);
        public user Read (int id);
        public user Update (user updateUser);
        public user Delete (user deleteUser);

    }
    public class UserRepo : IUserRepo {
        private readonly UserManagementDbContext _context;

        public UserRepo(UserManagementDbContext context)
        {
            _context = context;
        }

        public user Create (CreateUserRequest newUser) {
            var userCreated = _context.user.Add ( new user 
            {
                email = newUser.email,
                givenName = newUser.givenName,
                familyName = newUser.familyName,
                created = System.DateTime.Now,
            }
            );
            _context.SaveChanges();
            return userCreated.Entity;
        }

        public user Read (int id) {
            var userInfo = _context.user
                                   .SingleOrDefault(u => u.id == id);
            return userInfo;
        }

        public user Update (user updateUser) {
            var updatedUser = _context.user.Update(updateUser);
            _context.SaveChanges();
            return updatedUser.Entity;
        }
        public user Delete (user deleteUser) {
            var deletedUser = _context.user.Remove(deleteUser);
            _context.SaveChanges();
            return deletedUser.Entity;
        }

    }
}