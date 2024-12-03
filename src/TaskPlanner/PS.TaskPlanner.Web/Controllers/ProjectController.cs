using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.TaskPlanner.Application.CQRS.Projects.Commands.CreateProject;
using PS.TaskPlanner.Application.CQRS.Projects.Commands.DeleteProject;
using PS.TaskPlanner.Application.CQRS.Projects.Commands.UpdateProject;
using PS.TaskPlanner.Application.CQRS.Projects.Queries.GetAllProjects;
using PS.TaskPlanner.Application.CQRS.Projects.Queries.GetProjectById;
using PS.TaskPlanner.Web.Models;

namespace PS.TaskPlanner.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public ProjectController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // 1. Просмотр всех проектов
        public async Task<IActionResult> Index()
        {
            var query = new GetAllProjectsQuery();

            var projects = await _mediator.Send(query);
            var viewModel = _mapper.Map<List<ProjectViewModel>>(projects);

            return View(viewModel);
        }

        // 2. Просмотр проекта по ID
        public async Task<IActionResult> Details(Guid id)
        {
            var query = new GetProjectByIdQuery { Id = id };

            var project = await _mediator.Send(new GetProjectByIdQuery { Id = id });
            if (project == null) return NotFound();

            var viewModel = _mapper.Map<ProjectViewModel>(project);
            return View(viewModel);
        }

        // 3. Создание проекта (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ProjectViewModel());
        }

        // 4. Создание проекта (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var command = _mapper.Map<CreateProjectCommand>(model);
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        // 5. Редактирование проекта (GET)
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var query = new GetProjectByIdQuery { Id = id };

            var project = await _mediator.Send(query);
            if (project == null) return NotFound();

            var viewModel = _mapper.Map<ProjectViewModel>(project);
            return View(viewModel);
        }

        // 6. Редактирование проекта (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectViewModel model)
        {
            // Проверяем, что Id в модели совпадает с переданным Id
            if (model.Id == Guid.Empty) return BadRequest("Invalid project ID");

            if (!ModelState.IsValid) return View(model);

            var command = _mapper.Map<UpdateProjectCommand>(model);
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        // 7. Удаление проекта (GET)
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new GetProjectByIdQuery { Id = id };

            var project = await _mediator.Send(query);
            if (project == null) return NotFound();

            var viewModel = _mapper.Map<ProjectViewModel>(project);
            return View(viewModel);
        }

        // 8. Удаление проекта (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ProjectViewModel model)
        {
            // Проверка на пустой ID
            if (model.Id == Guid.Empty) return BadRequest("Invalid project ID");

            var command = new DeleteProjectCommand { Id = model.Id };

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
