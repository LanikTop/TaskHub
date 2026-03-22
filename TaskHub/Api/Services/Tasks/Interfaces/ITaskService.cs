using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;

namespace Api.Services.Tasks.Interfaces
{
    public interface ITaskService
    {
        Task<TaskResponse> CreateTaskAsync(CreateTaskRequest request);
        Task<List<TaskResponse>> GetAllTasksAsync();
        Task<TaskResponse?> GetTaskByIdAsync(Guid id);
        Task<bool> SetTaskTitleAsync(Guid id, SetTaskTitleRequest request);
        Task<bool> DeleteTaskByIdAsync(Guid id);
        Task<int> DeleteAllTasksAsync();
    }
}
