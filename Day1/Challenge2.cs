namespace DamianRyse.AdventOfCode2022.Day1;

internal class Challenge2
{
    private readonly List<Challenge1.Elf> Elfes;

    public Challenge2(IEnumerable<Challenge1.Elf> elfes)
    {
        Elfes = elfes.ToList();
    }

    public void Start()
    {
        var top3 = Elfes.OrderByDescending(elf => elf.SumCalories).Take(3).ToArray();
        Console.WriteLine($"Day 1/Challenge 2 => Total calories of the top 3: {top3.Sum(elf => elf.SumCalories)}");
    }
}