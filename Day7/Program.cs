using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\baws\documents\visual studio 2015\Projects\AdventOfCode\Day7\Input.txt");
            Dictionary<string, Wire> wireDict = new Dictionary<string, Wire>();
            string mode;

            Regex regexID = new Regex(@"[a-z]+");
            Regex regexOP = new Regex(@"[A-Z]+");

            foreach (string line in lines)
            {

                Match matchID = regexID.Match(line);
                string id1 = matchID.Value;

                string id2 = "";

                matchID = matchID.NextMatch();
                if (matchID.Success == true)
                {
                    id2 = matchID.Value;
                    string id3 = "";

                    matchID = matchID.NextMatch();
                    if (matchID.Success == true)
                    {
                        id3 = matchID.Value;
                    }
                    else
                    {
                        // No third id
                    }

                    Match matchOP = regexOP.Match(line);
                    if (matchOP.Success == true)
                    {
                        switch (matchOP.Value)
                        {
                            case "NOT":
                                wireDict.Add(id2, new Wire(id2,id1, matchOP.Value));
                                break;
                            case "RSHIFT":
                                Regex regexVal = new Regex(@"\d+");
                                Match valmatch = regexVal.Match(line);
                                wireDict.Add(id2, new Wire(id2,id1, Convert.ToUInt16(valmatch.Value), matchOP.Value));
                                break;
                            case "LSHIFT":
                                Regex regexVal2 = new Regex(@"\d+");
                                Match valmatch2 = regexVal2.Match(line);
                                wireDict.Add(id2, new Wire(id2,id1, Convert.ToUInt16(valmatch2.Value), matchOP.Value));
                                break;
                            case "AND":
                                if (id3 == "")
                                {
                                    //1 AND x = y
                                    wireDict.Add(id2, new Wire(id2,1, id1, matchOP.Value));
                                }
                                else
                                {
                                    wireDict.Add(id3, new Wire(id3,id1, id2, matchOP.Value));
                                }
                                break;
                            default:
                                wireDict.Add(id3, new Wire(id3,id1, id2, matchOP.Value));
                                break;
                        }
                    }
                    else
                    {
                        // WIRE TO WIRE
                        wireDict.Add(id2, new Wire(id2, id1));
                    }
                }
                else
                {
                    // No second id
                    // SET VALUE TO WIRE
                    Regex regexVal = new Regex(@"\d+");
                    Match valmatch = regexVal.Match(line);

                    wireDict.Add(id1, new Wire(Convert.ToUInt16(valmatch.Value)));

                }


            }


           
                foreach (var item in wireDict)
                {
                    item.Value.calculate(wireDict);
                }

            
            
            Console.WriteLine(wireDict["a"].Signal);
            Console.ReadLine();
        }

        internal class Wire
        {

            string _id;
            private ushort signal;
            private string _w1;
            private string _w2;
            private string _operation;
            private string mode;

            private ushort _shiftvalue;
            private ushort _andvalue;
            public bool calculated = false;
            public ushort Signal
            {
                get { return signal; }
                set { signal = value; }
            }

            public Wire(ushort value)
            {
                // For values
                mode = "value";
                signal = value;
                calculated = true;
            }

            public Wire(string id,string w1)
            {
                mode = "wire";
                _w1 = w1;
                _id = id;
            }

            public Wire(string id, ushort value, string w1, string operation)
            {
                // For Gates except NOT
                mode = "gate_with_immediate";
                _andvalue = value;
                _w1 = w1;
                _operation = operation;
                _id = id;
            }

            public Wire(string id, string w1, string w2, string operation)
            {
                // For Gates except NOT
                mode = "gate";
                _w1 = w1;
                _w2 = w2;
                _operation = operation;
                _id = id;
            }

            public Wire(string id, string w1, string operation)
            {
                // For NOT Operation
                _w1 = w1;
                _operation = operation;


                mode = "gate_not";
                _id = id;
            }

            public Wire(string id, string w1, ushort value, string operation)
            {
                // For Shift operation
                _w1 = w1;
                _operation = operation;
                _shiftvalue = value;
                mode = "shift";
                _id = id;
            }

            public void calculate(Dictionary<string,Wire> dict)
            {
                if (calculated == false)
                {
                    if (mode == "wire")
                    {
                        if (dict[_w1].calculated == false)
                        {
                            dict[_w1].calculate(dict);
                        }
                        this.Signal = dict[_w1].Signal;
                    }
                    else if (mode == "gate")
                    {
                        if (dict[_w1].calculated == false)
                        {
                            dict[_w1].calculate(dict);
                        }
                        if (dict[_w2].calculated == false)
                        {
                            dict[_w2].calculate(dict);
                        }
                        switch (_operation)
                        {
                            case "AND":

                                this.Signal = (ushort)(dict[_w1].Signal & dict[_w2].Signal);
                                break;
                            case "OR":

                                this.Signal = (ushort)(dict[_w1].Signal | dict[_w2].Signal);
                                break;

                        }

                    }
                    else if (mode == "gate_with_immediate")
                    {
                        if (dict[_w1].calculated == false)
                        {
                            dict[_w1].calculate(dict);
                        }
                        this.Signal = (ushort)(_andvalue & dict[_w1].Signal);
                    }
                    else if (mode == "gate_not")
                    {
                        if (dict[_w1].calculated == false)
                        {
                            dict[_w1].calculate(dict);
                        }
                        this.Signal = (ushort)(~dict[_w1].Signal);
                    }
                    else if (mode == "shift")
                    {
                        if (dict[_w1].calculated == false)
                        {
                            dict[_w1].calculate(dict);
                        }
                        switch (_operation)
                        {
                            case "LSHIFT":
                                this.Signal = (ushort)(dict[_w1].Signal << _shiftvalue);
                                break;
                            case "RSHIFT":
                                this.Signal = (ushort)(dict[_w1].Signal >> _shiftvalue);
                                break;
                        }

                    }
                    calculated = true;
                }
            }
        }
    }
}
