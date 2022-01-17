using DL;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;

namespace BL
{
    public class userBL : IuserBL
    {
        IuserDL iuserDL;
        public userBL(IuserDL iuserDL)
        {
            this.iuserDL = iuserDL;
        }

        public async Task<User> getUser(string email, string password)
        {
            User user;
            user = await iuserDL.getUser(email, password);
            return user;
        }

        public async Task<User> postUser(User user)
        {
            await iuserDL.postUser(user);
            return user;
        }

        public async Task<User> putUser(User user,int id)
        {
            await iuserDL.putUser(user,id);
            return user;
        }
    }
}
