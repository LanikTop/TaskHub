using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks
{
    public class DeleteTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> ExecuteAsync(Guid id)
        {
            return await _taskRepository.DeleteTaskAsync(id);
        }
    }
}
