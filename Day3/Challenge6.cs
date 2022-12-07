using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamianRyse.AdventOfCode2022.Day3
{
    internal class Challenge6
    {
        List<Rucksack> _rucksacks;

        public Challenge6(List<Rucksack> rucksacks)
        {
            _rucksacks = rucksacks;
            Console.WriteLine($"Day 3/Challenge 6 => The sum of all badges priority is {SumUpPriorities()}");
        }

        public int SumUpPriorities()
        {
            int sum = 0;
            for (int i = 0; i < _rucksacks.Count; i += 3)
            {
                List<Rucksack> group = new();
                group.Add(_rucksacks[i]);
                group.Add(_rucksacks[i+1]);
                group.Add(_rucksacks[i+2]);

                char c = group[0].Inventory.Distinct().First(x => group.All(y => y.Inventory.Distinct().Contains(x)));
                sum += (c < 97 ? c - 38 : c - 96);
            }
            return sum;
        }
    }
}
