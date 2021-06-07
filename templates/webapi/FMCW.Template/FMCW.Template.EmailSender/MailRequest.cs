using System.Collections.Generic;

namespace FMCW.Template.EmailSender
{
    public class MailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<MailAttachment> Attachments { get; set; }
    }
}
