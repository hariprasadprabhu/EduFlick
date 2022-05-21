using Course.DAC;
using Course.Model;
namespace Course.Business
{
    public class ForgotPasswordBO
    {
        public bool ForgotPassword(string email,int code)
        {
            ForgotPasswordDAC fd = new ForgotPasswordDAC();
            return fd.updateSecreteCode(email,code);

        }
        public bool IsEmailValid(string emailorUSN,ref string email)
        {
            ForgotPasswordDAC fd = new ForgotPasswordDAC();
            return fd.IsEmailValid(emailorUSN,ref email);
        }
        public bool VerifyOTP(string email,int code)
        {
            ForgotPasswordDAC fd = new ForgotPasswordDAC();
            return fd.VerifyOTP(email, code);
        }
        public bool ResetPassword(string email, string password)
        {
            ForgotPasswordDAC fd = new ForgotPasswordDAC();
            return fd.ResetPassword(email, password);
        }

    }
}
