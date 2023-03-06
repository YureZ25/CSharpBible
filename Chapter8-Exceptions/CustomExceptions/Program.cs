using CustomExceptions;

var engine = new CarEngine("CAXA");

engine.Start();

try
{
    engine.Start();
}
catch (CarEngineException ex)
{
    Console.WriteLine($"Запуск двигателя '{ex.CarEngine.Name}' заверщился с ошибкой '{ex.Message}'");
}
finally
{
    engine.Stop();
}

Console.WriteLine($"По итогу двигатель {(engine.IsWorking ? "работает" : "остановлен")}");