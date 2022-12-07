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
            
            Console.WriteLine($"Day 1/Challenge 1 => Elf {ElfWithMostCalores.ID} has the most calories: {ElfWithMostCalores.SumCalories}");
            
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

}
