using Inheritance;

Building myBuilding = new Building
{
    Width = 30,
    Length = 20,
    Height = 10,
};

myBuilding = new Shed();

Shed myShed = new Shed
{
    Width = 6,
    Length = 4,
    Height = 1,
};

myShed.Height = 2;

Console.WriteLine($"Объем сарая: {myShed.GetVolume()}");

AppartmentBuilding myAppartmentBuilding = new AppartmentBuilding
{
    Width = 130,
    Length = 120,
    Height = 110,
};

Console.WriteLine($"Объем многоэтажки: {myAppartmentBuilding.GetVolume()}");