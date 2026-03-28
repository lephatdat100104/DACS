using System.ComponentModel.DataAnnotations;

namespace DACS.Models
{
    public class ChatHistory
    {
        [Key] // 👈 Đây là dòng quan trọng
        public int ChatId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Question { get; set; }

        public string Answer { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

    }

}


