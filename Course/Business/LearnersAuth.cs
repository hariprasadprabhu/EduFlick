using Course.DAC;
using Course.Model;
using Course.Model.RequestResponse;

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
        public Trainers[] GetTrainers(int learnerId)
        {
            LearnerDAC learnerdac = new LearnerDAC("");
            return learnerdac.GetTrainers(learnerId);
        }

    }
}
