using MediatR;
using MemeApp.Infrastructure.Commands;
using MemeApp.Infrastructure.Queries;
using MemeApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemesController : ControllerBase
    {
        private readonly IMediator mediator;

        public MemesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<MemeModel> memes = await mediator.Send(new GetAllMemesQuery());

            return Ok(memes);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateMemeAsync([FromBody] CreateMemeModel request)
        {
            await mediator.Send(new CreateMemeCommand(request));

            return Ok();
        }

        [HttpGet]
        [Route("seed")]
        public async Task<IActionResult> SeedMeesFromExternalApi([FromQuery]int number = 50)
        {
            await mediator.Send(new SeedMemesCommand(number));

            return Ok();
        }
    }
}
