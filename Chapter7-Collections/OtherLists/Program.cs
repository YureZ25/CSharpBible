﻿using System.Collections;

var queue = new Queue();
queue.Enqueue("Первый");
queue.Enqueue(2);
queue.Enqueue("Третий");
queue.Enqueue(4);
queue.Enqueue("Пятый");
queue.Enqueue("Шестой");

Console.WriteLine("Очередь:");
do
{
    var value = queue.Dequeue();
    Console.WriteLine(value);
} while (queue.Count > 0);
Console.WriteLine();


var stack = new Stack();
stack.Push("Первый");
stack.Push(2);
stack.Push("Третий");
stack.Push("Четвертый");
stack.Push(5);
stack.Push("Шестой");

Console.WriteLine("Стек:");
for ( ; stack.Count > 0; )
{
    var value = stack.Pop();
    Console.WriteLine(value);
}
Console.WriteLine();


var hashtable = new Hashtable
{
    { "Михаил Смирнов", new Person("Михаил", "Смирнов") },
    { "Сергей Иванов", new Person("Сергей", "Иванов") },
    { "Алексей Петров", new Person("Алексей", "Петров") }
};

Console.WriteLine("Хэштаблица:");
Console.Write("Значения: ");
foreach (Person person in hashtable.Values)
{
    Console.Write(person.LastName + "; ");
}
Console.WriteLine();

Console.Write("Ключи: ");
foreach(string key in hashtable.Keys)
{
    Console.Write(key + "; ");
}
Console.WriteLine();

Console.Write("Значения по ключу: ");
foreach (string key in hashtable.Keys)
{
    var p = (Person?)hashtable[key];
    Console.Write($"Ключ - {key}, Имя - {p?.FirstName}; ");
}
Console.WriteLine();

record Person(string FirstName, string LastName);