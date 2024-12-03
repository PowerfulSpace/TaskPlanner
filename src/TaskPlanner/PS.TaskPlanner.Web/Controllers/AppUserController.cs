using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.TaskPlanner.Application.CQRS.AppUsers.Commands.UpdateAppUser;
using PS.TaskPlanner.Application.CQRS.AppUsers.Queries.GetAllAppUsers;
using PS.TaskPlanner.Application.CQRS.AppUsers.Queries.GetAppUserById;
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

        // 1. Просмотр всех пользователей
        public async Task<IActionResult> Index()
        {
            var users = await _mediator.Send(new GetAllAppUsersQuery());
            var viewModel = _mapper.Map<List<AppUserViewModel>>(users);

            return View(viewModel);
        }

        // 2. Просмотр пользователя по ID
        public async Task<IActionResult> Details(Guid id)
        {
            var user = await _mediator.Send(new GetAppUserByIdQuery { Id = id });
            if (user == null) return NotFound();

            var viewModel = _mapper.Map<AppUserViewModel>(user);
            return View(viewModel);
        }

        // 3. Редактирование пользователя (GET)
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _mediator.Send(new GetAppUserByIdQuery { Id = id });
            if (user == null) return NotFound();

            var viewModel = _mapper.Map<AppUserViewModel>(user);
            return View(viewModel);
        }

        // 4. Редактирование пользователя (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AppUserViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            var command = _mapper.Map<UpdateAppUserCommand>(model);
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
