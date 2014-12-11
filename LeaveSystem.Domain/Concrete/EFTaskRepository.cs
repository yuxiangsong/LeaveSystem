using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Abstract;

namespace LeaveSystem.Domain.Concrete
{
    public class EFTaskRepository:ITaskRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Projecttask> Tasks
        {
            get { return context.Tasks; }
        }

        public void SaveTask(Projecttask task)
        {
            if (task.TaskId == 0)
            {
                context.Tasks.Add(task);
            }
            else
            {
                Projecttask dbEntry = context.Tasks.Find(task.TaskId);

                if (dbEntry != null)
                {
                    dbEntry.ProjectId = task.ProjectId;
                    dbEntry.TaskName = task.TaskName;
                }
            }

            context.SaveChanges();
        }

        public Projecttask DeleteTask(int taskId)
        {
            Projecttask dbEntry = context.Tasks.Find(taskId);

            if (dbEntry != null)
            {
                context.Tasks.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
