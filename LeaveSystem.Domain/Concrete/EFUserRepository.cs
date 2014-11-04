using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Abstract;
using LeaveSystem.Domain.Infrastructure;

namespace LeaveSystem.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public void SaveUser(User user)
        {
            if (user.UserID == 0)
            {
                user.Password = Helpers.SHA1Encode(user.Password);
                user.PasswordCompare = Helpers.SHA1Encode(user.PasswordCompare);

                
                context.Users.Add(user);
            }
            else
            {
                User dbEntry = context.Users.Find(user.UserID);

                if (dbEntry != null)
                {
                    dbEntry.Username = user.Username;
                    dbEntry.Password = user.Password;
                    dbEntry.Email = user.Email;
                    dbEntry.DateOfBirth = user.DateOfBirth;
                    dbEntry.MobileNumber = user.MobileNumber;
                }
            }

            context.SaveChanges();
        }//SaveUser

        public User DeleteUser(int userID)
        {
            User dbEntry = context.Users.Find(userID);

            if (dbEntry != null)
            {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }//DeleteUser

        
    }
}
