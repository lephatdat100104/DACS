using System.ComponentModel.DataAnnotations;

namespace DACS.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string Comment { get; set; }
    }

}
