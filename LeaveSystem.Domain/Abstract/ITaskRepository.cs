﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveSystem.Domain.Entities;

namespace LeaveSystem.Domain.Abstract
{
    public interface ITaskRepository
    {
        IEnumerable<Projecttask> Tasks { get; }

        void SaveTask(Projecttask task);

        Projecttask DeleteTask(int taskId);
    }
}
