namespace Interface
{
    internal interface IPurse
    {
        // Все члены интерфейса по умолчанию public
        decimal Balance { get; }

        void EarnMoney(decimal amount);
        void SpendMoney(decimal amount);
    }
}
