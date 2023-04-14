using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace AD
{
    public partial class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        public Dictionary<string, Vertex> vertexMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            vertexMap = new Dictionary<string, Vertex>();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Adds a vertex to the graph. If a vertex with the given name
        ///    already exists, no action is performed.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public void AddVertex(string name)
        {
            if (!vertexMap.ContainsKey(name))
            {
                vertexMap.Add(name, new Vertex(name));
            }
        }


        /// <summary>
        ///    Gets a vertex from the graph by name. If no such vertex exists,
        ///    a new vertex will be created and returned.
        /// </summary>
        /// <param name="name">The name of the vertex</param>
        /// <returns>The vertex withe the given name</returns>
        public Vertex GetVertex(string name)
        {
            if (vertexMap.ContainsKey(name))
            {
                return (vertexMap[name]);
            }
            else
            {
                AddVertex(name);
                return vertexMap[name];
            }
        }


        /// <summary>
        ///    Creates an edge between two vertices. Vertices that are non existing
        ///    will be created before adding the edge.
        ///    There is no check on multiple edges!
        /// </summary>
        /// <param name="source">The name of the source vertex</param>
        /// <param name="dest">The name of the destination vertex</param>
        /// <param name="cost">cost of the edge</param>
        public void AddEdge(string source, string dest, double cost = 1)
        {
            Vertex v = GetVertex(source);
            Vertex w = GetVertex(dest);
            v.adj.AddLast(new Edge(w, cost));
        }


        /// <summary>
        ///    Clears all info within the vertices. This method will not remove any
        ///    vertices or edges.
        /// </summary>
        public void ClearAll()
        {
            if (vertexMap.Count == 0) throw new GraphEmptyException();

            foreach (var item in vertexMap)
            {
                vertexMap[item.Key].Reset();
            }
        }

        /// <summary>
        ///    Performs the Breatch-First algorithm for unweighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Unweighted(string name)
        {
            if (vertexMap.ContainsKey(name))
            {
                Queue<Vertex> Q = new Queue<Vertex>();
                foreach (Vertex v in vertexMap.Values)
                {
                    v.distance = INFINITY;
                }

                Vertex s = GetVertex(name);
                s.distance = 0;

                Q.Enqueue(s);

                while (Q.Count != 0)
                {
                    Vertex v = Q.Dequeue();
                    foreach (Edge w in v.adj)
                    {
                        if (w.dest.distance == INFINITY)
                        {
                            w.dest.distance = v.distance + 1;
                            w.dest.prev = v;
                            Q.Enqueue(w.dest);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///    Performs the Dijkstra algorithm for weighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Dijkstra(string name)
        {
            PriorityQueue<Vertex> Q = new PriorityQueue<Vertex>();

            foreach (Vertex v in vertexMap.Values)
            {
                v.distance = INFINITY;
                v.prev = null;
                v.known = false;
            }

            Vertex s = GetVertex(name);
            s.distance = 0;

            Q.Add(s);
            
            while (Q.size != 0)
            {
                Vertex v = Q.Remove();

                if (v.known)
                    continue;
                v.known = true;
                foreach (Edge e in v.adj)
                {
                    Vertex w = e.dest;
                    if(w.known == false)
                    {
                        if(v.distance + e.cost < w.distance)
                        {
                            w.distance = v.distance + e.cost;
                            w.prev = v;
                        }
                        Q.Add(w);
                    }
                }
            }
        }

        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Graph to its string representation.
        ///    It will call the ToString method of each Vertex. The output is
        ///    ascending on vertex name.
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns>
        public override string ToString()
        {
            StringBuilder graphToString = new StringBuilder();

            foreach (string key in vertexMap.Keys.OrderBy(x => x))
            {
                graphToString.AppendLine(vertexMap[key].ToString());
            }

            return graphToString.ToString();
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------



        public bool IsConnected()
        {
            throw new System.NotImplementedException();
        }

    }

    public class GraphEmptyException : System.Exception
    {
        // Is thrown when Remove is called on an empty queue
    }

    public class GraphKeyAlreadyExistException : System.Exception
    {
        // Is thrown when Remove is called on an empty queue
    }
}