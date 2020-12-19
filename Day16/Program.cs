using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day16
{
    class Program
    {
        static void Main(string[] args)
        {
            InputGetter input = new InputGetter("input.txt");

            ProgramFramework framework = new ProgramFramework();
            framework.InputHandler = input.GetStringsFromInput;
            framework.Part1Handler = Part1;
            framework.Part2Handler = Part2;
            framework.RunProgram();
        }

        public static void Part1(string[] data)
        {
            RulesParser rules = new();
            TicketParser nearbyTickets = new();
            LoadRules(data, rules);
            Ticket myTicket = GetMyTicket(data);
            LoadNearbyTickets(data, nearbyTickets);

            int total = 0;
            foreach (Ticket ticket in nearbyTickets.Tickets)
            {
                (bool valid, int num) = ticket.IsValid(rules);
                if (!valid)
                    total += num;
            }

            Console.WriteLine($"Your ticket scanning error rate is: {total}.");
        }

        public static void Part2(string[] data)
        {
            RulesParser rules = new();
            TicketParser nearbyTickets = new();
            LoadRules(data, rules);
            Ticket myTicket = GetMyTicket(data);
            LoadNearbyTickets(data, nearbyTickets);

            List<Ticket> validTickets = new();
            foreach (Ticket ticket in nearbyTickets.Tickets)
            {
                (bool valid, int num) = ticket.IsValid(rules);
                if (valid)
                    validTickets.Add(ticket);
            }

            Dictionary<int, HashSet<string>> ruleMatches = new Dictionary<int, HashSet<string>>();
            for (int i = 0; i < validTickets[0].Numbers.Count; i++)
            {
                HashSet<string> possibleRules = rules.Rules.Select(r => r.Name).ToHashSet();
                foreach (Ticket validTicket in validTickets)
                {
                    HashSet<string> matchedRules = new();
                    matchedRules = validTicket.GetMatchedRules(i, rules);
                    possibleRules = possibleRules.Intersect(matchedRules).ToHashSet();
                }
                ruleMatches[i] = possibleRules;
            }

            var sortedMatches = ruleMatches.ToList();
            sortedMatches.Sort((a, b) => a.Value.Count.CompareTo(b.Value.Count));
            for (int i = 0; i < sortedMatches.Count; i++)
            {
                for (int j = i + 1; j < sortedMatches.Count; j++)
                {
                    sortedMatches[j].Value.ExceptWith(sortedMatches[i].Value);
                }
            }

            List<KeyValuePair<int, HashSet<string>>> departureMatches = new();
            foreach (var item in sortedMatches)
            {
                foreach (var thing in item.Value)
                {
                    if (thing.StartsWith("departure"))
                    {
                        departureMatches.Add(item);
                        continue;
                    }
                }
            }

            long total = 1;
            foreach (var item in departureMatches)
            {
                total = total * myTicket.Numbers[item.Key];
            }

            Console.WriteLine($"The product of the departure items is: {total}.");
        }

        private static void LoadRules(string[] data, RulesParser rules)
        {
            int ruleIndex = 0;
            do
            {
                rules.AddRule(data[ruleIndex]);
            } while (data[ruleIndex++] != "your ticket:");
        }

        private static Ticket GetMyTicket(string[] data)
        {
            int dataIndex = GetDataIndexOfSection(data, "your ticket:");
            Ticket myTicket = new Ticket
            {
                Numbers = new List<int>(Array.ConvertAll(data[dataIndex].Split(','), int.Parse))
            };
            return myTicket;
        }

        private static void LoadNearbyTickets(string[] data, TicketParser tickets)
        {
            int dataIndex = GetDataIndexOfSection(data, "nearby tickets:");
            do
            {
                tickets.AddTicket(data[dataIndex]);
            } while (++dataIndex < data.Length);
        }

        private static int GetDataIndexOfSection(string[] data, string section)
        {
            int index = 0;
            while (data[index++] != section) ;
            return index;
        }
    }
}
