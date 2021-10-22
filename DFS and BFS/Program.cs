using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS_and_BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> DirectGraph = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> UndirectGraph = new Dictionary<string, List<string>>();

            string[] lines = System.IO.File.ReadAllLines("input.txt");

            foreach(string line in lines)
            {
                string start = line.Split(',')[0];
                string destination = line.Split(',')[1];

                if(!DirectGraph.ContainsKey(start)) DirectGraph.Add(start, new List<string>() );
                DirectGraph[start].Add(destination);

                if (!UndirectGraph.ContainsKey(start)) UndirectGraph.Add(start, new List<string>());
                if (!UndirectGraph.ContainsKey(destination)) UndirectGraph.Add(destination, new List<string>());

                UndirectGraph[start].Add(destination);
                UndirectGraph[destination].Add(start);

            }
            Console.WriteLine("Direct Graph");
            PrintGraphic(DirectGraph);

            Console.WriteLine();
            Console.WriteLine("UnDirect Graph");
            PrintGraphic(UndirectGraph);

        }

        static void PrintGraphic(Dictionary<string, List<string>> Graph)
        {
            foreach(var start in Graph.Keys)
            {
                foreach(string destination in Graph[start])
                {
                    Console.WriteLine("{0} -> {1}", start, destination);
                }
            }
        }
    }
}
