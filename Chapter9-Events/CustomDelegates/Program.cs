using CustomDelegates;

var me = new Person("Yura", "Nik", 24);

Console.WriteLine(me);

me.FirstNameChanged += new Person.NameChanged(NameChangeHandler);
me.LastNameChanged += NameChangeHandler;
me.AgeChanged += delegate (object? sender, EventArgs args)
{
	if (sender is Person person)
	{
        Console.WriteLine($"Возраст был изменен на {person.Age}");
    }
};

Console.WriteLine("Введите новое имя");
me.FirstName = Console.ReadLine() ?? string.Empty;

Console.WriteLine("Введите новую фамилию");
me.LastName = Console.ReadLine() ?? string.Empty;

Console.WriteLine("Введите новый возраст");
me.Age = Convert.ToInt32(Console.ReadLine());

Console.WriteLine(me);

void NameChangeHandler(Person person, NameChangedEventArgs args)
{
	switch (args.ChangingKind)
	{
		case NameChangedEventArgs.NameChangingKind.FirstName:
            Console.WriteLine($"Подтверждаете изменение имени с {person.FirstName} на {args.NewName}? (y/n)");
            break;
		case NameChangedEventArgs.NameChangingKind.LastName:
            Console.WriteLine($"Подтверждаете изменение фамилии с {person.LastName} на {args.NewName}? (y/n)");
            break;
		default:
			throw new NotImplementedException();
	}

	var input = Console.ReadLine();
	if (input == "y")
	{
		args.IsCanceled = false;
	}
	else if (input == "n")
	{
		args.IsCanceled = true;
	}
	else
	{
		Console.WriteLine("Введенное значение не распознано. Изменение отменено.");
        args.IsCanceled = true;
    }
}