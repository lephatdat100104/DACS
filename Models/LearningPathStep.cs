using System.ComponentModel.DataAnnotations;

namespace DACS.Models
{
    public class LearningPathStep
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DominantType { get; set; } // VD: "Kỹ thuật"

        [Required]
        public string YearStage { get; set; } // VD: "Năm 1", "Năm 2"

        [Required]
        public string Content { get; set; } // Nội dung chi tiết
    }
}
