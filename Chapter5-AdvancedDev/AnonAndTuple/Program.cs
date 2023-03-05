
// Переменная анонимного типа
var person = new
{
    FirstName = "Yura",
    LastName = "Nik",
    Age = 25
};

// Свойства анонимного типа readonly
//person.Age = 34;

Console.WriteLine($"Чел: Имя - {person.FirstName} Фамилия - {person.LastName} Возраст - {person.Age} \n");

// System.Tuple не то же самое, что кортежи самого языка, они преобразуются в System.ValueTuple
// System.Tuple - класс с (readonly) свойствами
// System.ValueTuple - структура с полями
// https://blog.christian-schou.dk/ultimate-guide-to-use-tuple-in-programming/
// Tuple<double, double> coordinates = (34.78, 23.34); // Ошибка
// ValueTuple<double, double> coordinates = (34.78, 23.34); // Норм

// Декомпозиция кортежа
var (latitude, longitude) = GetCoordinates();

PrintCootdinates((latitude, longitude));

(double, double) GetCoordinates()
{
    return (25.34, 18.93);
}

// Использование именованного кортежа
void PrintCootdinates((double latitude, double longitude) coordinates)
{
    Console.WriteLine($"Широта: {coordinates.latitude} Долгота: {coordinates.longitude}");
}