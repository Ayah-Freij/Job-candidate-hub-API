using Job_candidate_hub_API.Features.Candidates.Models;
using Job_candidate_hub_API.Features.Candidates.Repositories;

namespace Job_candidate_hub_API.Features.Candidates.Services
{
    public class CandidatesServices : ICandidatesService
    {
        private readonly ICandidatesRepository _candidateRepository;

        public CandidatesServices(ICandidatesRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<(bool IsSuccess, Candidate Candidate, string ErrorMessage, int StatusCode)> CreateOrUpdateCandidateAsync(Candidate candidate)
        {
            try
            {
                var existingCandidate = await _candidateRepository.GetCandidateByEmailAsync(candidate.Email);
                if (existingCandidate != null)
                {
                    existingCandidate.FirstName = candidate.FirstName;
                    existingCandidate.LastName = candidate.LastName;
                    existingCandidate.PhoneNumber = candidate.PhoneNumber;
                    existingCandidate.TimeInterval = candidate.TimeInterval;
                    existingCandidate.LinkedInProfile = candidate.LinkedInProfile;
                    existingCandidate.GitHubProfile = candidate.GitHubProfile;
                    existingCandidate.FreeTextComment = candidate.FreeTextComment;
                    await _candidateRepository.UpdateCandidateAsync(existingCandidate);
                    return (true, existingCandidate, null, 200);
                }
                else
                {
                    await _candidateRepository.CreateCandidateAsync(candidate);
                    return (true, candidate, null, 201);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return (false, null, ex.Message, 500);
            }
        }
    }

    public interface ICandidatesService
    {
        Task<(bool IsSuccess, Candidate Candidate, string ErrorMessage, int StatusCode)> CreateOrUpdateCandidateAsync(Candidate candidate);
    }
}
