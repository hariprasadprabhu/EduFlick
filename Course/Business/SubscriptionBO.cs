using Course.DAC;
using Course.Model;

namespace Course.Business
{
    public class SubscriptionBO
    {
        public bool Subscribe(Subscription sub)
        {
            SubscriptionDAC sDac= new SubscriptionDAC();
            return sDac.Subscribe(sub);

        }
    }
}
