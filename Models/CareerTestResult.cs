namespace DACS.Models
{
    public class CareerTestResult
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime TakenAt { get; set; }
        public string DominantType { get; set; }
        public string Suggestion { get; set; }
    }

}
