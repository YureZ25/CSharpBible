namespace Delegates
{
    internal class Person
    {
        private int _age;
        public string Name { get; set; }
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0) throw new ArgumentException("Возраст не может быть отрицательным");
                _age = value;
                // Вызов (Invoke) события, которое запустит подписанные обработчики
                if (AgeChanged != null) AgeChanged(this, EventArgs.Empty); // или AgeChanged?.Invoke(this, EventArgs.Empty)
            }
        }
        
        // Объявление события типа делегата
        public event EventHandler? AgeChanged;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
