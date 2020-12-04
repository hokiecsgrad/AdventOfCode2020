using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day4
{
    public class PassportBuilder
    {
        public string PassportData { get; private set; }

        public void AddData(string data)
        {
            PassportData += ' ' + data;
        }

        public Passport CreatePassport()
        {
            PassportData data = ParsePassportData();
            return new Passport(data);
        }

        private PassportData ParsePassportData()
        {
            string[] passportData = new List<string>(
                    PassportData.Split(' ')
                )
                .Select(s => s.Trim())
                .ToArray();
            
            PassportData data = new PassportData();
            
            for (int i = 0; i < passportData.Length; i++)
            {
                string[] property = passportData[i].Split(':');

                if ( ! String.IsNullOrEmpty(property[0]) )
                    data.SetValue(property[0], property[1]);
            }

            return data;
        }
    }
}