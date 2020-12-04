using System;
using System.Reflection;

namespace AdventOfCode.Day4
{
    public class Passport
    {
        public PassportData Data { get; private set; }
        public string[] required { get; set; } = 
            new string[] {"byr","iyr","eyr","hgt","hcl","ecl","pid","cid"};

        public Passport(PassportData data)
        {
            Data = data;
        }

        public bool IsValid()
        {
            return AreAllRequiredDataSet();
        }

        private bool AreAllRequiredDataSet()
        {
            for (int i = 0; i < required.Length; i++)
            {
                if ( String.IsNullOrEmpty( Data.GetType().GetProperty(required[i]).GetValue(Data).ToString() ) )
                    return false;
            }

            return true;
        }
    }
}