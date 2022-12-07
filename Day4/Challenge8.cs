using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamianRyse.AdventOfCode2022.Day4
{
    internal class Challenge8
    {
        private List<ElfPair> _elfPairs;

        public Challenge8(IEnumerable<ElfPair> elfPairs)
        {
            _elfPairs = elfPairs.ToList();
            var overlappingPairs = FindOverlappingAssignments();
            Console.WriteLine($"Day 4/Challenge 8 => There are {overlappingPairs.Count} overlapping assignments.");
        }

        private List<ElfPair> FindOverlappingAssignments()
        {
            List<ElfPair> r = new();
            foreach (ElfPair elfPair in _elfPairs)
            {
                var elf1Range = Enumerable.Range(elfPair.Elf1Min, elfPair.Elf1Max - elfPair.Elf1Min + 1);
                var elf2Range = Enumerable.Range(elfPair.Elf2Min, elfPair.Elf2Max - elfPair.Elf2Min + 1);
                if (elf1Range.Any(x => elf2Range.Contains(x)))
                    r.Add(elfPair);
            }
            return r;
        }
    }
}
