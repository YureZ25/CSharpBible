using DefaultInterface;

IPurse purse = new Purse();
purse.EarnMoney(60);
Console.WriteLine($"Сумма в кошельке: {purse.Balance}");

IPurse deposit = new Deposit();
deposit.EarnMoney(60);
Console.WriteLine($"Сумма на депозите: {deposit.Balance}");
