using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DamianRyse.AdventOfCode2022.Day1.Challenge1;


namespace DamianRyse.AdventOfCode2022.Day1
{
    internal class Challenge1
    {
        public Elf ElfWithMostCalores { get; private set; }
        public Elf[] AllElves { get; private set; }
        public Challenge1()
        {

        }
        public void Start(string input)
        {
            string[] itemsPerElf = input.Split(Environment.NewLine + Environment.NewLine);
            List<Elf> elfes= new List<Elf>();

            for (int i = 0; i < itemsPerElf.Length; i++) 
            { 
                string[] items = itemsPerElf[i].Split(Environment.NewLine);
                List<uint> calories = new();
                foreach (string item in items) 
                { 
                    if(uint.TryParse(item,out uint calorie))
                        calories.Add(calorie);
                }
                elfes.Add(new(i, calories));
            }

            //elfes.ForEach(e => { Console.WriteLine($"{e.ID} carries {e.ItemCount} items with a total of {e.SumCalories} calories."); });
            ElfWithMostCalores = elfes.OrderByDescending(elf=>elf.SumCalories).Take(1).First();
            AllElves = elfes.ToArray();
            
            Console.WriteLine($"Day1/Challenge 1 => Elf {ElfWithMostCalores.ID} has the most calories: {ElfWithMostCalores.SumCalories}");
            
        }

        internal class Elf
        {
            public int ID { get; }
            public List<uint> CarriedCalories { get; }
            public long SumCalories { get { return CarriedCalories.Sum(x => x); } }
            public int ItemCount { get { return CarriedCalories.Count; } }

            public Elf(int id, IEnumerable<uint> calories)
            {
                ID = id;
                CarriedCalories = new();
                CarriedCalories.AddRange(calories);
            }
        }

    }
    internal class Challenge2
    {
        private List<Challenge1.Elf> Elfes;
        public Challenge2(IEnumerable<Challenge1.Elf> elfes)
        {
            Elfes = elfes.ToList();
        }
        public void Start()
        {
            Challenge1.Elf[] top3 = Elfes.OrderByDescending(elf => elf.SumCalories).Take(3).ToArray();
            Console.WriteLine($"Day1/Challenge 2 => Total calories of the top 3: {top3.Sum(elf=>elf.SumCalories)}");
        }

    }
}
