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
        public bool VerifyOTP(string email,int code)
        {
            ForgotPasswordDAC fd = new ForgotPasswordDAC();
            return fd.VerifyOTP(email, code);
        }

    }
}
