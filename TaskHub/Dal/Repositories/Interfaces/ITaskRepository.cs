using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskEntity> CreateTaskAsync(string title, Guid createdByUserId);
        Task<List<TaskEntity>> GetAllTasksAsync();
        Task<TaskEntity?> GetTaskByIdAsync(Guid id);
        Task<bool> UpdateTaskTitleAsync(Guid id, string title);
        Task<bool> DeleteTaskAsync(Guid id);
        Task<int> DeleteAllTasksAsync();
    }
}
