using System;
using System.Collections.Generic;
using System.Text;

namespace csharp30
{
    class City
    {
        public string Name { get; set; }
        public readonly int Id;
        public static int Count = 0;
        public int Population;

        public City()
        {
         Count++;
         Id = Count;
        }
        public City(string name,int population):this()
        {
            Name = name;
            Population = population;
            
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
