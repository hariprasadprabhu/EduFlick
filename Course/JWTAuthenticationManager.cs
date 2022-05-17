using Course.Model;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Course.DAC;

namespace Course
{
    public class JWTAuthenticationManager
    {
        public JWTAuthResponse AuthenticateLearner(string usn, string password)
        {
            LearnerDAC ldac = new LearnerDAC("");
            Learner lr = ldac.LoginCheck(usn, password);
            if (lr==null)
            {
                return null;
            }

            var JwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("Super secure Super secure Super secure");
            var securityTokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("username",usn)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };
            var securityToken = JwtSecurityTokenHandler.CreateToken(securityTokenDecriptor);
            var token = JwtSecurityTokenHandler.WriteToken(securityToken);
            return new JWTAuthResponse
            {
                token = token,
                email = usn,
                expiresIn = 30,
                learner = lr,
                userId=lr.Id
            };
        }
        public JWTAuthResponse AuthenticateRegister(string email)
        {
            var JwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("Super secure Super secure Super secure");
            var securityTokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("username",email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };
            var securityToken = JwtSecurityTokenHandler.CreateToken(securityTokenDecriptor);
            var token = JwtSecurityTokenHandler.WriteToken(securityToken);
            return new JWTAuthResponse
            {
                token = token,
                email = email,
                expiresIn = 30
            };
        }
        public JWTAuthResponse AuthenticateTrainer(string email, string password)
        {
            TrainerDAC ldac = new TrainerDAC("");
            Trainer lr = ldac.LoginCheck(email, password);
            if (lr == null)
            {
                return null;
            }

            var JwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("Super secure Super secure Super secure");
            var securityTokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("email",email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };
            var securityToken = JwtSecurityTokenHandler.CreateToken(securityTokenDecriptor);
            var token = JwtSecurityTokenHandler.WriteToken(securityToken);
            return new JWTAuthResponse
            {
                token = token,
                email = email,
                expiresIn = 30,
                trainer = lr,
                userId = lr.Id
            };
        }
        public JWTAuthResponse AuthenticateRegisterTrainer(string email)
        {
            var JwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("Super secure Super secure Super secure");
            var securityTokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new List<Claim>
                {
                    new Claim("email",email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };
            var securityToken = JwtSecurityTokenHandler.CreateToken(securityTokenDecriptor);
            var token = JwtSecurityTokenHandler.WriteToken(securityToken);
            return new JWTAuthResponse
            {
                token = token,
                email = email,
                expiresIn = 30
            };
        }
    }
}
