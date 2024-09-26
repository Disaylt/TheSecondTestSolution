using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Api.Controllers;
using TheSecondTestSolution.UnitTests.Mocks.MediatR;

namespace TheSecondTestSolution.UnitTests.Api
{
    internal class TopicsTest
    {
        private TopicsController _topicsController;

        [SetUp]
        public void SetUp()
        {
            _topicsController = new TopicsController(MediatrMockFactory.ForTopicsController());
        }

        [Test]
        public async Task GetTopic_InputVoid_Expected200()
        {
            IActionResult actionResult = await _topicsController.GetRangeAsync();
            OkObjectResult okResult = actionResult as OkObjectResult
                ?? throw new NullReferenceException();

            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }
    }
}
