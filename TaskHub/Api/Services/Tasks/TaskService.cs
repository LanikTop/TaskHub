using Api.Controllers.Tasks.Response;
using Api.UseCases.Tasks;
using Api.Services.Tasks.Interfaces;
using Api.Controllers.Tasks.Request;

namespace Api.Services.Tasks
{
    public class TaskService : ITaskService
    {

        private readonly CreateTaskUseCase _createTaskUseCase;
        private readonly GetTasksUseCase _getTasksUseCase;
        private readonly GetTaskUseCase _getTaskUseCase;
        private readonly SetTaskTitleUseCase _setTaskTitleUseCase;
        private readonly DeleteTaskUseCase _deleteTaskUseCase;
        private readonly DeleteTasksUseCase _deleteTasksUseCase;

        public TaskService(
        CreateTaskUseCase createTaskUseCase,
        GetTasksUseCase getTasksUseCase,
        GetTaskUseCase getTaskUseCase,
        SetTaskTitleUseCase setTaskTitleUseCase,
        DeleteTaskUseCase deleteTaskUseCase,
        DeleteTasksUseCase deleteTasksUseCase)
        {
            _createTaskUseCase = createTaskUseCase;
            _getTasksUseCase = getTasksUseCase;
            _getTaskUseCase = getTaskUseCase;
            _setTaskTitleUseCase = setTaskTitleUseCase;
            _deleteTaskUseCase = deleteTaskUseCase;
            _deleteTasksUseCase = deleteTasksUseCase;
        }

        public async Task<TaskResponse> CreateTaskAsync(CreateTaskRequest request)
        {
            return await _createTaskUseCase.ExecuteAsync(request.Title, request.CreatedByUserId);
        }

        public async Task<int> DeleteAllTasksAsync()
        {
            return await _deleteTasksUseCase.ExecuteAsync();
        }

        public async Task<bool> DeleteTaskByIdAsync(Guid id)
        {
            return await _deleteTaskUseCase.ExecuteAsync(id);
        }

        public async Task<List<TaskResponse>> GetAllTasksAsync()
        {
            return await _getTasksUseCase.ExecuteAsync();
        }

        public async Task<TaskResponse?> GetTaskByIdAsync(Guid id)
        {
            return await _getTaskUseCase.ExecuteAsync(id);
        }

        public async Task<bool> SetTaskTitleAsync(Guid id, SetTaskTitleRequest request)
        {
            return await _setTaskTitleUseCase.ExecuteAsync(id, request);
        }
    }
}
