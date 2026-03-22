using Api.Controllers.Tasks.Response;
using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks
{
    public class GetTasksUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public GetTasksUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskResponse>> ExecuteAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();

            return tasks.Select(t => new TaskResponse
            {
                Id = t.Id,
                Title = t.Title,
                CreatedByUserId = t.CreatedByUserId,
                CreatedUtc = t.CreatedUtc
            }).ToList();
        }
    }
}
