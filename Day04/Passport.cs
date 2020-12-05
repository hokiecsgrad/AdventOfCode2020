using System;
using System.Text.RegularExpressions;
using System.Reflection;
using AdventOfCode.Day4.Validators;

namespace AdventOfCode.Day4
{
    public class Passport
    {
        public PassportData Data { get; private set; }
        public string[] required { get; set; } =
            new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", "cid" };

        public Passport(PassportData data)
        {
            Data = data;
        }

        public bool IsValid()
        {
            bool isValid = true;
            isValid &= new Validate(Data.byr).IsInt().IsAtLeast(1920).IsNoMoreThan(2002).Run();
            isValid &= new Validate(Data.iyr).IsInt().IsAtLeast(2010).IsNoMoreThan(2020).Run();
            isValid &= new Validate(Data.eyr).IsInt().IsAtLeast(2020).IsNoMoreThan(2030).Run();
            isValid &= new Validate(Data.hcl).IsString().Matches(new Regex("^#[0-9a-f]{6}$")).Run();
            isValid &= new Validate(Data.ecl).IsString().IsOneOf(new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }).Run();
            isValid &= new Validate(Data.pid).IsString().LengthIsExactly(9).Matches(new Regex("^[0-9]+$")).Run();
            isValid &= new Validate(Data.hgt).IsString().Matches(new Regex("((1[5-8]\\d|19[0-3])cm|(59|6\\d|7[0-6])in)")).Run();
            return isValid;
        }

        public void HackRequirements(string[] newRequirements)
        {
            // You sneaky bastard
            required = newRequirements;
        }

        public bool AreAllRequiredDataSet()
        {
            for (int i = 0; i < required.Length; i++)
            {
                if (String.IsNullOrEmpty(Data.GetType().GetProperty(required[i]).GetValue(Data).ToString()))
                    return false;
            }

            return true;
        }
    }
}