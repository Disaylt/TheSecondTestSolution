using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Api.Controllers;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Domain.Seed;
using TheSecondTestSolution.UnitTests.Mocks.MediatR;

namespace TheSecondTestSolution.UnitTests.Api
{
    public class TopicTest
    {
        private TopicController _topicController;

        [SetUp]
        public void SetUp()
        {
            _topicController = new TopicController(MediatrMockFactory.ForTopicController());
        }

        [TestCase(0)]
        public async Task GetTopic_InputId_ExpectedTopic(int id)
        {
            IActionResult actionResult = await _topicController.GetAsync(id);
            OkObjectResult okResult = actionResult as OkObjectResult
                ?? throw new NullReferenceException();

            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }

        [TestCase(1)]
        public void GetTopic_InputId_ExpectedNotFound(int id)
        {
            RootExeption exeption = Assert.ThrowsAsync<RootExeption>(() => _topicController.GetAsync(id));
            Assert.That(exeption.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [TestCase(-1)]
        public void GetTopic_InputId_ExpectedBadRequest(int id)
        {
            RootExeption exeption = Assert.ThrowsAsync<RootExeption>(() => _topicController.GetAsync(id));
            Assert.That(exeption.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public async Task CreateTopic_InputTitle_ExpectedNewTopicType()
        {
            IActionResult actionResult = await _topicController.AddAsync(new TopicDto());
            OkObjectResult okResult = actionResult as OkObjectResult
                ?? throw new NullReferenceException();

            Assert.That(okResult.Value?.GetType(), Is.EqualTo(typeof(TopicDto)));
        }

        [Test]
        public async Task CreateTopic_InputTitle_Expected200()
        {
            IActionResult actionResult = await _topicController.AddAsync(new TopicDto());
            OkObjectResult okResult = actionResult as OkObjectResult
                ?? throw new NullReferenceException();

            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }
    }
}
