
var linkedList = new LinkedList<string>(new[] { "Михаил Смирнов", "Сергей Иванов", "Алексей Петров" });
var currentNode = linkedList.First;
Console.WriteLine("Двусвязный список:");
while (currentNode != null)
{
    Console.Write(currentNode.Value + "; ");
    currentNode = currentNode.Next;
}
Console.Write("\n\n");


var queue = new Queue<string>();
queue.Enqueue("Первый");
queue.Enqueue("Второй");
queue.Enqueue("Третий");
queue.Enqueue("Четвертый");
queue.Enqueue("Пятый");
queue.Enqueue("Шестой");

Console.WriteLine("Очередь:");
do
{
    var value = queue.Dequeue();
    Console.WriteLine(value);
} while (queue.Count > 0);
Console.WriteLine();


var stack = new Stack<string>();
stack.Push("Первый");
stack.Push("Второй");
stack.Push("Третий");
stack.Push("Четвертый");
stack.Push("Пятый");
stack.Push("Шестой");

Console.WriteLine("Стек:");
for (; stack.Count > 0;)
{
    var value = stack.Pop();
    Console.WriteLine(value);
}
Console.WriteLine();


var dict = new Dictionary<string, Person>
{
    { "Михаил Смирнов", new Person("Михаил", "Смирнов") },
    { "Сергей Иванов", new Person("Сергей", "Иванов") },
    { "Алексей Петров", new Person("Алексей", "Петров") }
};

Console.WriteLine("Хэштаблица:");
Console.Write("Значения: ");
foreach (Person person in dict.Values)
{
    Console.Write(person.LastName + "; ");
}
Console.WriteLine();

Console.Write("Ключи: ");
foreach (string key in dict.Keys)
{
    Console.Write(key + "; ");
}
Console.WriteLine();

Console.Write("Значения по ключу: ");
foreach (var (key, value) in dict)
{
    Console.Write($"Ключ - {key}, Имя - {value?.FirstName}; ");
}
Console.WriteLine();

record Person(string FirstName, string LastName);