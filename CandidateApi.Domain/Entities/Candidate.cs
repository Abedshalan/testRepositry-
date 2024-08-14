using System.ComponentModel.DataAnnotations;

namespace CandidateApi.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; } // Primary key, auto-incremented by convention
        [Required] // Data annotation to specify that the field is required
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required] 
        [EmailAddress] // Optional: Data annotation for email format validation
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string CallTimeInterval { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
