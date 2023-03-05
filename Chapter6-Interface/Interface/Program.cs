using Interface;

// Создаем переменную человека и присваеваем ее экземпляр переменным object и IPurse
// (ссылка будет на один и тот же объект)
var person = new Person("Yura", "Nik");
object personObject = person;
IPurse personPurse = person;

// Можно вызвать метод на прямую у объекта
person.EarnMoney(110);
PrintBalance(person);

// Способ через приведение объекта к интерфейсу
if (personObject is IPurse purse)
{
    purse.SpendMoney(20);
    PrintBalance(purse);
}

// Способ через присваивание переменной типа интерфейса
personPurse.SpendMoney(30);
PrintBalance(personPurse);
Console.WriteLine();

// Использование интерфейса для унификации аргументов метода
void PrintBalance(IPurse purse)
{
    Console.WriteLine($"Сумма в кошельке: {purse.Balance}");
}


var deposit = new Deposit();

// Отработает собственный метод класса
deposit.EarnMoney(55);
PrintBalance(deposit);

// Отработает метод интерфейса
((IPurse)deposit).EarnMoney(30);
PrintBalance(deposit);
Console.WriteLine();

// Объект сейфа реализует сразу и ISafe и IPurse
ISafe safe = new Safe(230);
try
{
    safe.SpendMoney(30); // Не получится, т.к. сейф по умолчанию заблокирован
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
safe.Unlock();
safe.SpendMoney(40);
PrintBalance(safe);
