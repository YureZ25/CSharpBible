using System.Collections;

namespace ArrayList
{
    internal class PersonEnumerator : IEnumerator
    {
        int _currentIndex = -1;
        readonly Person _person;

        public PersonEnumerator(Person person)
        {
            _person = person;
        }

        public object? Current => _person[_currentIndex];

        public bool MoveNext()
        {
            _currentIndex++;
            if (_currentIndex >= _person.ChildrenCount)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }
}
