using System;
using System.Collections.Generic;
using System.Reflection;

namespace AdventOfCode.Day4
{
    public class PassportData
    {
        public string byr { get; set; } = "";
        public string iyr { get; set; } = "";
        public string eyr { get; set; } = "";
        public string hgt { get; set; } = "";
        public string hcl { get; set; } = "";
        public string ecl { get; set; } = "";
        public string pid { get; set; } = "";
        public string cid { get; set; } = "";

        public void SetValue(string key, string value)
        {
            if ( this.GetType().GetProperty(key) == null )
                return;
            
            this.GetType().GetProperty(key).SetValue(this, value);
        }
    }
}