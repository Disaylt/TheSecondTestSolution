using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Domain.ValueObjects
{
    public class ScoreValueObject : BaseValueObject
    {
        public int Value { get; }

        public ScoreValueObject(int value)
        {
            if(value < 0)
            {
                throw new RootExeption(HttpStatusCode.BadRequest, $"Score cannot be less than 0, value = {value}");
            }

            Value = value;

        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
