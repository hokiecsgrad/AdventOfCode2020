using System;
using Xunit;
using AdventOfCode.Day2;


namespace tests
{
    public class Day2Tests
    {
        [Fact]
        public void CountValidPasswords_WithDefaultInput_ShouldReturn2()
        {
            string[] input = new string[] {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };
            int total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string raw = input[i];
                RuleParser ruleParser = new RuleParser();
                ruleParser.ParseRules(raw.Substring(0, raw.IndexOf(':')));
                PasswordValidator passValidator = new PasswordValidator(ruleParser, raw.Substring(raw.IndexOf(':')));
                if (passValidator.IsPart1Valid())
                    total += 1;
            }

            Assert.Equal(2, total);
        }

        [Fact]
        public void ParsePasswordRules_WithSimpleText_ShouldReturnRules()
        {
            string raw = "1-3 a: abcde";
            int minRequired = 0;
            int maxRequired = 0;
            char pattern = ' ';

            RuleParser ruleParser = new RuleParser();
            ruleParser.ParseRules(raw.Substring(0, raw.IndexOf(':')));

            minRequired = ruleParser.Min;
            maxRequired = ruleParser.Max;
            pattern = ruleParser.Pattern;

            Assert.Equal(1, minRequired);
            Assert.Equal(3, maxRequired);
            Assert.Equal('a', pattern);
        }

        [Fact]
        public void VerifyPassword_ForPart1_ShouldReturnTrue()
        {
            string raw = "1-3 a: abcde";
            string password = String.Empty;

            RuleParser ruleParser = new RuleParser();
            ruleParser.ParseRules(raw.Substring(0, raw.IndexOf(':')));

            PasswordValidator passValidator = new PasswordValidator(ruleParser, raw.Substring(raw.IndexOf(':')));
            bool isValidPassword = passValidator.IsPart1Valid();

            Assert.True(isValidPassword);
        }

        [Fact]
        public void VerifyPassword_ForValidPart2_ShouldReturnTrue()
        {
            string raw = "1-3 a: abcde";
            string password = String.Empty;

            RuleParser ruleParser = new RuleParser();
            ruleParser.ParseRules(raw.Substring(0, raw.IndexOf(':')));

            PasswordValidator passValidator = new PasswordValidator(ruleParser, raw.Substring(raw.IndexOf(':')));
            bool isValidPassword = passValidator.IsPart2Valid();

            Assert.True(isValidPassword);
        }

        [Fact]
        public void VerifyPassword_ForInvalidPart2_ShouldReturnFalse()
        {
            string raw = "1-3 b: cdefg";
            string password = String.Empty;

            RuleParser ruleParser = new RuleParser();
            ruleParser.ParseRules(raw.Substring(0, raw.IndexOf(':')));

            PasswordValidator passValidator = new PasswordValidator(ruleParser, raw.Substring(raw.IndexOf(':')));
            bool isValidPassword = passValidator.IsPart2Valid();

            Assert.False(isValidPassword);
        }

        [Fact]
        public void VerifyPassword_ForInvalidPart2Other_ShouldReturnFalse()
        {
            string raw = "2-9 c: ccccccccc";
            string password = String.Empty;

            RuleParser ruleParser = new RuleParser();
            ruleParser.ParseRules(raw.Substring(0, raw.IndexOf(':')));

            PasswordValidator passValidator = new PasswordValidator(ruleParser, raw.Substring(raw.IndexOf(':')));
            bool isValidPassword = passValidator.IsPart2Valid();

            Assert.False(isValidPassword);
        }
    }
}
