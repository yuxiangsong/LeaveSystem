using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeaveSystem.Domain.Entities;

namespace LeaveSystem.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }

        void SaveUser(User user);

        User DeleteUser(int userID);

        //bool IsValidUser(string username, string password);
    }
}
