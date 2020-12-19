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
            string[] input = sampleInput.Split(Environment.NewLine,
                            StringSplitOptions.TrimEntries |
                            StringSplitOptions.RemoveEmptyEntries
                            );

            RulesParser rules = new();
            int ruleIndex = 0;
            do
            {
                rules.AddRule(input[ruleIndex]);
            } while (input[ruleIndex++] != "your ticket:");

            while (input[ruleIndex++] != "nearby tickets:") ;

            TicketParser tickets = new();
            do
            {
                tickets.AddTicket(input[ruleIndex]);
            } while (++ruleIndex < input.Length);

            int total = 0;
            foreach (Ticket ticket in tickets.Tickets)
            {
                int invalidNumber = ticket.IsValid(rules);
                total += invalidNumber;
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
            int ruleIndex = 0;
            do
            {
                rules.AddRule(data[ruleIndex]);
            } while (data[ruleIndex++] != "your ticket:");

            Ticket myTicket = new Ticket
            {
                Numbers = new List<int>(Array.ConvertAll(data[ruleIndex].Split(','), int.Parse))
            };

            while (data[ruleIndex++] != "nearby tickets:") ;

            TicketParser nearbyTickets = new();
            do
            {
                nearbyTickets.AddTicket(data[ruleIndex]);
            } while (++ruleIndex < data.Length);

            List<Ticket> validTickets = new();
            foreach (Ticket ticket in nearbyTickets.Tickets)
            {
                if (ticket.IsValid(rules) == 0)
                    validTickets.Add(ticket);
            }
        }
    }
}
