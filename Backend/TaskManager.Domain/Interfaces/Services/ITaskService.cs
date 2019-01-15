﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Services
{
    public interface ITaskService
    {
        TaskEntity GetById(int id);
        List<TaskEntity> GetAllByBoardId(int boardId);
        Task<TaskEntity> Add(TaskEntity task);
        Task<TaskEntity> Update(TaskEntity task);
    }
}
