using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie3
{
    public class CollectionChecker
    {
        private const int Minimum = 5;

        public static IEnumerable<IEnumerable<string>> OnlyBigCollections(List<IEnumerable<string>> toFilter)
        {
            Func<IEnumerable<string>, bool> predicate = list =>
            {
                var current = 0;

                foreach (var obj in list)
                {
                    current++;
                    if (current == Minimum)
                    {
                        return true;
                    }
                }

                return false;
            };

            return toFilter.Where(predicate);
        }
    }
}