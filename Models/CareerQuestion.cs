namespace DACS.Models
{
    public class CareerQuestion
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public ICollection<CareerOption> Options { get; set; }
    }

}
