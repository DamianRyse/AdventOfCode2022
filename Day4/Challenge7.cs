using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamianRyse.AdventOfCode2022.Day4
{
    internal class Challenge7
    {
        private List<ElfPair> elfPairs;
        public List<ElfPair> ElfPairs { get { return elfPairs; } }

        public Challenge7(string input)
        {
            elfPairs = ParseSectionAssignments(input);
            Console.WriteLine($"Day 4/Challenge 7 => There are {FindFullyOverlappingAssignments().Count} fully overlapping assignments.");
        }

        private List<ElfPair> ParseSectionAssignments(string input)
        {
            List<ElfPair> r = new();
            string[] lines= input.Split(Environment.NewLine);
            foreach(string line in lines)
            {
                ElfPair elfPair = new ElfPair();
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
            foreach(ElfPair elfPair in elfPairs)
            {
                if(elfPair.Elf1Min <= elfPair.Elf2Min && elfPair.Elf1Max >= elfPair.Elf2Max)        // Elf 1 fully overlapping Elf 2
                {
                    r.Add(elfPair);
                }
                else if (elfPair.Elf2Min <= elfPair.Elf1Min && elfPair.Elf2Max >= elfPair.Elf1Max)  // Elf 2 fully overlapping Elf 1
                {
                    r.Add(elfPair);
                }
            }
            return r;
        }
    }

    public struct ElfPair
    {
        public int Elf1Min, Elf1Max;
        public int Elf2Min, Elf2Max;
    }
}
