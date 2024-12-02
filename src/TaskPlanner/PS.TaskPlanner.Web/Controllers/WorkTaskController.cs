using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.TaskPlanner.Domain.Entities;
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

        /// <summary>
        /// Получение списка всех задач.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var tasks = await _workTaskRepository.GetAllAsync();
            var taskViewModels = _mapper.Map<IEnumerable<WorkTaskViewModel>>(tasks);
            return View(taskViewModels);
        }

        /// <summary>
        /// Получение списка задач по ID проекта.
        /// </summary>
        public async Task<IActionResult> ByProject(Guid projectId)
        {
            var tasks = await _workTaskRepository.GetByProjectIdAsync(projectId);
            var taskViewModels = _mapper.Map<IEnumerable<WorkTaskViewModel>>(tasks);
            return View("Index", taskViewModels);
        }

        /// <summary>
        /// Получение списка задач по ID пользователя.
        /// </summary>
        public async Task<IActionResult> ByUser(Guid userId)
        {
            var tasks = await _workTaskRepository.GetByUserIdAsync(userId);
            var taskViewModels = _mapper.Map<IEnumerable<WorkTaskViewModel>>(tasks);
            return View("Index", taskViewModels);
        }

        /// <summary>
        /// Детали задачи по ID.
        /// </summary>
        public async Task<IActionResult> Details(Guid id)
        {
            var task = await _workTaskRepository.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            var taskViewModel = _mapper.Map<WorkTaskViewModel>(task);
            return View(taskViewModel);
        }

        /// <summary>
        /// Создание новой задачи (GET).
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Создание новой задачи (POST).
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkTaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
                return View(taskViewModel);

            var task = _mapper.Map<WorkTask>(taskViewModel);
            await _workTaskRepository.AddAsync(task);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Редактирование задачи (GET).
        /// </summary>
        public async Task<IActionResult> Edit(Guid id)
        {
            var task = await _workTaskRepository.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            var taskViewModel = _mapper.Map<WorkTaskViewModel>(task);
            return View(taskViewModel);
        }

        /// <summary>
        /// Редактирование задачи (POST).
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, WorkTaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
                return View(taskViewModel);

            var existingTask = await _workTaskRepository.GetByIdAsync(id);
            if (existingTask == null)
                return NotFound();

            var updatedTask = _mapper.Map(taskViewModel, existingTask);
            await _workTaskRepository.UpdateAsync(updatedTask);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Удаление задачи (GET).
        /// </summary>
        public async Task<IActionResult> Delete(Guid id)
        {
            var task = await _workTaskRepository.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            var taskViewModel = _mapper.Map<WorkTaskViewModel>(task);
            return View(taskViewModel);
        }

        /// <summary>
        /// Удаление задачи (POST).
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var task = await _workTaskRepository.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            await _workTaskRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
