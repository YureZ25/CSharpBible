using OperatorsOverride;

var p1 = new MyPoint(5, 10, 15);
var p2 = new MyPoint(15, 10, 5);
var middle = (p1 + p2) / 2;
Console.WriteLine($"Середина между точкой {p1} и точкой {p2} это точка {middle}");

var line1 = new MyLine(p1, p2);
var line2 = new MyLine(new MyPoint(-15, -20, -5), p2);
if (line1 > line2)
{
    Console.WriteLine("Первая линия больше");
}
else
{
    Console.WriteLine("Вторая линия больше");
}


var personPosition = new PersonPosition(-9, 46, 8);
var p = (MyPoint)personPosition;
Console.WriteLine($"Место положение человека: {p}");