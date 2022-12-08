namespace DamianRyse.AdventOfCode2022.Day4;

internal class Challenge7
{
    public Challenge7(string input)
    {
        ElfPairs = ParseSectionAssignments(input);
        Console.WriteLine(
            $"Day 4/Challenge 7 => There are {FindFullyOverlappingAssignments().Count} fully overlapping assignments.");
    }

    public List<ElfPair> ElfPairs { get; }

    private List<ElfPair> ParseSectionAssignments(string input)
    {
        List<ElfPair> r = new();
        var lines = input.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            var elfPair = new ElfPair();
            elfPair.Elf1Min = int.Parse(line.Split(',').First().Split('-').First());
            elfPair.Elf1Max = int.Parse(line.Split(',').First().Split('-').Last());
            elfPair.Elf2Min = int.Parse(line.Split(',').Last().Split('-').First());
            elfPair.Elf2Max = int.Parse(line.Split(',').Last().Split('-').Last());
            r.Add(elfPair);
        }

        return r;
    }

    private List<ElfPair> FindFullyOverlappingAssignments()
    {
        List<ElfPair> r = new();
        foreach (var elfPair in ElfPairs)
            if (elfPair.Elf1Min <= elfPair.Elf2Min &&
                elfPair.Elf1Max >= elfPair.Elf2Max) // Elf 1 fully overlapping Elf 2
                r.Add(elfPair);
            else if (elfPair.Elf2Min <= elfPair.Elf1Min &&
                     elfPair.Elf2Max >= elfPair.Elf1Max) // Elf 2 fully overlapping Elf 1
                r.Add(elfPair);
        return r;
    }
}

public struct ElfPair
{
    public int Elf1Min, Elf1Max;
    public int Elf2Min, Elf2Max;
}