namespace Interface
{
    internal class Safe : ISafe
    {
        private bool _isLocked = true;
        public bool IsLocked => _isLocked;

        private decimal _balance;
        public decimal Balance => _balance;

        public Safe(decimal initialBalance)
        {
            _balance = initialBalance;
        }

        public void EarnMoney(decimal amount)
        {
            if (_isLocked) throw new InvalidOperationException("Сейф заблокирован");

            _balance += amount;
        }

        public void SpendMoney(decimal amount)
        {
            if (_isLocked) throw new InvalidOperationException("Сейф заблокирован");

            _balance -= amount;
        }

        public void Lock()
        {
            _isLocked = true;
        }

        public void Unlock()
        {
            _isLocked = false;
        }
    }
}
