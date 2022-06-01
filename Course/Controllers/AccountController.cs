using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course.Model;
using Course.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [EnableCors("AllowOrigin")]
        [HttpPost]
        [Route("learner/Login")]
        public IActionResult Login(LoginRequest loginrequest)
        {
            var jwtautheticationManager = new JWTAuthenticationManager();
            var authRes = jwtautheticationManager.AuthenticateLearner(loginrequest.usn, loginrequest.password);
            if (authRes == null)
                return Unauthorized();
            return Ok(authRes);

        }
        [HttpGet]
        [Route("getTrainers/{learnerId:int}")]
        public JsonResult GetTrainers(int learnerId)
        {
            LearnersAuth learnersAuth = new LearnersAuth();
            return new JsonResult(learnersAuth.GetTrainers(learnerId));
        }
        [HttpPost]  
        [Route("learner/RegisterLearner")]
        public IActionResult RegisterLearner(Learner regLearner)
        {
            var learnersAuth = new LearnersAuth();
            var result = learnersAuth.LearnerRegistration(regLearner);
            var jwtautheticationManager = new JWTAuthenticationManager();
            JWTAuthResponse authRes = jwtautheticationManager.AuthenticateRegister(regLearner.Email);
            if (result == "Err")
            {
                authRes.token = "";
                authRes.expiresIn = 0;
                authRes.email = regLearner.Email;
                authRes.error = "User Exist";
                return Ok(authRes);
            }
            else
                regLearner.Id = int.Parse(result);
            if (authRes == null)
                return Unauthorized();
            authRes.userId = int.Parse(result);
            return Ok(authRes);

        }
        [HttpPost]
        [Route("trainer/Login")]
        public IActionResult LoginTrainer(LoginRequest loginrequest)
        {
            var jwtautheticationManager = new JWTAuthenticationManager();
            var authRes = jwtautheticationManager.AuthenticateTrainer(loginrequest.email, loginrequest.password);
            if (authRes == null)
                return Unauthorized();
            return Ok(authRes);

        }
        [HttpPost]
        [Route("trainer/RegisterTrainer")]
        public IActionResult RegisterTrainer(Trainer regTrainer)
        {
            var trainersAuth = new TrainerAuth();
            var result = trainersAuth. TrainerRegistration(regTrainer);
            var jwtautheticationManager = new JWTAuthenticationManager();
            JWTAuthResponse authRes = jwtautheticationManager.AuthenticateRegisterTrainer(regTrainer.email);
            if (result == "Err")
            {
                authRes.token = "";
                authRes.expiresIn = 0;
                authRes.email = regTrainer.email;
                authRes.error = "Trainer Exist";
                return Ok(authRes);
            }
            else
                regTrainer.Id = int.Parse(result);
            if (authRes == null)
                return Unauthorized();
            authRes.userId = int.Parse(result);
            return Ok(authRes);

        }
    }
}
