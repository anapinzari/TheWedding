namespace TheWedding.Models
{
    class Person
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value == null || value.Length == 0) throw new Exception("First name cannot be empty.");
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == null || value.Length == 0) throw new Exception("Last name cannot be empty.");
                _lastName = value;
            }
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
