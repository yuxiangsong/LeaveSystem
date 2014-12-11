using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveSystem.Domain.Entities;

namespace LeaveSystem.Domain.Abstract
{
    public interface IProjectRepository
    {
        IEnumerable<Project> Projects { get; }

        void SaveProject (Project project);

        Project DeleteProject(int projectId);
    }
}
