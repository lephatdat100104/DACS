namespace DACS.Models
{
    public class FinalYearTestResult
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TotalScore { get; set; }
        public string Recommendation { get; set; }
        public DateTime TakenAt { get; set; }
    }
}
