using Employee_Management_System.IAuth;
using Employee_Management_System.Model;
using Employee_Management_System.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employee_Management_System.Service
{
    public class Authentication : IAuthenticateService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthRepository _IauthRepository;
        public Authentication(IAuthRepository authRepository, IConfiguration configuration)
        {
            _IauthRepository = authRepository;
            _configuration = configuration;
        }

        public LoginEntity AuthenticateData(string username, string password)
        {
            var userCheck = _IauthRepository.GetUserByUsername(username);
            if (userCheck != null && userCheck.Password == password)
            {
                return userCheck;
            }
            return null;
        }
        public string GenerateToken(LoginEntity Data)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
