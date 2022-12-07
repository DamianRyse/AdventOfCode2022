using System;
using DamianRyse.AdventOfCode2022;
using DamianRyse.AdventOfCode2022.Day1;
using static DamianRyse.AdventOfCode2022.Day1.Challenge1;

namespace DamianRyse.AdventOfCode2022
{
    public class AdventOfCode2022
    {
        public static void Main()
        {
            StartChallenge1();
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
    }
}
