using System.Collections;
using SystemArrayList = System.Collections.ArrayList;

namespace ArrayList
{
    internal class Person : IEnumerable, IComparable
    {
        #region ArrayList
        readonly SystemArrayList _children = new SystemArrayList();
        public int ChildrenCount => _children.Count;
        #endregion

        #region DataProps
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion

        #region Indexer
        public Person? this[int index] => (Person?)_children[index];
        #endregion

        #region IEnumerable
        public IEnumerator GetEnumerator()
        {
            return new PersonEnumerator(this);
        }
        #endregion

        #region IComparable
        public void SortChildren()
        {
            _children.Sort();
        }

        public void SortChildrenByFirstName()
        {
            _children.Sort(new PersonByFirstNameComparer());
        }

        public int CompareTo(object? other)
        {
            if (other is not Person person) return -1;

            int byLastName = LastName.CompareTo(person?.LastName);
            int byFirstName = FirstName.CompareTo(person?.FirstName);
            return byLastName != 0 ? byLastName : byFirstName;
        }
        #endregion

        #region DataMethods
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
        #endregion

        #region Object
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        #endregion
    }
}
