using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course.Model;
using Microsoft.Extensions.Options;
using Course.Model.Email;
//using MimeKit;
//using MailKit;
//using MailKit.Security;
//using MailKit.Net.Smtp;
using Course.Business;
using EASendMail;

namespace Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPassword : ControllerBase
    {
        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                ForgotPasswordBO bo= new ForgotPasswordBO();
                string email1="";
                if (!bo.IsEmailValid(request.ToEmail, ref email1))
                    return BadRequest("Invalid Email or UPRN");
                Random random= new Random();
                int code = random.Next(100000, 999999);
                bool res =bo.ForgotPassword(request.ToEmail, code);
                if(!res)
                    return Unauthorized();
                try
                {
                    SmtpMail oMail = new SmtpMail("TryIt");

                    // Your yahoo email address
                    oMail.From = "Eduflick@yahoo.com";

                    // Set recipient email address
                    oMail.To = email1;

                    // Set email subject
                    oMail.Subject = "Reset Password";

                    // Set email body
                    oMail.TextBody = "Hi,\n\nPlease use this code to reset your password " + code + "\n\nNote:OTP will be expiered in next 5 minutes\n\nThank you,\nTeam Eduflick";

                    // Yahoo SMTP server address
                    SmtpServer oServer = new SmtpServer("smtp.mail.yahoo.com");

                    // For example: your email is "myid@yahoo.com", then the user should be "myid@yahoo.com"
                    oServer.User = "eduflick@yahoo.com";
                    oServer.Password = "axtvcqcuivdolyqx";


                    // Because yahoo deploys SMTP server on 465 port with direct SSL connection.
                    // So we should change the port to 465. you can also use 25 or 587
                    oServer.Port = 465;

                    // detect SSL type automatically
                    oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                    EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                    oSmtp.SendMail(oServer, oMail);
                }
                catch (Exception ep)
                {

                }
                //var email = new MimeMessage();
                //string emailbody = "<h2>Hi,</h2><br/><p>Please use this code to reset your password "+code+"</p><br/><p>Note:OTP will be expiered in next 5 minutes</p><br/><p>Thank you,</p><br/><p>Eduflick</p>";
                //email.Sender = MailboxAddress.Parse("eduflick123@gmail.com");
                //email.From.Add(MailboxAddress.Parse("eduflick123@gmail.com"));
                //email.To.Add(MailboxAddress.Parse(email1));
                //email.Subject = "Eduflick Reset Password";
                //var builder = new BodyBuilder();
                //builder.HtmlBody = emailbody;
                //email.Body = builder.ToMessageBody();
                //using var smtp = new SmtpClient();
                //smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                //smtp.Authenticate("eduflick.mite@gmail.com", "Eduflick@123");
                //await smtp.SendAsync(email);
                //smtp.Disconnect(true);

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        [HttpPost]
        [Route("verifyOTP")]
        public IActionResult VerifyOTP([FromForm] VerifyOTP data)
        {
            ForgotPasswordBO fb = new ForgotPasswordBO();
            if (fb.VerifyOTP(data.email, data.code))
                return Ok();
            else
                return Unauthorized();
        }
        [HttpPost]
        [Route("resetpassword")]
        public IActionResult ResetPassword(Resetpassword resetpass)
        {
            ForgotPasswordBO fb = new ForgotPasswordBO();
            if (fb.ResetPassword(resetpass.email, resetpass.password))
                return Ok();
            else
                return Unauthorized();
        }
    }
}
