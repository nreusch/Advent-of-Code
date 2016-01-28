using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\baws\documents\visual studio 2015\Projects\AdventOfCode\Day9\Input.txt");
            List<Knoten> knotenList = new List<Knoten>();
            Regex regexCity = new Regex(@"\w+");
            Regex regexDist = new Regex(@"\d+");

            foreach(string line in lines)
            {
                Match firstCity = regexCity.Match(line);
                Match secondCity = firstCity.NextMatch().NextMatch();
                Match dist = regexDist.Match(line);

                Knoten toAdd = new Knoten(firstCity.Value);
                if (!knotenList.Contains(toAdd))
                {

                    toAdd.addToNeighbours(Convert.ToInt32(dist.Value), new Knoten(secondCity.Value));
                    knotenList.Add(toAdd);
                }
                else
                {
                    knotenList.Find(item => item.Name.Equals(toAdd.Name)).addToNeighbours(Convert.ToInt32(dist.Value), new Knoten(secondCity.Value));
                    
                }
                
                
            }

            foreach(Knoten knoten in knotenList)
            {

            }

            Console.ReadLine();
        }
    }

    internal class Knoten : IEquatable<Knoten>
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Knoten(string name)
        {
            _name = name;
        }
        private SortedList<int, Knoten> nachbarList = new SortedList<int, Knoten>();

        public void addToNeighbours(int dist, Knoten knoten)
        {
            nachbarList.Add(dist, knoten);
        }

        public SortedList<int, Knoten> getNachbarList()
        {
            return nachbarList;
        }

        bool IEquatable<Knoten>.Equals(Knoten other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
