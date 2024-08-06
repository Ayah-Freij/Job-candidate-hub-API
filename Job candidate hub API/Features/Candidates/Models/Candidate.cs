using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_candidate_hub_API.Features.Candidates.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string TimeInterval { get; set; }

        [Url]
        public string LinkedInProfile { get; set; }

        [Url]
        public string GitHubProfile { get; set; }

        [Required]
        public string FreeTextComment { get; set; }
    }
}
