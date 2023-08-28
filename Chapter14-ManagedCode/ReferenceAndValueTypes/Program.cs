
var people = new List<Person>();

AddPerson("Yura", "Nik");
AddPerson("Yura", "Nik");

PrintPeople();

// Две структуры будут равны если значения из полей одинаковые
Console.WriteLine($"Первый элемент такой же как второй: {people[0].Equals(people[1])}");

void AddPerson(string firstName, string lastName)
{
    // В стеке выделяется и заполняется значениями память для стрктуры
    var p = new Person { FirstName = firstName, LastName = lastName };

    // Т.к. массивы не могут работать со значимыми типами, то в момент добавления
    people.Add(p); // происходит неявная упаковка в объект, расположенный в куче

    // После упакопки (копирования в кучу) изменения изходной переменной не повлияют на элемент в списке
    p.FirstName = lastName;
    p.LastName = firstName;

    // При окончании метода значения из стека удаляются, но в куче - остаются и удаляются только при
    // отсутвии на них ссылок сборщиком мусора, когда он посчитает нужным)
}

void PrintPeople()
{
    foreach (var p in people)
    {
        Console.WriteLine(p);
    }
}

struct Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Структуры тоже наследуются от object, но опосредовано, через ValueType
    public override readonly string ToString()
    {
        // Модификатор readonly тут запрещает изменение структуры в этом методе
        // FirstName = string.Empty; - ошибка
        return $"{FirstName} {LastName}";
    }
}