using Course.DAC;
using Course.Model;

namespace Course.Business
{
    public class LearnersAuth
    {
        public string LearnerRegistration(Learner learner)
        {
            LearnerDAC learnerDAC = new LearnerDAC("");
            string res = learnerDAC.RegisterLearner(learner);
            return res;


        }
    }
}
