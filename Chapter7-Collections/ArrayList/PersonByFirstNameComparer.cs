using System.Collections;

namespace ArrayList
{
    internal class PersonByFirstNameComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x is Person person1 && y is Person person2)
            {
                return person1.FirstName.CompareTo(person2.FirstName);
            }
            return -1;
        }
    }
}
