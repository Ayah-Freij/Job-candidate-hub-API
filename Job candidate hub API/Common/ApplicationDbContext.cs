using Job_candidate_hub_API.Features.Candidates.Models;
using Microsoft.EntityFrameworkCore;

namespace Job_candidate_hub_API.Common
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Candidate> Candidates { get; set; }

    }
}
