namespace FMCW.Template.EmailSender
{
    public class MailAttachment
    {
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
    }
}
