using Microsoft.EntityFrameworkCore;
using WebTracker.Models;

namespace Webtracker.Repositories
{
    public class ErrorRespository : IErrorsRepository
    {
        private readonly WebTrackerDBContext _context;
        public ErrorRespository(WebTrackerDBContext context) => _context = context;

        //methods---------------
        public bool AddAction(Error error)
        {
            _context.ErrorDatas.Add(error);
            _context.SaveChanges();
            return true;
        }

        public List<Error> GetClientErrors(string websiteName)
        {
            return _context.ErrorDatas.Where(n => n.WebsiteName == websiteName).ToList();
        }
    }
}
