using System.Threading.Tasks;
using Entities;

namespace BL
{
    public interface IuserBL
    {
        Task<User> getUser(string email, string password);
        Task<User> postUser(User user);
        Task<User> putUser(User user,int id);
    }
}