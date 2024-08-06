using Job_candidate_hub_API.Features.Candidates.Models;
using Job_candidate_hub_API.Features.Candidates.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Job_candidate_hub_API.Features.Candidates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidatesService _candidateService;

        public CandidatesController(ICandidatesService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateCandidate([FromBody] Candidate candidate)
        {
            if (candidate == null)
            {
                return BadRequest("Candidate cannot be null.");
            }

            var result = await _candidateService.CreateOrUpdateCandidateAsync(candidate);

            if (result.IsSuccess)
            {
                return Ok(result.Candidate);
            }

            return StatusCode(result.StatusCode, result.ErrorMessage);
        }
    }
}
