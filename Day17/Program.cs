using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day17
{
    
    class Program
    {
        static int sum = 0;
        static int perm;

        static int min = 99;
        static int anz = 0;
        static int c = 0;

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Niklas-Uni\Documents\Visual Studio 2010\Projects\Day17\Day17\input.txt");
            int[] container = new int[lines.Length];
            int k = 0;
            foreach (string s in lines)
            {
                container[k] = Convert.ToInt32(s);
                k++;
            }

            for (int x = 0; x < container.Length;x++ )
            {
                rec_add(container, 0, x);
            }


            Console.WriteLine(perm);
            Console.WriteLine(min);
            Console.WriteLine(anz);
            Console.ReadLine();
           

        }

        private static void rec_add(int[] cont, int sum, int i)
        {
            c++;
            int temp = sum + cont[i];
            if (temp > 150)
            {
                c--;
                return;
            }
            else if (temp == 150)
            {
                if (c < min)
                {
                    min = c;
                    anz = 1;
                }
                else if (c == min) anz++;
                perm++;
                c--;
                return;
            }
            else if(temp < 150)
            {
                for(int j = i+1;j < cont.Length;j++)
                {
                    rec_add(cont, temp, j);
                }
                c--;
                return;
            }
        }
    }
}
