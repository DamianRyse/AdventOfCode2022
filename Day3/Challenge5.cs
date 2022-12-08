namespace DamianRyse.AdventOfCode2022.Day3;

internal class Challenge5
{
    public Challenge5(string rucksackContents)
    {
        Rucksacks = ParseRucksackContent(rucksackContents);
        var allPriorityPoints = SumUpPriorityPoints();
        Console.WriteLine("Day 3/Challenge 5 => Priority points: " + allPriorityPoints);
    }

    public List<Rucksack> Rucksacks { get; }

    private List<Rucksack> ParseRucksackContent(string input)
    {
        List<Rucksack> r = new();
        var rucksacks = input.Split(Environment.NewLine);
        foreach (var rucksackContent in rucksacks)
        {
            if (rucksackContent.Length % 2 != 0)
                continue;

            var half = rucksackContent.Length / 2;
            var newRucksack = new Rucksack();
            newRucksack.FirstCompartment = rucksackContent.Substring(0, half).ToCharArray();
            newRucksack.SecondCompartment = rucksackContent.Substring(half, half).ToCharArray();
            r.Add(newRucksack);
        }

        return r;
    }

    private int SumUpPriorityPoints()
    {
        var sum = 0;
        foreach (var rucksack in Rucksacks)
        {
            var c = GetCharInBothCompartments(rucksack);
            sum += c < 97 ? c - 38 : c - 96;
        }

        return sum;
    }

    private char GetCharInBothCompartments(Rucksack rucksack)
    {
        return rucksack.FirstCompartment.Distinct().First(x => rucksack.SecondCompartment.Distinct().Contains(x));
    }
}

public struct Rucksack
{
    public char[] FirstCompartment;
    public char[] SecondCompartment;
    public char[] Inventory => FirstCompartment.Concat(SecondCompartment).ToArray();
}