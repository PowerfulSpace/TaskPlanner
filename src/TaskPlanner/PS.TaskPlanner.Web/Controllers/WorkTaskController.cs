using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.CreateWorkTask;
using PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.DeleteWorkTask;
using PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.UpdateWorkTask;
using PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetAllWorkTasks;
using PS.TaskPlanner.Web.Models;

namespace PS.TaskPlanner.Web.Controllers
{
    public class WorkTaskController : Controller
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public WorkTaskController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // 1. Просмотр всех задач
        public async Task<IActionResult> Index()
        {
            var tasks = await _mediator.Send(new GetAllWorkTasksQuery());
            var viewModel = _mapper.Map<List<WorkTaskViewModel>>(tasks);

            return View(viewModel);
        }

        // 2. Просмотр задачи по ID
        public async Task<IActionResult> Details(Guid id)
        {
            var task = await _mediator.Send(new GetWorkTaskByIdQuery { Id = id });
            if (task == null) return NotFound();

            var viewModel = _mapper.Map<WorkTaskViewModel>(task);
            return View(viewModel);
        }

        // 3. Создание задачи (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View(new WorkTaskViewModel());
        }

        // 4. Создание задачи (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkTaskViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var command = _mapper.Map<CreateWorkTaskCommand>(model);
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        // 5. Редактирование задачи (GET)
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var task = await _mediator.Send(new GetWorkTaskByIdQuery { Id = id });
            if (task == null) return NotFound();

            var viewModel = _mapper.Map<WorkTaskViewModel>(task);
            return View(viewModel);
        }

        // 6. Редактирование задачи (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, WorkTaskViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            var command = _mapper.Map<UpdateWorkTaskCommand>(model);
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        // 7. Удаление задачи (GET)
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var task = await _mediator.Send(new GetWorkTaskByIdQuery { Id = id });
            if (task == null) return NotFound();

            var viewModel = _mapper.Map<WorkTaskViewModel>(task);
            return View(viewModel);
        }

        // 8. Удаление задачи (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _mediator.Send(new DeleteWorkTaskCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
