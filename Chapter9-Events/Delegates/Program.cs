using Delegates;

Person me = new Person("Yura", 25);

// Два способа подписать обработчик на событие
me.AgeChanged += ShowAgeChanged;
me.AgeChanged += new EventHandler(ShowAgeChanged);

me.Age++; // Изменение возраста, которое повлечет за собой вызов

// Метод - Обработчик
void ShowAgeChanged(object? sender, EventArgs e)
{
    if (sender is Person person)
    {
        Console.WriteLine($"Возраст {person.Name} изменился на {person.Age}");
    }
}
