using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.TaskPlanner.Web.Models;

namespace PS.TaskPlanner.Web.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AppUserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AppUserViewModel model)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AppUserViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(AppUserViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<IActionResult> Details(AppUserViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
