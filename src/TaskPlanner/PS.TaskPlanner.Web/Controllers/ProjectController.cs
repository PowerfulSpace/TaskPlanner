using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Получение списка всех проектов.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var projects = await _projectRepository.GetAllAsync();
            var projectViewModels = _mapper.Map<IEnumerable<ProjectViewModel>>(projects);
            return View(projectViewModels);
        }

        /// <summary>
        /// Получение списка проектов пользователя по UserId.
        /// </summary>
        public async Task<IActionResult> ByUser(Guid userId)
        {
            var projects = await _projectRepository.GetByUserIdAsync(userId);
            var projectViewModels = _mapper.Map<IEnumerable<ProjectViewModel>>(projects);
            return View("Index", projectViewModels);
        }

        /// <summary>
        /// Детали проекта по ID.
        /// </summary>
        public async Task<IActionResult> Details(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return NotFound();

            var projectViewModel = _mapper.Map<ProjectViewModel>(project);
            return View(projectViewModel);
        }

        /// <summary>
        /// Создание нового проекта (GET).
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Создание нового проекта (POST).
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid)
                return View(projectViewModel);

            var project = _mapper.Map<Project>(projectViewModel);
            await _projectRepository.AddAsync(project);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Редактирование проекта (GET).
        /// </summary>
        public async Task<IActionResult> Edit(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return NotFound();

            var projectViewModel = _mapper.Map<ProjectViewModel>(project);
            return View(projectViewModel);
        }

        /// <summary>
        /// Редактирование проекта (POST).
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid)
                return View(projectViewModel);

            var existingProject = await _projectRepository.GetByIdAsync(id);
            if (existingProject == null)
                return NotFound();

            var updatedProject = _mapper.Map(projectViewModel, existingProject);
            await _projectRepository.UpdateAsync(updatedProject);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Удаление проекта (GET).
        /// </summary>
        public async Task<IActionResult> Delete(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return NotFound();

            var projectViewModel = _mapper.Map<ProjectViewModel>(project);
            return View(projectViewModel);
        }

        /// <summary>
        /// Удаление проекта (POST).
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return NotFound();

            await _projectRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
