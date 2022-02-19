namespace TheWedding.Models
{
    class Guest : Person
    {
        public int MonetaryGift { get; set; }

        public Guest(string firstName, string lastName, int monetaryGift) : base(firstName, lastName)
        {
            MonetaryGift = monetaryGift;
        }
    }
}
