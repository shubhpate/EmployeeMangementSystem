using Employee_Management_System.Model;

namespace Employee_Management_System.IAuth
{
    public interface IAuthRepository
    {
        LoginEntity GetUserByUsername(string username);
    }
}
