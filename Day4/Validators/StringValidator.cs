using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day4.Validators
{
    public class StringValidator
    {
        public string Value { get; set; } = string.Empty;
        public char Begining { get; set; } = '\0';
        public Regex RegexPattern { get; set; } = null;
        public string[] Possibles { get; set; } = new string[] { };
        public int ExactLength { get; set; } = 0;

        public StringValidator(string value)
        {
            Value = value;
        }

        public bool Run()
        {
            bool isValid = true;

            if (Begining != '\0')
                isValid &= Value[0] == Begining;
            if (RegexPattern != null)
                isValid &= RegexPattern.Match(Value).Success;
            if (Possibles.Length > 0)
                isValid &= new List<string>(Possibles).Contains(Value);
            if (ExactLength > 0)
                isValid &= Value.Length == ExactLength;

            return isValid;
        }

    }
}