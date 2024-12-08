using ProjetDotNet.Models.Entities;

namespace ProjetDotNet.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void UpdateUser(User update);
        void DeleteUser(User delete);
        IEnumerable<User> GetUsers();
    }
}
