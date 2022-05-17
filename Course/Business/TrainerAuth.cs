using Course.DAC;
using Course.Model;

namespace Course.Business
{
    public class TrainerAuth
    {
        public string TrainerRegistration(Trainer learner)
        {
            TrainerDAC learnerDAC = new TrainerDAC("");
            string res = learnerDAC.RegisterTrainer(learner);
            return res;


        }
    }
}
