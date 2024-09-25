using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Domain.ValueObjects
{
    public class LinkValueObject : BaseValueObject
    {
        public string Value { get; private set; }

        public LinkValueObject(string value)
        {
            if(Uri.IsWellFormedUriString(value, UriKind.Absolute) == false)
            {
                throw new RootExeption(HttpStatusCode.BadRequest, $"Bad uri - {value}");
            }

            Value = value;
        }


        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
