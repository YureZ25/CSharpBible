namespace DefaultInterface
{
    internal interface IPurse
    {
        decimal Balance { get; set; }

        void EarnMoney(decimal amount)
        {
            Balance += amount;
        }

        void SpendMoney(decimal amount)
        {
            Balance -= amount;
        }
    }
}
