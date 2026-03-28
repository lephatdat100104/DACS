namespace DACS.Models.ViewModels
{
    public class CareerTestResultViewModel
    {
        public string DominantType { get; set; }
        public string Suggestion { get; set; }
        public string Resources { get; set; }

        public List<UniversitySuggestion> UniversitySuggestions { get; set; } // <-- dòng nà
    }
}
