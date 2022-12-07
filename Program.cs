using DamianRyse.AdventOfCode2022.Day4;

namespace DamianRyse.AdventOfCode2022
{
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
            string inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),"Day1_Input.txt"));

            var challenge = new Day1.Challenge1();
            challenge.Start(inputText);

            StartChallenge2(challenge.AllElves);
        }
        private static void StartChallenge2(IEnumerable< Day1.Challenge1.Elf> elfes) 
        {
            var challenge = new Day1.Challenge2(elfes); 
            challenge.Start();
        }

        private static void StartChallenge3()
        {
            string inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Day2_Input.txt"));
            var challenge = new Day2.Challenge3(inputText);
            
        }
        private static void StartChallenge4()
        {
            string inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Day2_Input.txt"));
            var challenge = new Day2.Challenge4(inputText);

        }
        private static void StartChallenge5()
        {
            string inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Day3_Input.txt"));
            var challenge = new Day3.Challenge5(inputText);

            StartChallenge6(challenge.Rucksacks);
        }

        private static void StartChallenge6(IEnumerable<Day3.Rucksack> challenge5Rucksacks)
        {
            var challenge = new Day3.Challenge6(challenge5Rucksacks.ToList());
        }

        private static void StartChallenge7()
        {
            string inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Day4_Input.txt"));
            var challenge = new Day4.Challenge7(inputText);

            StartChallenge8(challenge.ElfPairs);
        }
        private static void StartChallenge8(IEnumerable<ElfPair> challenge8ElfPairs)
        {
            string inputText = File.ReadAllText(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Day4_Input.txt"));
            var challenge = new Day4.Challenge8(challenge8ElfPairs);
        }
    }
}
