namespace DefaultInterface
{
    internal class Deposit : IPurse
    {
        public decimal Balance { get; set; }

        public void EarnMoney(decimal amount)
        {
            Balance += amount * 2;
        }
    }
}
