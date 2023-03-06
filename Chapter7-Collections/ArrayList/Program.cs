using ArrayList;

var parent = new Person("Дмитрий", "Никитин");
parent.AddChild("Юрий", "Никитин");
parent.AddChild("Леонид", "Никитин");
parent.AddChild("Татьяна", "Прокопенко");
parent.AddChild("Владимир", "Никитин");

Console.WriteLine($"Дети родителя {parent}:");
for (int i = 0; i < parent.ChildrenCount; i++)
{
    Console.WriteLine(parent[i]);
}
Console.WriteLine();

parent.SortChildren();
Console.WriteLine($"Отсортированные дети родителя {parent}:");
foreach (var child in parent)
{
    Console.WriteLine(child);
}
Console.WriteLine();

parent.SortChildrenByFirstName();
Console.WriteLine($"Отсортированные по имени дети родителя {parent}:");
foreach (var child in parent)
{
    Console.WriteLine(child);
}
Console.WriteLine();

parent.DeleteChild(3);
Console.WriteLine($"Дети родителя {parent}:");
foreach (var child in parent)
{
    Console.WriteLine(child);
}
