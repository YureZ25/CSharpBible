namespace CustomDelegates
{
    internal class Person
    {
        public delegate void NameChanged(Person person, NameChangedEventArgs args);

        public event NameChanged? FirstNameChanged;
        public event NameChanged? LastNameChanged;
        public event EventHandler? AgeChanged;

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (FirstNameChanged != null)
                {
                    var args = new NameChangedEventArgs(value, NameChangedEventArgs.NameChangingKind.FirstName);
                    FirstNameChanged(this, args);
                    if (args.IsCanceled) return;
                }
                _firstName = value;
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                if (LastNameChanged != null)
                {
                    var args = new NameChangedEventArgs(value, NameChangedEventArgs.NameChangingKind.LastName);
                    LastNameChanged.Invoke(this, args);
                    if (args.IsCanceled) return;
                }
                _lastName = value; 
            }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set 
            { 
                _age = value; 
                AgeChanged?.Invoke(this, EventArgs.Empty);
            }
        }


        public Person(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Age}";
        }
    }
}
