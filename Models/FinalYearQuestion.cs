namespace DACS.Models
{
    public class FinalYearQuestion
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ICollection<FinalYearAnswer> Answers { get; set; }
    }
}
