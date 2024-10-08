﻿using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Application.Commands;
using TheSecondTestSolution.Application.Models;
using TheSecondTestSolution.Application.Queries;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.UnitTests.Mocks.MediatR
{
    internal class MediatrMockFactory
    {
        public static IMediator ForTopicController()
        {
            Mock<IMediator> mock = new Mock<IMediator>();

            mock.Setup(x => x.Send(It.Is<GetTopicByIdQuery>(l => l.Id == 0), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TopicDto());
            mock.Setup(x => x.Send(It.Is<GetTopicByIdQuery>(l => l.Id == 1), It.IsAny<CancellationToken>()))
               .Throws(() => new RootExeption(System.Net.HttpStatusCode.NotFound, string.Empty));
            mock.Setup(x => x.Send(It.Is<GetTopicByIdQuery>(l => l.Id < 0), It.IsAny<CancellationToken>()))
                .Throws(() => new RootExeption(System.Net.HttpStatusCode.BadRequest, string.Empty));

            mock.Setup(x => x.Send(It.IsAny<AddTopicCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TopicDto());

            return mock.Object;
        }

        public static IMediator ForTopicsController()
        {
            Mock<IMediator> mock = new Mock<IMediator>();

            mock.Setup(x => x.Send(It.IsAny<GetTopicsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Enumerable.Empty<TopicDto>());

            return mock.Object;
        }
    }
}
