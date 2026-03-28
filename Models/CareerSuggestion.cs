using System.ComponentModel.DataAnnotations;

namespace DACS.Models
{
    public class CareerSuggestion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CareerType { get; set; }  // Ví dụ: "Kỹ thuật", "Sáng tạo"

        public string SuggestedMajors { get; set; }  // Ví dụ: "CNTT, Cơ điện tử"

        public string Resources { get; set; }  // Ví dụ: Link tài liệu, sách
    }
}
