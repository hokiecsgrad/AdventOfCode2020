using System;
using System.Linq;

namespace AdventOfCode.Day2
{
    public class PasswordValidator
    {
        private RuleParser Rules;
        private string Password = String.Empty;

        public PasswordValidator(RuleParser rules, string password)
        {
            Rules = rules;
            Password = password;
        }

        public bool IsPart1Valid()
        {
            int numPatterns = GetNumberOfPatterns(Rules.Pattern);
            if (numPatterns >= Rules.Min && numPatterns <= Rules.Max)
                return true;

            return false;
        }

        private int GetNumberOfPatterns(char pattern)
        {
            return Password.ToCharArray().Count(c => c == pattern);
        }

        public bool IsPart2Valid()
        {
            if ( 
                (Password[Rules.Min + 1] == Rules.Pattern || Password[Rules.Max + 1] == Rules.Pattern) 
                && Password[Rules.Min + 1] != Password[Rules.Max + 1] 
               )
                return true;
            
            return false;
        }
    }
}