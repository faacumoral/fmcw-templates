namespace FMCW.Template.EmailSender
{
    public class MailConfig
    {
        public string Smtp { get; set; }
        public int Port { get; set; }
        public string From { get; set; }
        public string FromPassword { get; set; }
        public string FromName { get; set; }
    }
}
