using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheSecondTestSolution.Application.Commands;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Application.Queries;

namespace TheSecondTestSolution.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TopicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            GetTopicByIdQuery query = new GetTopicByIdQuery { Id = id };

            TopicDto topic = await _mediator.Send(query);

            return Ok(topic);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TopicDto body)
        {
            AddTopicCommand command = new AddTopicCommand { Topic = body };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
