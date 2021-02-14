using System;
using System.Collections.Generic;
using System.Text;

namespace csharp30
{
    class Country
    {
        public string Name { get; set; }
        public readonly int Id;
        public static int Count = 0;
        public int Population;
        public City[] cities;

        public Country()
        {
            Count++;
            Id = Count;
            cities = new City[0];
        }
        public Country(string name,int population) : this()
        {

            Name = name;
            Population = population;
          
        }
        public override string ToString()
        {
            return Name;
        }
        public void Addcity(City city)
        {
            Array.Resize(ref cities, cities.Length + 1);
            cities[cities.Length - 1] = city;
            Helper.Print(ConsoleColor.Green, $"{city.Name} adli seher {Name} olkeye elave olundu.");
        }
        public void DeleteCity(City city)
        {
            City[] yenicity = new City[0];
            foreach (City item in cities)
            {
                if (item == city)
                {
                    Array.Resize(ref yenicity, yenicity.Length + 1);
                    yenicity[yenicity.Length - 1] = city;
                    cities=yenicity;
                }
               
            }
           
        }
        public void Showcity()
        {
            Helper.Print(ConsoleColor.Blue, $"{Name} olkesinde seherlerin siyahisi:");
            foreach (City item in cities)
            {
                Console.WriteLine(item);
            }
        }
        public City [] Search(string name)
        {
            City[] capital = new City[0];
            foreach (City item in cities)
            {
                if (name.ToLower() ==item.Name.ToLower())
                {
                    Array.Resize(ref capital, capital.Length + 1);
                    capital[capital.Length - 1] = item;
                }
            }
            return capital;
          
        }
    }
}
