using Delegates;

Person me = new Person("Yura", 25);

me.AgeChanged += ShowAgeChanged;
me.AgeChanged += new EventHandler(ShowAgeChanged);

me.Age++;


void ShowAgeChanged(object? sender, EventArgs e)
{
    if (sender is Person person)
    {
        Console.WriteLine($"Возраст {person.Name} изменился на {person.Age}");
    }
}
