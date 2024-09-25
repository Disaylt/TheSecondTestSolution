using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Application.Queries;

namespace TheSecondTestSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TopicsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRangeAsync()
        {
            GetTopicsQuery query = new GetTopicsQuery();

            IEnumerable<TopicDto> topics = await _mediator.Send(query);

            return Ok(topics);
        }
    }
}
