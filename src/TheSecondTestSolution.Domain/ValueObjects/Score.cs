using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecondTestSolution.Domain.ValueObjects
{
    public class Score : BaseValueObject
    {
        public int Value { get; }

        public Score(int value)
        {
            if(value < 0)
            {
                throw new ArgumentException($"Score cannot be less than 0, value = {value}");
            }

            Value = value;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
