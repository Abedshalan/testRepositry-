using CandidateApi.Application.Interface;
using CandidateApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApi.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost("candidate/add-update")]
        public async Task<IActionResult> AddOrUpdateCandidateAsync([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _candidateService.AddOrUpdateCandidateAsync(candidate);
            return Ok(candidate);
        }
    }
}
