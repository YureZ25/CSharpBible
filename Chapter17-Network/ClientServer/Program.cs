using ClientServer;

while (true)
{
    Console.WriteLine("Программа для обмена сообщениями");
    Console.WriteLine("1 - Запустить сервер");
    Console.WriteLine("2 - Соединение с сервером");
    Console.WriteLine("0 - Зввершить программу");

    if (!int.TryParse(Console.ReadLine(), out var cmd))
    {
        Console.WriteLine("Комманда не распознана. Повторите ввод.");
        continue;
    }

    switch (cmd)
    {
        case 0:
            Console.WriteLine("Завершение программы...");
            return;
        case 1:
            try
            {
                await ServerCommands(new Server());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        case 2:
            try
            {
                await ClientCommands(new Client());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            break;
        default:
            Console.WriteLine("Такой комманды еще не придумали(");
            break;
    }
}

Task ServerCommands(Server server)
{
    while (true)
    {
        Console.WriteLine("0 - Выключить сервер");

        if (!int.TryParse(Console.ReadLine(), out var cmd))
        {
            Console.WriteLine("Комманда не распознана. Повторите ввод.");
            continue;
        }

        switch (cmd)
        {
            case 0:
                Console.WriteLine("Выключаем сервер");
                server.Stop();
                return Task.CompletedTask;
            default:
                Console.WriteLine("Такой комманды еще не придумали(");
                break;
        }
    }
}

async Task ClientCommands(Client client)
{
    while (true)
    {
        Console.WriteLine("1 - Передать сообщение");
        Console.WriteLine("0 - Закрыть клиент");

        if (!int.TryParse(Console.ReadLine(), out var cmd))
        {
            Console.WriteLine("Комманда не распознана. Повторите ввод.");
            continue;
        }

        switch (cmd)
        {
            case 1:
                Console.WriteLine("Введите сообщение:");
                await client.SendMessage(Console.ReadLine());
                break;
            case 0:
                Console.WriteLine("Закрываем клиент");
                client.Stop();
                return;
            default:
                Console.WriteLine("Такой комманды еще не придумали(");
                break;
        }
    }
}
