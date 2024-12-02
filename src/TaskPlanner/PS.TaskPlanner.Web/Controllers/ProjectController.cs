using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PS.TaskPlanner.Web.Models;

namespace PS.TaskPlanner.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectController(IMediator mediator, IMapper mapper)
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
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            throw new NotImplementedException();
        }


        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProjectViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ProjectViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<IActionResult> Details(ProjectViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
