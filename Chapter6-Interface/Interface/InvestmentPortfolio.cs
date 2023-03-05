namespace Interface
{
    internal class InvestmentPortfolio : IPurse
    {
        private decimal _balance = 0;
        public decimal Balance => _balance;

        // Собственный метод класса
        public void EarnMoney(decimal amount)
        {
            _balance += amount * 2;
        }

        // Явная реализация интерфейса, у объекта этот метод вызвать не получится
        void IPurse.EarnMoney(decimal amount)
        {
            _balance += amount;
        }

        public void SpendMoney(decimal amount)
        {
            _balance -= amount;
        }
    }
}
