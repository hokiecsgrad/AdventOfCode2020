using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using AdventOfCode.Day4;


namespace tests
{
    public class Day4Tests
    {
        [Fact]
        public void FindValidPassports_WithDefaultInput_ShouldReturn2()
        {
            string testInput = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
                byr:1937 iyr:2017 cid:147 hgt:183cm

                iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
                hcl:#cfa07d byr:1929

                hcl:#ae17e1 iyr:2013
                eyr:2024
                ecl:brn pid:760753108 byr:1931
                hgt:179cm

                hcl:#cfa07d eyr:2025 pid:166559648
                iyr:2011 ecl:brn hgt:59in
                ";
            string[] passportsData = new List<string>(
                    testInput.Split(Environment.NewLine)
                )
                .Select(s => s.Trim())
                .ToArray();

            int validPassports = 0;

            PassportBuilder passportBuilder = new PassportBuilder();
            for (int i = 0; i < passportsData.Length; i++)
            {
                if ( ! IsAnEmptyLine(passportsData[i]) )
                {
                    passportBuilder.AddData(passportsData[i]);
                }
                else
                {
                    Passport passport = passportBuilder.CreatePassport();
                    
                    if ( passport.IsValid() )
                        validPassports++;

                    passportBuilder = new PassportBuilder();
                }
            }

            Assert.Equal(2, validPassports);
        }

        private bool IsAnEmptyLine(string data)
            => String.IsNullOrEmpty(data);

    }
}
