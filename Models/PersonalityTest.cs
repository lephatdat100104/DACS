using System.ComponentModel.DataAnnotations;

namespace DACS.Models
{
    public class PersonalityTest
    {
        [Key] // 👈 Đây là khóa chính
        public int TestId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        public string TestType { get; set; } // MBTI, Holland, v.v.

        public string Result { get; set; } // Ví dụ: "INTJ", "Realistic - Investigative"

        public DateTime TakenAt { get; set; } = DateTime.Now;
    }

}
