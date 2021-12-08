using SchsPolicySearch.Domain.Entities;

namespace SchsPolicySearch.InMemoryData
{
    public interface ISearchService
    {
        public Member GetMemberByPolicyNumberOrMemberNumber(string policyNumber, string memberNumber);
    }
}
