namespace DACS.Models
{
    public class CareerOption
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; } // Ví dụ: "Sáng tạo", "Kỹ thuật", "Xã hội"

        public int CareerQuestionId { get; set; }
        public CareerQuestion CareerQuestion { get; set; }
    }

}
