using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks
{
    public class DeleteTasksUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTasksUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<int> ExecuteAsync()
        {
            return await _taskRepository.DeleteAllTasksAsync();
        }
    }
}
