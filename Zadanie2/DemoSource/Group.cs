using System.Collections.Generic;

namespace Zadanie2.DemoSource
{
    public class Group
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}