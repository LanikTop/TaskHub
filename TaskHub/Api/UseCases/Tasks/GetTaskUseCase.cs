using Api.Controllers.Tasks.Response;
using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks
{
    public class GetTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskResponse?> ExecuteAsync(Guid id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);

            if (task == null)
                return null;

            return new TaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                CreatedByUserId = task.CreatedByUserId,
                CreatedUtc = task.CreatedUtc
            };
        }
    }
}
