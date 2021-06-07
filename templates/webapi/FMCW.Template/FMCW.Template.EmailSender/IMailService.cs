using FMCW.Template.Results;
using System.Threading.Tasks;

namespace FMCW.Template.EmailSender
{
    public interface IMailService
    {
        Task<BoolResult> SendMail(MailRequest mailRequest);
        Task<BoolResult> SendTestMail();
    }
}
