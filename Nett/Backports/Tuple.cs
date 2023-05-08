using System;
using System.Collections.Generic;

namespace Nett.Backports
{
    internal class Tuple<T1, T2> : IEquatable<Tuple<T1, T2>>
    {
        public T1 Item1 { get; }
        public T2 Item2 { get; }

        internal Tuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }

        public bool Equals(Tuple<T1, T2> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            return EqualityComparer<T1>.Default.Equals(Item1, other.Item1)
                   && EqualityComparer<T2>.Default.Equals(Item2, other.Item2);
        }

        public override bool Equals(object obj) 
            => obj is Tuple<T1, T2> tuple 
                   && Equals(tuple);

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T1>.Default.GetHashCode(Item1) * 397) ^
                       EqualityComparer<T2>.Default.GetHashCode(Item2);
            }
        }

        public static bool operator ==(Tuple<T1, T2> left, Tuple<T1, T2> right) 
            => Equals(left, right);

        public static bool operator !=(Tuple<T1, T2> left, Tuple<T1, T2> right) 
            => !Equals(left, right);
    }

    internal static class Tuple
    {
        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
            => new(item1, item2);
    }
}
