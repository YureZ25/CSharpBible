namespace Views.ViewModels
{
    // Модели предствалений - это классы с данными (без логики, максимум валидационная)
    // Для передачи представлениям или из них в приложение (аналог DTO в API)

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
