using System.Reflection;

namespace CollectorRegistry.Server.Enum
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public int ID { get; private set; }

        protected Enumeration(int id, string name) => (ID, Name) = (id, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = ID.Equals(otherValue.ID);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object other) => ID.CompareTo(((Enumeration)other).ID);

        // Other utility methods ...
    }
}
