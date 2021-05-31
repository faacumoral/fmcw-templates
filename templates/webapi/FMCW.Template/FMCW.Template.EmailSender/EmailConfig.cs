using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMCW.Template.EmailSender
{
    public class EmailConfig
    {
        public string Smtp { get; set; }
        public int Port { get; set; }
        public string From { get; set; }
        public string FromPassword { get; set; }
        public string FromName { get; set; }
    }
}
