using SchsPolicySearch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchsPolicySearch.InMemoryData
{
    public class SearchService : ISearchService
    {
        private PolicySearchDbContext _policySearchDbContext;

        public SearchService(PolicySearchDbContext policySearchDbContext)
        {
            _policySearchDbContext = policySearchDbContext ?? throw new ArgumentNullException();
            policySearchDbContext.Database.EnsureCreated(); // required for data seeding
        }

        public Member GetMemberByPolicyNumberOrMemberNumber(string policyNumber, string memberCardNumber)
        {
            return _policySearchDbContext
                 .Members
                 .FirstOrDefault(x => x.MemberCardNumber == memberCardNumber || x.PolicyNumber == policyNumber);
        }
    }
}
