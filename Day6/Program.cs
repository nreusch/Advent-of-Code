using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\baws\documents\visual studio 2015\Projects\AdventOfCode\Day6\Input.txt");
            byte[,] lights = new byte[1000,1000];
            Regex regex = new Regex(@"\d+");
            int i = 0;

            foreach (string line in lines)
            {
                
                Match match = regex.Match(line);
                int x1 = Convert.ToInt32(match.Value);
                match = match.NextMatch();
                int y1 = Convert.ToInt32(match.Value);
                match = match.NextMatch();
                int x2 = Convert.ToInt32(match.Value);
                match = match.NextMatch();
                int y2 = Convert.ToInt32(match.Value);

                
                

                
                if (line.StartsWith("turn on"))
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            lights[x,y] +=1;
                        }
                    }
                }
                else if (line.StartsWith("turn off"))
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            if (lights[x, y] > 0)
                            {
                                lights[x, y] -= 1;
                            }
                        }
                    }
                }
                else if (line.StartsWith("toggle"))
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        for (int y = y1; y <= y2; y++)
                        {
                            lights[x, y] += 2;
                        }
                    }
                }
                Console.WriteLine("finished" + i);
            }

            int count = 0;
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                     count += lights[x,y];
                    
                }
            }
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
