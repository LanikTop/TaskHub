using Api.Controllers.Tasks.Request;
using Dal.Repositories.Interfaces;

namespace Api.UseCases.Tasks
{
    public class SetTaskTitleUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public SetTaskTitleUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> ExecuteAsync(Guid id, SetTaskTitleRequest request)
        {
            return await _taskRepository.UpdateTaskTitleAsync(id, request.Title);
        }
    }
}
