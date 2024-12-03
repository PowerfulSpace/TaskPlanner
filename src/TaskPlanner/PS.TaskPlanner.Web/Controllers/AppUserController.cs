using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.TaskPlanner.Web.Models;

namespace PS.TaskPlanner.Web.Controllers
{
    public class AppUserController : Controller
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AppUserController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка всех пользователей.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllAsync();
            var userViewModels = _mapper.Map<IEnumerable<AppUserViewModel>>(users);
            return View(userViewModels);
        }

        /// <summary>
        /// Детали пользователя по ID.
        /// </summary>
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            var userViewModel = _mapper.Map<AppUserViewModel>(user);
            return View(userViewModel);
        }

        /// <summary>
        /// Редактирование данных пользователя (GET).
        /// </summary>
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            var userViewModel = _mapper.Map<AppUserViewModel>(user);
            return View(userViewModel);
        }

        /// <summary>
        /// Редактирование данных пользователя (POST).
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AppUserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                return NotFound();

            var updatedUser = _mapper.Map(userViewModel, existingUser);
            await _userRepository.UpdateAsync(updatedUser);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Удаление пользователя (GET).
        /// </summary>
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            var userViewModel = _mapper.Map<AppUserViewModel>(user);
            return View(userViewModel);
        }

        /// <summary>
        /// Удаление пользователя (POST).
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            // Здесь можно вызвать метод DeleteAsync, если он реализован в репозитории.
            // await _userRepository.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
// Исправить ошибки для репозитория