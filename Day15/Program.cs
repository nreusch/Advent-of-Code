using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate Ingredient array(without calories)
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\baws\documents\visual studio 2015\Projects\AdventOfCode\Day15\Input.txt");
            Regex regexCap = new Regex(@"[-]*\d"); // Match each number
            int[,] ingre = new int[4, 5];

            int i = 0;
            foreach(string line in lines)
            {
                Match m = regexCap.Match(line);
                for(int j = 0; j < 5;j++)
                {
                 // Generate Ingredient array for each line   
                    ingre[i, j] = Convert.ToInt32(m.Value.Substring(2, m.Value.Length - 2));
                    m = m.NextMatch();
                }
                i++;
            }


            int highest = 0;
            int[] sums = new int[5];

            for(int a = 0;a < 100; a++)
            {
                for (int b = 0; b < 100; b++)
                {
                    for (int c = 0; c < 100; c++)
                    {
                        for (int d = 0; d < 100; d++)
                        {
                            if (a + b + c + d == 100)
                            {
                                // Calculate sums for each ingredient type
                                for(int k = 0; k < 5;k++)
                                {
                                    sums[k] = a * ingre[0, k] + b * ingre[1, k] + c * ingre[2, k] + d * ingre[3, k];
                                    if (sums[k] < 0) { sums[k] = 0; };
                                }

                                int temp = sums[0] * sums[1] * sums[2] * sums[3]; // scoring excluding calories
                                if(temp > highest)
                                {
                                    if (sums[4] == 500)
                                    {
                                        highest = temp;
                                    }
                                }


                            }
                        }
                    }
                }

            }
            Console.WriteLine(highest);
            Console.ReadLine();
        }
    }
}
