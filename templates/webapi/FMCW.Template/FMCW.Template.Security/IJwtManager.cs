using FMCW.Template.Results;

namespace FMCW.Template.Security
{
    public interface IJwtManager
    {
        public JwtDTO GenerateToken(int idUsuario);
        public IntResult ValidateToken(string token);
    }
}