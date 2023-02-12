
// Взаимодействие со структурой как с обычной переменной
// При объявлении переменной на нее сразу выделяется память в стеке
Person yura;
yura.FirstName = "Юра";
yura.LastName = "Никитин";
yura.Age = 25;
Console.WriteLine($"Имя: {yura.FirstName}, Фамилия: {yura.LastName}, Возраст: {yura.Age}.");

// Можно использовать new для вызова конструктора
Person tanya = new Person("Таня", "Прокопенко");
Console.WriteLine($"Имя: {tanya.FirstName}, Фамилия: {tanya.LastName}, Возраст: {tanya.Age}.");

// Можно вызывать методы структуры
yura.Print();


struct Person
{
    // поля структуры
    public string FirstName;
    public string LastName;
    public int Age;

    // В отличии от классов, у структур конструктор без параметров остается даже при определении кастомного
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = 18;
    }

    // Можно использовать и методы, но это дороже по производительность из-за распаковки
    public void Print()
    {
        Console.WriteLine($"Имя: {FirstName}, Фамилия: {LastName}, Возраст: {Age}.");
    }
}