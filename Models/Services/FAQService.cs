using Microsoft.EntityFrameworkCore;

namespace DACS.Models.Services
{
    public class FAQService
    {
        private readonly ApplicationDbContext _context;

        public FAQService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> GetAnswerAsync(string userMessage)
        {
            var faq = await _context.FAQs
                                    .FirstOrDefaultAsync(f => userMessage.Contains(f.Question));
            if (faq != null)
                return faq.Answer;
            return null;
        }

        public async Task AddFAQAsync(string question, string answer)
        {
            _context.FAQs.Add(new FAQ { Question = question, Answer = answer });
            await _context.SaveChangesAsync();
        }

        public async Task<List<FAQ>> GetAllFAQAsync()
        {
            return await _context.FAQs.ToListAsync();
        }

        public async Task UpdateFAQAsync(int id, string question, string answer)
        {
            var faq = await _context.FAQs.FindAsync(id);
            if (faq != null)
            {
                faq.Question = question;
                faq.Answer = answer;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteFAQAsync(int id)
        {
            var faq = await _context.FAQs.FindAsync(id);
            if (faq != null)
            {
                _context.FAQs.Remove(faq);
                await _context.SaveChangesAsync();
            }
        }
    }

}
