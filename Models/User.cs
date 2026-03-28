using System.ComponentModel.DataAnnotations;

namespace DACS.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        // Role: "student" hoặc "admin"
        [Required]
        public string Role { get; set; }

        // Quan hệ
        public ICollection<ChatHistory> ChatHistories { get; set; }
        public ICollection<Suggestion> Suggestions { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<PersonalityTest> PersonalityTests { get; set; }
    }

}
