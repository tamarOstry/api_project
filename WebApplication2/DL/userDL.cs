using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class userDL : IuserDL
    {
        vaichleContext vaichleContext;

        public userDL(vaichleContext vaichleContext)
        {
            this.vaichleContext = vaichleContext;
        }

        public async Task<User> getUser(string email, string password)
        {
            var userToGet = await vaichleContext.Users.Where(u =>
             u.Email == email && u.Password == password
            ).FirstOrDefaultAsync();  
            if (userToGet == null)
                return null;
            return userToGet;
        }

        public async Task<User> postUser(User user)
        {
            using(var context=new vaichleContext())
            { 
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> putUser(User user,int id)
        {  
            var userToChange = await vaichleContext.Users.FindAsync(id);
            user.UserId = id;
            vaichleContext.Entry(userToChange).CurrentValues.SetValues(user);
            await vaichleContext.SaveChangesAsync();
            return userToChange;
        }

     }
}
