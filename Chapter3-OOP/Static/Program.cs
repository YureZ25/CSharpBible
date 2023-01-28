using Static;

Console.WriteLine("Ничего не произошло");
// При любом обращении к статическим методам или создании объекта отрабатывает стратический конструктор
var testSheep = new Sheep { SheepName = "test" };
Console.WriteLine($"Кол-во овец: {Sheep.GetCount()}");

var archi = new Sheep("Арчи");
var elen = new Sheep("Элен");
var choko = new Sheep("Чоко");
var nastya = new Sheep("Настя");
var masha = new Sheep("Маша");
var yulya = new Sheep("Юля");

Console.WriteLine($"Индекс овцы {elen.SheepName} - {elen.SheepIndex}");

Console.WriteLine($"\nИтоговое кол-во овец: {Sheep.GetCount()}");

Sheep.ShowAll();

if (Sheep.GetCount() > 10)
{
    Console.WriteLine("Можно засыпать zzZ");
}
else
{
    Console.WriteLine("Слишком мало овец, чтобы заснуть");
}