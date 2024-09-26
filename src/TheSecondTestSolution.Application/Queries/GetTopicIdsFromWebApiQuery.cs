﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecondTestSolution.Application.Queries
{
    public class GetTopicIdsFromWebApiQuery : IRequest<IReadOnlyCollection<int>>
    {
    }
}
