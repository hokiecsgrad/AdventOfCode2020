using System;
using System.Collections.Generic;
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
            int ruleIndex = 0;
            do
            {
                rules.AddRule(data[ruleIndex]);
            } while (data[ruleIndex++] != "your ticket:");

            while (data[ruleIndex++] != "nearby tickets:") ;

            TicketParser tickets = new();
            do
            {
                tickets.AddTicket(data[ruleIndex]);
            } while (++ruleIndex < data.Length);

            int total = 0;
            foreach (Ticket ticket in tickets.Tickets)
            {
                int invalidNumber = ticket.IsValid(rules);
                total += invalidNumber;
            }

            Console.WriteLine($"Your ticket scanning error rate is: {total}.");
        }

        public static void Part2(string[] data)
        {
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
