using Job_candidate_hub_API.Common;
using Job_candidate_hub_API.Features.Candidates.Models;
using Microsoft.EntityFrameworkCore;

namespace Job_candidate_hub_API.Features.Candidates.Repositories
{
    public class CandidatesRepositories : ICandidatesRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidatesRepositories(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate> GetCandidateByEmailAsync(string email)
        {
            return await _context.Candidates.SingleOrDefaultAsync(candidate => candidate.Email == email);
        }

        public async Task CreateCandidateAsync(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCandidateAsync(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
        }

    }
    public interface ICandidatesRepository
    {
        Task<Candidate> GetCandidateByEmailAsync(string email);
        Task CreateCandidateAsync(Candidate candidate);
        Task UpdateCandidateAsync(Candidate candidate);
    }
}
