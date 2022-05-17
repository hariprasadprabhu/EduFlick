namespace Course.Model
{
    public class Quiz
    {
        public Quiz(int id, string quetion, string option1, string option2, string option3, string option4, string answer)
        {
            Id = id;
            Quetion = quetion;
            Option1 = option1;
            Option2 = option2;
            Option3 = option3;
            Option4 = option4;
            this.answer = answer;
        }

        public int Id { get; set; }
        public string Quetion { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string answer { get; set; }
    }
}
