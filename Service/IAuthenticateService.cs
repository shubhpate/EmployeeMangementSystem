using Employee_Management_System.Model;

namespace Employee_Management_System.Service
{
    public interface IAuthenticateService
    {
            LoginEntity AuthenticateData(string username, string password);
            string GenerateToken(LoginEntity login);
    }
}
