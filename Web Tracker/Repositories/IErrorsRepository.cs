using WebTracker.Models;

namespace Webtracker.Repositories
{
    public interface IErrorsRepository
    {
        public bool AddAction(Error error);

        public List<Error> GetClientErrors(string websiteName);

    }
}
