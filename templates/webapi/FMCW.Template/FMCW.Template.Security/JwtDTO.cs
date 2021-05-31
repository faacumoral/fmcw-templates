using FMCW.Template.Results;
using System;

namespace FMCW.Template.Security
{
    public class JwtDTO : BaseDTO
    {
        public string Jwt { get; set; }
        public DateTime ExpDate { get; set; } 
    }
}
