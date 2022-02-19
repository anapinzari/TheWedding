namespace TheWedding.Models
{
    class MarriedPerson : Person
    {       
        public int ExpectedAmountFromGodparents { get; set; }
        public int ExpectedAmountFromGuests { get; set; }

        public MarriedPerson(string firstName, string lastName, int expectedAmountFromGodparents, int expectedAmountFromGuests) : base(firstName, lastName) 
        {
            ExpectedAmountFromGodparents = expectedAmountFromGodparents;
            ExpectedAmountFromGuests = expectedAmountFromGuests;
        }
    }
}
