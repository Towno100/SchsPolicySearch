using SchsPolicySearch.Domain.SharedKernal;
using SchsPolicySearch.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchsPolicySearch.Domain.Entities
{
    public class Member : BaseEntity
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }

        public NumericalIdentifier MemberCardNumber { get; }

        public NumericalIdentifier PolicyNumber { get; }

        protected Member() { }

        public Member(int id, string firstName, string lastName, DateTime dateOfBirth, NumericalIdentifier memberCardNumber, NumericalIdentifier policyCardNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            MemberCardNumber = memberCardNumber;
            PolicyNumber = policyCardNumber;
        }

    }

    //{"id":1,"firstName":"Winne","lastName":"Janc","memberCardNumber":"0473128446","policyNumber":"1405677686","dataOfBirth":"26/07/1995"}
}
