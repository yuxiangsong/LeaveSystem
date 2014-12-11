using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LeaveSystem.Domain.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectTitle { get; set; }

        public virtual ICollection<Projecttask> Projecttasks { get; set; }
    }
}
