using WebTracker.Models;

namespace Webtracker.Repositories
{
    public interface IWarningRepository
    {
        public bool AddAction(Warnings war);
        public List<Warnings> GetClientWarnings(string websiteName);
    }
}
