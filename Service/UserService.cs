using ProjetDotNet.Interfaces;
using ProjetDotNet.Models.Entities;

namespace ProjetDotNet.Service
{
    public class UserService : IUserService
    {
        private IGenericBLL<User> _userBLL;
        public UserService(IGenericBLL<User> userBll)
        {
            _userBLL = userBll;
        }
        public IEnumerable<User> GetUsers()
        {
            return _userBLL.GetMany();

        }

        public void AddUser(User user)
        {
            _userBLL.Add(user);

        }

        public void UpdateUser(User user)
        {
            _userBLL.Update(user);

        }

        public void DeleteUser(User user)
        {
            _userBLL.Delete(user);

        }
    }
}
