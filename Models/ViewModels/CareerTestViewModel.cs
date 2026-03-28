namespace DACS.Models.ViewModels
{
    public class CareerTestViewModel
    {
        public List<CareerQuestion> Questions { get; set; }
        public Dictionary<int, int> Answers { get; set; } // QuestionId → OptionId
    }
}
