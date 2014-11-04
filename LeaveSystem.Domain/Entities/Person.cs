using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveSystem.Domain.Entities
{
    public class Person
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public Role Role { set; get; }
    }

    public enum Role{
        Admin,
        User,
        Guest
    }
}
