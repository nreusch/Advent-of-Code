using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\baws\documents\visual studio 2015\Projects\AdventOfCode\Day2\Input.txt");
            long total = 0;
            total = Part2(lines, total);
            Console.WriteLine(total);
            Console.ReadLine();
        }

        private static long Part2(string[] lines, long total)
        {
            for (int i = 0; i < lines.Length; i++)
            {

                string line = lines[i];
                string[] dims = line.Split('x');
                int[] ints = Array.ConvertAll(dims, Convert.ToInt32);
                int l = Convert.ToInt32(dims[0]);
                int w = Convert.ToInt32(dims[1]);
                int h = Convert.ToInt32(dims[2]);
                Array.Sort(ints);

                int ribbon = ints[0] * 2 + ints[1] * 2;
                int bow = l * w * h;

                total += ribbon + bow;



            }

            return total;
        }

        private static long Part1(string[] lines, long total)
        {
            for (int i = 0; i < lines.Length; i++)
            {

                string line = lines[i];
                string[] dims = line.Split('x');
                int[] ints = Array.ConvertAll(dims, Convert.ToInt32);
                Array.Sort(ints);
                int kleinste = ints[0] * ints[1];
                int l = Convert.ToInt32(dims[0]);
                int w = Convert.ToInt32(dims[1]);
                int h = Convert.ToInt32(dims[2]);

                total += (2 * l * w + 2 * w * h + 2 * h * l) + kleinste;



            }

            return total;
        }
    }
}
