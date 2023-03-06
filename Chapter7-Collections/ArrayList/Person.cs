using SystemArrayList = System.Collections.ArrayList;

namespace ArrayList
{
    internal class Person
    {
        readonly SystemArrayList _children = new SystemArrayList();
        public int ChildrenCount => _children.Count;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person? this[int index] => (Person?)_children[index];

        public Person? GetChild(int index)
        {
            if (index >= 0 && index < _children.Count)
            {
                return (Person?)_children[index];
            }
            return null;
        }

        public void AddChild(string firstName, string lastName)
        {
            _children.Add(new Person(firstName, lastName));
        }

        public void DeleteChild(int index)
        {
            if (index >= 0 && index < _children.Count)
            {
                _children.RemoveAt(index);
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
