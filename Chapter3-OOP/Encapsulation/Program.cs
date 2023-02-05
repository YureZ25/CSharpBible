using Encapsulation;

var fileHandler = new FileHandler("test.txt");

var line = fileHandler.ReadLine();

Console.WriteLine(line);