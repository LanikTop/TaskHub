using Api.Controllers.Tasks.Response;
using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks
{
    public class CreateTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskResponse> ExecuteAsync(string title, Guid createdByUserId)
        {
            var taskEntity = await _taskRepository.CreateTaskAsync(title, createdByUserId);

            return new TaskResponse
            {
                Id = taskEntity.Id,
                Title = taskEntity.Title,
                CreatedByUserId = taskEntity.CreatedByUserId,
                CreatedUtc = taskEntity.CreatedUtc
            };
        }
    }
}
