using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode.Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            InputGetter input = new InputGetter("input.txt");

            ProgramFramework framework = new ProgramFramework();
            framework.InputHandler = input.GetStringsFromInput;
            framework.Part1Handler = Part1;
            framework.Part2Handler = Part2;
            framework.RunProgram();
        }

        public static void Part1(string[] data)
        {
            Dictionary<long, long> memory = new Dictionary<long, long>();

            string mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Substring(0, 4) == "mask")
                {
                    mask = Parser.GetMask(data[i]);
                }
                else
                {
                    (long memSlot, long value) = Parser.GetMem(data[i]);
                    BinaryNum num = new BinaryNum(value);
                    memory[memSlot] = num.MemMask(mask);
                }
            }

            Console.WriteLine($"The total of the memory slots is: {memory.Sum(addr => addr.Value)}.");
        }

        public static List<string> AddressCombos = new List<string>();

        public static void Part2(string[] data)
        {
            Dictionary<long, long> memory = new Dictionary<long, long>();
            string mask = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Substring(0, 4) == "mask")
                {
                    mask = Parser.GetMask(data[i]);
                }
                else
                {
                    (long memSlot, long value) = Parser.GetMem(data[i]);

                    BinaryNum addr = new BinaryNum(memSlot);
                    string currMask = addr.AddrMask(mask);

                    AddressCombos = new List<string>();
                    GetAddrCombos(
                        currMask.ToCharArray(),
                        Array.IndexOf(currMask.ToCharArray(), 'X')
                        );

                    foreach (var address in AddressCombos)
                        memory[Convert.ToInt64(address, 2)] = value;
                }
            }

            Console.WriteLine($"The total of the memory slots is: {memory.Sum(addr => addr.Value)}.");
        }

        private static void GetAddrCombos(char[] addrMask, int currIndex)
        {
            if (!addrMask.Contains('X'))
                AddressCombos.Add(new string(addrMask));
            else
            {
                int nextPos = Array.IndexOf(addrMask, 'X', currIndex + 1);
                char[] newAddr = new char[36];
                addrMask[currIndex] = '0';
                Array.Copy(addrMask, newAddr, 36);
                GetAddrCombos(newAddr, nextPos);
                addrMask[currIndex] = '1';
                Array.Copy(addrMask, newAddr, 36);
                GetAddrCombos(newAddr, nextPos);
            }
        }
    }
}
