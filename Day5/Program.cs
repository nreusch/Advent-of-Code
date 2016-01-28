using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part2 solved with JS and Regex 
            /*
         document.body.textContent.split('\n')
        .filter(s => {
          return s.match(/(\w)(?=.\1)/) && s.match(/(\w\w)(?=.*\1)/);
        }).length
        */
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\baws\documents\visual studio 2015\Projects\AdventOfCode\Day5\Input.txt");
            string[] lines2 = new string[] { "xyppnjiljvirmqjo" };
            int nicenumber = 0;

            foreach (string line in lines)
            {
                int vowelct = 0;
                bool doubleletter = false;
                bool nobadwords = true;
                // 1 line has 16 chars
                for (int i = 0; i < line.Length - 1; i = i + 1)
                {
                    string word = line.Substring(i, 2);
                    
                    if (word == "ab" || word == "cd" || word == "pq" || word == "xy")
                    {
                        nobadwords = false;
                        
                    }
                    else
                    {
                        string a = word.Substring(0, 1);
                        string b = word.Substring(1, 1);

                        if (a == b)
                        {
                            doubleletter = true;
                        }
                        if (a == "a" || a == "e" || a == "i" || a == "o" || a == "u")
                        {
                            vowelct += 1;
                        }
                        
                    }
                    
                }

                if (vowelct >= 3 && doubleletter == true && nobadwords == true)
                {
                    nicenumber += 1;
                }
                
            }

            Console.WriteLine(nicenumber);
            Console.ReadLine();
        }
    }
}
