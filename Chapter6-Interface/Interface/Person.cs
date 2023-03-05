namespace Interface
{
    internal class Person : IPurse
    {
        private decimal _balance = 0;
        public decimal Balance => _balance;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void EarnMoney(decimal amount)
        {
            _balance += amount;
        }

        public void SpendMoney(decimal amount)
        {
            _balance -= amount;
        }
    }
}
