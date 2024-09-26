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

        //По подобному принципу проверяем каждое значение в топике, которые могут опракинуть валидация, для примера взял 2
        [TestCase("1234")]
        public void CreateTopic_InputTitle_ExpectedBadRequest(string title)
        {
            TopicDto topic = new TopicDto { Title = title };
            RootExeption exeption = Assert.ThrowsAsync<RootExeption>(() => _topicController.AddAsync(topic));
            Assert.That(exeption.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [TestCase("12345678901")]
        public async Task CreateTopic_InputTitle_ExpectedOk(string title)
        {
            TopicDto topic = new TopicDto { Title = title };
            IActionResult actionResult = await _topicController.AddAsync(topic);
            OkResult okResult = actionResult as OkResult
                ?? throw new NullReferenceException();

            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }
    }
}
