using System;

namespace csharp30
{
    class Program
    {
        public enum Choose
        {
            CreateCountry=1,Createcity,Citylist,Searchbyname,Deletecity,Exit,Comeback
        }
        static void Main(string[] args)
        {
        //    arrayden silmeyi dememisen axiii ?( hmm?birdene problem odurki men seherler listine gedib cixa bilmirem deye sile de bilmiremm bide nece silim seheri)
            Country[] countries = new Country[0];
            bool isNumber;
            while (true)
            {
                Helper.Print(ConsoleColor.Green, "Olke yarat - 1; Seher yarat - 2; olkelerin siyahisi - 3;" +
                   "Ada gore axtarish seherler uzre - 4; Sheher silmek - 5;Cixis-6;Evveleqayit-7");
                string operation = Console.ReadLine();
                int num;
                bool Isnumber=int.TryParse(operation,out num);
                if (Isnumber)
                {
                    if (num==6)
                    {
                        Helper.Print(ConsoleColor.Yellow, "Deyerli istifadeci,Sistemden istifade etdiyiniz ucun tesekkurler");
                        break;
                    }
                    switch (num)
                    {
                        
                        case(int)Choose.CreateCountry:
                            Helper.Print(ConsoleColor.Blue, "Deyerli istifadeci,Olke adini daxil edin");//olke adi isteyirem
                            string cname = Console.ReadLine().Trim(); //yoxlayim ki bosluq ile gondermesin
                            int num2;
                            bool num1 = int.TryParse(cname,out num2);

                            if (num2==(int)Choose.Comeback)
                            {
                                break;
                            }
                            // olke adinin bos olub olmamagi yoxlayiram
                            if (String.IsNullOrEmpty(cname))
                            {
                                Helper.Print(ConsoleColor.Red, "Deyerli istifadeci,Xahis edirik olke adini duzgun daxil edin");
                                goto case (int)Choose.CreateCountry;
                            }
                            if (num2 == (int)Choose.Comeback)
                            {
                                break;
                            }
                            //eyni adli ikinci olke yarada bilmesin
                            foreach (Country item in countries)
                            {
                                if (item.Name.ToLower()==cname.ToLower())
                                {
                                    Helper.Print(ConsoleColor.Red, $"{cname} adli olke artiq movcuddur");
                                    goto case (int)Choose.CreateCountry;
                                }
                            }
                             MaxCount:
                            Helper.Print(ConsoleColor.Green, "Deyerli istifadeci,Population sayini daxil edin:");
                            string pop= Console.ReadLine();
                            int maxCount;
                            isNumber = int.TryParse(pop, out maxCount);
                            if (!isNumber)
                            {
                                Helper.Print(ConsoleColor.Red, "Deyerli istifadeci,Eded daxil edin!!!");
                                goto MaxCount;
                            }
                            Country country = new Country(cname,maxCount);
                            Array.Resize(ref countries, countries.Length + 1);
                            countries[countries.Length - 1] = country;
                            Helper.Print(ConsoleColor.Green, $"Deyerli istifadeci,{cname} adli olke yaradildi");
                            break;
                            if (num2 == (int)Choose.Comeback)
                            {
                                break;
                            }
                        case (int)Choose.Createcity:

                            Helper.Print(ConsoleColor.Blue, "Deyerli istifadeci,Seher adini daxil edin");
                            string cityname = Console.ReadLine().Trim();
                            int num4;
                            bool num3 = int.TryParse(cityname, out num4);

                            if (num4 == (int)Choose.Comeback)
                            {
                                break;
                            }
                            if (String.IsNullOrEmpty(cityname))
                            {
                                Helper.Print(ConsoleColor.Red, "Xahis edirik seher adini duzgun daxil edin");
                                goto case (int)Choose.Createcity;
                            }
                        MaxCount2:
                            Helper.Print(ConsoleColor.Green, "Deyerli istifadeci,Population sayini daxil edin:");
                            string pop2 = Console.ReadLine();
                            int maxCount2;
                            isNumber = int.TryParse(pop2, out maxCount2);
                            if (!isNumber)
                            {
                                Helper.Print(ConsoleColor.Red, "Deyerli istifadeci,Eded daxil edin!!!");
                                goto MaxCount2;
                            }
                        A1:
                            Helper.Print(ConsoleColor.Blue, "Deyerli istifadeci,Sistemde olan olkelerden birini sechin");
                            foreach (Country item in countries)
                            {
                                Console.WriteLine(item);
                            }
                            
                            //seher yaratmaq
                            City newcity = new City(cityname,maxCount2);
                            string choosename = Console.ReadLine().Trim();
                            int num6;
                            bool num5 = int.TryParse(choosename, out num6);

                            if (num6== (int)Choose.Comeback)
                            {
                                break;
                            }
                            bool Test = false;
                            foreach (Country item in countries)
                            {
                                if (item.Name.ToLower() == choosename.ToLower())
                                {
                                    Test = true;
                                    item.Addcity(newcity);
                                    break;
                                }
                            
                            }
                            if (!Test)
                            {
                                Helper.Print(ConsoleColor.Red, "seher adini duzgun daxil edin!!!");
                                goto A1;
                            }
                            break;
                        case (int)Choose.Citylist:
                            
                            foreach (Country item in countries)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case(int) Choose.Searchbyname:
                            Helper.Print(ConsoleColor.Green, "Deyerli istifadeci,Axtardiginiz seher adini daxil edin:");
                            string searchName = Console.ReadLine();
                            if (String.IsNullOrEmpty(searchName))
                            {
                                Helper.Print(ConsoleColor.Red, " Deyerli istifadeci,Duzgun daxil edin!!!");
                                goto case (int)Choose.Searchbyname;
                            }
                            foreach (Country item in countries )
                            {
                                foreach (City ct in item.Search(searchName))
                                {
                                    Helper.Print(ConsoleColor.Green, $" Deyerli istifadeci,{ct} adli seher {item} adli olkeye mexsusdur");
                                }
                            }
                            break;
                        case(int) Choose.Deletecity:
                            Helper.Print(ConsoleColor.Green, " Deyerli istifadeci,silmek istediyiniz seher adini daxil edin:");
                            string deleteName = Console.ReadLine();
                            if (String.IsNullOrEmpty(deleteName))
                            {
                                Helper.Print(ConsoleColor.Red, "Deyerli istifadeci,Duzgun daxil edin!!!");
                                goto case (int)Choose.Deletecity;
                            }
                            else
                            {
                               
                                Console.WriteLine($" Deyerli istifadeci, {deleteName} adli seher  silinmisdir");
                            }
                            //foreach (Country item in countries)
                            //{
                            //    foreach (City gr in item.Search(deleteName))
                            //    {
                            //        Console.WriteLine(gr);
                            //    }
                            //}
                            break;
                        case(int) Choose.Exit:
                            break;
                            
                        default:
                            Console.WriteLine(" Deyerli istifadeci sistemde olan reqemlerden istifade edin..");
                            break;
                    }
                }

            }
        }
    }
}
