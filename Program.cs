using System.Reflection;
using DamianRyse.AdventOfCode2022.Day1;
using DamianRyse.AdventOfCode2022.Day2;
using DamianRyse.AdventOfCode2022.Day3;
using DamianRyse.AdventOfCode2022.Day4;

namespace DamianRyse.AdventOfCode2022;

public class AdventOfCode2022
{
    public static void Main()
    {
        StartChallenge1();
        // Challenge2 started by challenge 1
        StartChallenge3();
        StartChallenge4();
        StartChallenge5();
        // Challenge 6 started by challenge 5
        StartChallenge7();
        // Challenge 8 started by challenge 7
    }

    private static void StartChallenge1()
    {
        var inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Day1_Input.txt"));

        var challenge = new Challenge1();
        challenge.Start(inputText);

        StartChallenge2(challenge.AllElves);
    }

    private static void StartChallenge2(IEnumerable<Challenge1.Elf> elfes)
    {
        var challenge = new Challenge2(elfes);
        challenge.Start();
    }

    private static void StartChallenge3()
    {
        var inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Day2_Input.txt"));
        var challenge = new Challenge3(inputText);
    }

    private static void StartChallenge4()
    {
        var inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Day2_Input.txt"));
        var challenge = new Challenge4(inputText);
    }

    private static void StartChallenge5()
    {
        var inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Day3_Input.txt"));
        var challenge = new Challenge5(inputText);

        StartChallenge6(challenge.Rucksacks);
    }

    private static void StartChallenge6(IEnumerable<Rucksack> challenge5Rucksacks)
    {
        var challenge = new Challenge6(challenge5Rucksacks.ToList());
    }

    private static void StartChallenge7()
    {
        var inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Day4_Input.txt"));
        var challenge = new Challenge7(inputText);

        StartChallenge8(challenge.ElfPairs);
    }

    private static void StartChallenge8(IEnumerable<ElfPair> challenge8ElfPairs)
    {
        var inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Day4_Input.txt"));
        var challenge = new Challenge8(challenge8ElfPairs);
    }
}