using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;
using AdventOfCode.Day4;
using AdventOfCode.Day4.Validators;


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
                iyr:2011 ecl:brn hgt:59in";
            string[] passportsData = new List<string>(
                    testInput.Split(Environment.NewLine)
                )
                .Select(s => s.Trim())
                .ToArray();

            int validPassports = 0;
            PassportBuilder passportBuilder = new PassportBuilder();
            for (int i = 0; i <= passportsData.Length; i++)
            {
                if (i == passportsData.Length || IsAnEmptyLine(passportsData[i]))
                {
                    Passport passport = passportBuilder.CreatePassport();
                    passport.HackRequirements(new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" });

                    if (passport.AreAllRequiredDataSet())
                        validPassports++;

                    passportBuilder = new PassportBuilder();
                }
                else
                {
                    passportBuilder.AddData(passportsData[i]);
                }
            }

            Assert.Equal(2, validPassports);
        }

        private bool IsAnEmptyLine(string data)
            => String.IsNullOrEmpty(data);

        [Fact]
        public void ByrValidator_With3Digits_ShouldBeFalse()
        {
            string byr = "200";
            bool valid = new Validate(byr)
                                .IsInt()
                                .IsAtLeast(1920)
                                .IsNoMoreThan(2002)
                                .Run();
            Assert.False(valid);
        }

        [Fact]
        public void ByrValidator_WithCorrectDate_ShouldBeTrue()
        {
            string byr = "2000";
            bool valid = new Validate(byr)
                                .IsInt()
                                .IsAtLeast(1920)
                                .IsNoMoreThan(2002)
                                .Run();
            Assert.True(valid);
        }

        [Fact]
        public void HclValidator_WithInvalidChars_ShouldBeFalse()
        {
            string hcl = "#123abz";
            bool valid = new Validate(hcl)
                                .IsString()
                                .Matches(new Regex("#[0-9a-f]{6}"))
                                .Run();
            Assert.False(valid);
        }

        [Fact]
        public void HclValidator_WithValidChars_ShouldBeTrue()
        {
            string hcl = "#123abc";
            bool valid = new Validate(hcl)
                                .IsString()
                                .Matches(new Regex("#[0-9a-f]{6}"))
                                .Run();
            Assert.True(valid);
        }

        [Fact]
        public void EclValidator_WithInvalidString_ShouldBeFalse()
        {
            string ecl = "blue";
            bool valid = new Validate(ecl)
                                .IsString()
                                .IsOneOf(new string[] { "red", "green" })
                                .Run();
            Assert.False(valid);
        }

        [Fact]
        public void EclValidator_WithValidString_ShouldBeTrue()
        {
            string ecl = "blue";
            bool valid = new Validate(ecl)
                                .IsString()
                                .IsOneOf(new string[] { "red", "green", "blue" })
                                .Run();
            Assert.True(valid);
        }

        [Fact]
        public void PidValidator_WithInvalidString_ShouldBeFalse()
        {
            string pid = "0123456789";
            bool valid = new Validate(pid)
                                .IsString()
                                .LengthIsExactly(9)
                                .Matches(new Regex("^[0-9]$"))
                                .Run();
            Assert.False(valid);
        }

        [Fact]
        public void PidValidator_WithValidString_ShouldBeTrue()
        {
            string pid = "000000001";
            bool valid = new Validate(pid)
                                .IsString()
                                .LengthIsExactly(9)
                                .Matches(new Regex("^[0-9]+$"))
                                .Run();
            Assert.True(valid);
        }

        [Fact]
        public void PassportValidation_WithAllInvalidInput_ShouldReturn0Valid()
        {
            string testInput = @"eyr:1972 cid:100
                hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

                iyr:2019
                hcl:#602927 eyr:1967 hgt:170cm
                ecl:grn pid:012533040 byr:1946

                hcl:dab227 iyr:2012
                ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

                hgt:59cm ecl:zzz
                eyr:2038 hcl:74454a iyr:2023
                pid:3556412378 byr:2007";
            string[] passportsData = new List<string>(
                    testInput.Split(Environment.NewLine)
                )
                .Select(s => s.Trim())
                .ToArray();

            int validPassports = 0;
            PassportBuilder passportBuilder = new PassportBuilder();
            for (int i = 0; i <= passportsData.Length; i++)
            {
                if (i == passportsData.Length || IsAnEmptyLine(passportsData[i]))
                {
                    Passport passport = passportBuilder.CreatePassport();
                    passport.HackRequirements(new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" });

                    if (passport.IsValid())
                        validPassports++;

                    passportBuilder = new PassportBuilder();
                }
                else
                {
                    passportBuilder.AddData(passportsData[i]);
                }
            }

            Assert.Equal(0, validPassports);
        }

        [Fact]
        public void PassportValidation_WithAllValidInput_ShouldReturn4Valid()
        {
            string testInput = @"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
                hcl:#623a2f

                eyr:2029 ecl:blu cid:129 byr:1989
                iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

                hcl:#888785
                hgt:164cm byr:2001 iyr:2015 cid:88
                pid:545766238 ecl:hzl
                eyr:2022

                iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719";
            string[] passportsData = new List<string>(
                    testInput.Split(Environment.NewLine)
                )
                .Select(s => s.Trim())
                .ToArray();

            int validPassports = 0;
            PassportBuilder passportBuilder = new PassportBuilder();
            for (int i = 0; i <= passportsData.Length; i++)
            {
                if (i == passportsData.Length || IsAnEmptyLine(passportsData[i]))
                {
                    Passport passport = passportBuilder.CreatePassport();
                    passport.HackRequirements(new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" });

                    if (passport.IsValid())
                        validPassports++;

                    passportBuilder = new PassportBuilder();
                }
                else
                {
                    passportBuilder.AddData(passportsData[i]);
                }
            }

            Assert.Equal(4, validPassports);
        }
    }
}
