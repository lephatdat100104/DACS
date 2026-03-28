namespace DACS.Models
{
    public class FinalYearAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public int QuestionId { get; set; }
        public FinalYearQuestion Question { get; set; }
    }
}
