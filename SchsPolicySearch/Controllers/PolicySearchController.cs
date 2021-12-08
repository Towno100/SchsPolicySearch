using Microsoft.AspNetCore.Mvc;
using SchsPolicySearch.InMemoryData;
using SchsPolicySearch.Web.Dtos;

namespace SchsPolicySearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolicySearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public PolicySearchController(ISearchService searchService)
        {
            _searchService = searchService;
            
        }
        
        [HttpGet(Name = "PolicySearch")]
        public IActionResult Get(string policyCardNumber, string memberCardNumber)
        {
            var member = _searchService.GetMemberByPolicyNumberOrMemberNumber(policyCardNumber, memberCardNumber);

            if (member == null)
            {
                return Ok(new MemberDto());
            }

            var memberDto = new MemberDto
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                MemberCardNumber = member.MemberCardNumber.Value,
                PolicyNumber = member.PolicyNumber
            };

            return Ok(memberDto);
        }
    }
}