using Microsoft.EntityFrameworkCore;
using WebTracker.Models;

namespace Webtracker.Repositories
{
    public class WarningRepository: IWarningRepository
    { 
        private readonly WebTrackerDBContext _context;
        public WarningRepository(WebTrackerDBContext context) => _context = context;

        //methods---------------
        public bool AddAction(Warnings war)
        {
            _context.WarningDatas.Add(war);
            _context.SaveChanges();
            return true;
        }

        public List<Warnings> GetClientWarnings(string websiteName)
        {
            return _context.WarningDatas.Where(n => n.WebsiteName == websiteName).ToList();
        }
    }
}
