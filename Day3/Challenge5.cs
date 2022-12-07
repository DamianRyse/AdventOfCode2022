using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamianRyse.AdventOfCode2022.Day3
{
    internal class Challenge5
    {
        private List<Rucksack> _rucksacks;
        public List<Rucksack> Rucksacks { get { return _rucksacks; } }

        public Challenge5(string rucksackContents) 
        {
            _rucksacks = ParseRucksackContent(rucksackContents);
            int allPriorityPoints = SumUpPriorityPoints();
            Console.WriteLine("Day 3/Challenge 5 => Priority points: " + allPriorityPoints);
        }

        private List<Rucksack> ParseRucksackContent(string input)
        {
            List<Rucksack> r = new();
            string[] rucksacks = input.Split(Environment.NewLine);
            foreach(string rucksackContent in rucksacks)
            {
                if (rucksackContent.Length % 2 != 0)
                    continue;

                int half = rucksackContent.Length / 2;
                Rucksack newRucksack = new Rucksack();
                newRucksack.FirstCompartment = rucksackContent.Substring(0,half).ToCharArray();
                newRucksack.SecondCompartment = rucksackContent.Substring(half,half).ToCharArray();
                r.Add(newRucksack);
            }

            return r;
        }

        private int SumUpPriorityPoints()
        {
            int sum = 0;
            foreach (var rucksack in _rucksacks)
            {
                char c = GetCharInBothCompartments(rucksack);
                sum += (c < 97 ? c - 38 : c - 96);
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

}
