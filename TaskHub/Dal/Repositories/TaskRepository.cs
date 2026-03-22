using Dal.Context;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepository(TaskDbContext context)
        {
            _dbContext = context;
        }

        public async Task<TaskEntity> CreateTaskAsync(string title, Guid createdByUserId)
        {
            var task = new TaskEntity
            {
                Id = Guid.NewGuid(),
                Title = title,
                CreatedByUserId = createdByUserId,
                CreatedUtc = DateTimeOffset.UtcNow
            };

            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<int> DeleteAllTasksAsync()
        {
            var count = await _dbContext.Tasks.CountAsync();
            _dbContext.Tasks.RemoveRange(_dbContext.Tasks);
            await _dbContext.SaveChangesAsync();

            return count;
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
                return false;

            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<TaskEntity>> GetAllTasksAsync()
        {
            return await _dbContext.Tasks
                .OrderByDescending(t => t.CreatedUtc)
                .ToListAsync();
        }

        public async Task<TaskEntity?> GetTaskByIdAsync(Guid id)
        {
            return await _dbContext.Tasks
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> UpdateTaskTitleAsync(Guid id, string title)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null)
                return false;

            task.Title = title;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
