using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Common;
using AdventOfCode.Day16;

namespace tests
{
    public class Day16Tests
    {
        [Fact]
        public void Part1_WithSampleInput_ShouldReturn71()
        {
            string sampleInput = @"class: 1-3 or 5-7
                row: 6-11 or 33-44
                seat: 13-40 or 45-50

                your ticket:
                7,1,14

                nearby tickets:
                7,3,47
                40,4,50
                55,2,20
                38,6,12";
            string[] data = sampleInput.Split(Environment.NewLine,
                            StringSplitOptions.TrimEntries |
                            StringSplitOptions.RemoveEmptyEntries
                            );

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

            Assert.Equal(71, total);
        }

        [Fact]
        public void Part2_WithSampleInput_ShouldReturn()
        {
            string sampleInput = @"class: 0-1 or 4-19
                row: 0-5 or 8-19
                seat: 0-13 or 16-19

                your ticket:
                11,12,13

                nearby tickets:
                3,9,18
                15,1,5
                5,14,9";
            string[] data = sampleInput.Split(Environment.NewLine,
                            StringSplitOptions.TrimEntries |
                            StringSplitOptions.RemoveEmptyEntries
                            );

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

            Assert.Single(sortedMatches[0].Value);
            Assert.Contains("row", sortedMatches[0].Value);
            Assert.Single(sortedMatches[1].Value);
            Assert.Contains("class", sortedMatches[1].Value);
            Assert.Single(sortedMatches[2].Value);
            Assert.Contains("seat", sortedMatches[2].Value);
        }

        private void LoadRules(string[] data, RulesParser rules)
        {
            int ruleIndex = 0;
            do
            {
                rules.AddRule(data[ruleIndex]);
            } while (data[ruleIndex++] != "your ticket:");
        }

        private Ticket GetMyTicket(string[] data)
        {
            int dataIndex = GetDataIndexOfSection(data, "your ticket:");
            Ticket myTicket = new Ticket
            {
                Numbers = new List<int>(Array.ConvertAll(data[dataIndex].Split(','), int.Parse))
            };
            return myTicket;
        }

        private void LoadNearbyTickets(string[] data, TicketParser tickets)
        {
            int dataIndex = GetDataIndexOfSection(data, "nearby tickets:");
            do
            {
                tickets.AddTicket(data[dataIndex]);
            } while (++dataIndex < data.Length);
        }

        private int GetDataIndexOfSection(string[] data, string section)
        {
            int index = 0;
            while (data[index++] != section) ;
            return index;
        }

    }
}
