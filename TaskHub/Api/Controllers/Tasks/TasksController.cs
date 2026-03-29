using Api.Attributes;
using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;
using Api.Services.Tasks.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tasks;

[ApiController]
[Route("api/[controller]")]
[StudentInfoHeaders]
[ResponseTimeHeader]
public sealed class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponse>> CreateTaskAsync(
        [FromBody] CreateTaskRequest request,
        CancellationToken cancellationToken)
    {
        var task = await _taskService.CreateTaskAsync(request);
        return Ok(task);
    }

    [HttpGet]
    public async Task<ActionResult<TaskResponse>> GetAllTasksAsync(CancellationToken cancellationToken)
    {
        var tasks = await _taskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskResponse>> GetTaskByIdAsync([FromRouteTaskId] Guid id, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var taskResponse = await _taskService.GetTaskByIdAsync(id);

        if (taskResponse is null)
            return NotFound();

        return Ok(taskResponse);
    }

    [HttpPut("{id}/title")]
    public async Task<IActionResult> SetTaskTitleAsync(
        [FromRouteTaskId] Guid id,
        [FromBody] SetTaskTitleRequest? request,
        CancellationToken cancellationToken)
    {
        var taskResponse = await _taskService.SetTaskTitleAsync(id, request);
        if (!taskResponse)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTaskByIdAsync([FromRouteTaskId] Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _taskService.DeleteTaskByIdAsync(id);
        if (deleted == false)
            return NotFound();

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAllTasksAsync(CancellationToken cancellationToken)
    {
        await _taskService.DeleteAllTasksAsync();
        return NoContent();
    }
}