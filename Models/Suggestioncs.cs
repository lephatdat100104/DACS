using System.ComponentModel.DataAnnotations;

namespace DACS.Models
{
    public class Suggestion
    {
        public int SuggestionId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        // Loại gợi ý: "Học tập" | "Nghề nghiệp"
        [Required]
        public string Type { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

}
