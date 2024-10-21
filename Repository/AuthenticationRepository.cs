using System;
using Employee_Management_System.Data;
using Employee_Management_System.IAuth;
using Employee_Management_System.Model;

namespace Employee_Management_System.AuthRepository
{
    public class AuthenticationRepository : IAuthRepository
    {
            private readonly EmployeeDBContext _context;

            public AuthenticationRepository(EmployeeDBContext context)
            {
                _context = context;
            }

            public LoginEntity GetUserByUsername(string username)
            {
                return _context.logins.FirstOrDefault(user => user.Username == username);
            }

    }
}
