using Destructor;

DestructorTest();
Console.WriteLine("\n\n");
DisposeTest();

void DestructorTest()
{
    CreateSomeObj();

    GC.Collect();
    Console.ReadKey();
}

void CreateSomeObj()
{
    var dataReader = new FakeDataReader("C:/data/text.txt");
    dataReader = new FakeDataReader("/sys/server.conf");
    dataReader = new FakeDataReader("D:/video.mkv");
}

void DisposeTest()
{
    using (var fakeCon = new FakeDbConnection("SQLite"))
    {
        Console.WriteLine($"Взаимодействуем с соединением {fakeCon.Name} внутри using");
    }

    FakeDbConnection? fakeDb = null;
    try
    {
        fakeDb = new FakeDbConnection("MS SQL");
    }
    finally
    {
        fakeDb?.Dispose();
    }
}