namespace WebTracker.Models
{
    public class Error
    {
        public int ErrorId { get; set; }
        public string ErrorData { get; set; }
        public string ErrorScript { get; set; }
        public int ErrorLine { get; set; }
        public int ErrorColumn { get; set; }
        public string ErrorStack { get; set; }
        public string WebsiteName { get; set; }
    }
}
