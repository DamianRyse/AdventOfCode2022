namespace DamianRyse.AdventOfCode2022.Day1;

internal class Challenge1
{
    public Elf ElfWithMostCalores { get; private set; }
    public Elf[] AllElves { get; private set; }

    public void Start(string input)
    {
        var itemsPerElf = input.Split(Environment.NewLine + Environment.NewLine);
        var elfes = new List<Elf>();

        for (var i = 0; i < itemsPerElf.Length; i++)
        {
            var items = itemsPerElf[i].Split(Environment.NewLine);
            List<uint> calories = new();
            foreach (var item in items)
                if (uint.TryParse(item, out var calorie))
                    calories.Add(calorie);
            elfes.Add(new Elf(i, calories));
        }

        //elfes.ForEach(e => { Console.WriteLine($"{e.ID} carries {e.ItemCount} items with a total of {e.SumCalories} calories."); });
        ElfWithMostCalores = elfes.OrderByDescending(elf => elf.SumCalories).Take(1).First();
        AllElves = elfes.ToArray();

        Console.WriteLine(
            $"Day 1/Challenge 1 => Elf {ElfWithMostCalores.ID} has the most calories: {ElfWithMostCalores.SumCalories}");
    }

    internal class Elf
    {
        public Elf(int id, IEnumerable<uint> calories)
        {
            ID = id;
            CarriedCalories = new List<uint>();
            CarriedCalories.AddRange(calories);
        }

        public int ID { get; }
        public List<uint> CarriedCalories { get; }

        public long SumCalories
        {
            get { return CarriedCalories.Sum(x => x); }
        }

        public int ItemCount => CarriedCalories.Count;
    }
}