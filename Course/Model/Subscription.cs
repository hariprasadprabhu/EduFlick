namespace Course.Model
{
    public class Subscription
    {
        public Subscription(int id, int trainerid, int learnerid)
        {
            this.id = id;
            this.trainerid = trainerid;
            this.learnerid = learnerid;
        }

        public int id { get; set; }
        public int trainerid { get; set; }
        public int learnerid { get; set; }
        public DateTime date { get; set; } = DateTime.Now;

    }
}
