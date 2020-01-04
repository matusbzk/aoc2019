using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019.Common
{
    public static class VariousExtensions
    {
        public static T[] GetEnumValues<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("GetValues<T> can only be called for types derived from System.Enum", "T");
            }
            return (T[])Enum.GetValues(typeof(T));
        }

        public static T GetRandomElement<T>(this IEnumerable<T> enumerable)
        {
            var enumerableArr = enumerable as T[] ?? enumerable.ToArray();
            var count = enumerableArr.Count();
            return enumerableArr.ElementAt(new Random().Next(count));
        }

        public static Stack<T> PushAndReturn<T>(this Stack<T> stack, T item)
        {
            stack.Push(item);
            return stack;
        }
    }
}
