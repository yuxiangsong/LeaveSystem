using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeaveSystem.Domain.Entities;
using LeaveSystem.Domain.Abstract;

namespace LeaveSystem.Domain.Concrete
{
    public class EFProjectRepository : IProjectRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Project> Projects
        {
            get { return context.Projects; }
        }

        public void SaveProject(Project project)
        {
            if (project.Id == 0)
            {
                context.Projects.Add(project);
            }
            else
            {
                Project dbEntry = context.Projects.Find(project.Id);

                if (dbEntry != null)
                {
                    dbEntry.ProjectDescription = project.ProjectDescription;
                    dbEntry.ProjectTitle = project.ProjectTitle;
                    //dbEntry.TaskItems = project.TaskItems;
                }
            }

            context.SaveChanges();
        }

        public Project DeleteProject(int projectId)
        {
            Project dbEntry = context.Projects.Find(projectId);

            if (dbEntry != null)
            {
                context.Projects.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
