using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Job_candidate_hub_API.Features.Candidates.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        public string TimeInterval { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string LinkedInProfile { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]

        public string GitHubProfile { get; set; }

        [Required(ErrorMessage = "A comment is required.")]
        public string FreeTextComment { get; set; }
    }
}
