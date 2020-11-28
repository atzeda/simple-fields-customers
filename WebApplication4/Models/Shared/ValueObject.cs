using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models.Shared
{
    public abstract class ValueObject
    {
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }
    }
}
