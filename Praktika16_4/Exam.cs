using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Praktika16_4
{
    public class Exam
    {
        static Queue<Countries> myQueue = new Queue<Countries>();
        public static void NumberOfCountries(string n)
        {
            StreamReader sr = new StreamReader("Region.txt");
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] lines = line.Split(' ');
                if (examination(lines[0], lines[1],n) == true)
                {

                    Countries countrie = new Countries();
                    countrie.countrie = lines[0];
                    countrie.population = int.Parse(lines[1]);
                    myQueue.Enqueue(countrie);
                }
                else
                {
                    Console.WriteLine("Ошибка");
                    return;
                }
            }
            sr.Close();
            IEnumerable<Countries> countries = myQueue.OrderBy(x => x.countrie.Length).ThenBy(x => x.countrie).Where(x=>x.population>int.Parse(n));
            foreach (var item in countries)
            {
                Console.WriteLine($"{item.countrie} {item.population}");
            }
            
        }
        public static bool examination(string countrie,string population,string n)
        {
            for (int i = 0; i < countrie.Length; i++)
            {
                if (char.IsDigit(countrie[i]))
                {
                    return false;
                }
            }
            for (int i = 0; i < population.Length; i++)
            {
                if(char.IsLetter(population[i]))
                {
                    return false;
                }
            }
            try
            {
                int.Parse(n);
                return true;
            }
            catch
            {

                return false;
            }
            return true;
        }
    }
}
