using CSharpFunctionalExtensions;
using SchsPolicySearch.Common;
using SchsPolicySearch.Domain.SharedKernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchsPolicySearch.Domain.ValueObjects
{
    public class NumericalIdentifier : ValueObject
    {

        public string Value { get; }

        private NumericalIdentifier(string identifier)
        {
            Value = identifier;
        }

        public static Result<NumericalIdentifier> Create(string identifier)
        {
            if (!identifier.IsValidNumbericalIdentifier())
            {
                return Result.Failure<NumericalIdentifier>("The identifier must be 10 digit number."); 
                //throw new ArgumentException("The identifier must be 10 digit number.");
            }

            return Result.Success(new NumericalIdentifier(identifier));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(NumericalIdentifier numericalIdentifier)
        {
            return numericalIdentifier.Value;
        }
    }
}
