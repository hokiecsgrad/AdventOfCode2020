using System;
using System.Collections.Generic;

namespace AdventOfCode.Day16
{
    public class Ticket
    {
        public List<int> Numbers { get; init; } = new();

        public int IsValid(RulesParser rules)
        {
            foreach (int num in Numbers)
            {
                bool matchAny = false;
                foreach (Rule rule in rules.Rules)
                {
                    if (num.IsWithin(rule.Lower.Min, rule.Lower.Max) ||
                        num.IsWithin(rule.Upper.Min, rule.Upper.Max))
                        matchAny = true;
                }
                if (!matchAny)
                    return num;
            }
            return 0;
        }
    }

    public class TicketParser
    {
        public List<Ticket> Tickets { get; private set; } = new();

        public void AddTicket(string ticket)
        {
            List<int> numbers = new List<int>(Array.ConvertAll(ticket.Split(','), int.Parse));
            Tickets.Add(new Ticket { Numbers = numbers });
        }
    }
}