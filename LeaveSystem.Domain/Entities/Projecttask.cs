using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LeaveSystem.Domain.Entities
{
    public class Projecttask
    {
        [Key]
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        [Display(Name="Task name")]
        public string TaskName { get; set; }

        public virtual Project Project { get; set; }
    }
}
