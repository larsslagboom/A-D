using System;
using System.Collections.Generic;
using System.Text;

namespace AD
{
    public partial class Graph
    {
        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented during exam
        //----------------------------------------------------------------------
        public void RegioClearAll() // Calls Vertex.RegionReset() for all vertices
        {
            if (vertexMap.Count == 0) throw new GraphEmptyException();

            foreach (var key in vertexMap.Keys)
            {
                vertexMap[key].RegioReset();
            }
        }

        public string AllPaths()
        {
            StringBuilder sb = new StringBuilder();
            string startingVert = null;
            if(vertexMap.Count == 0)
            {
                return "";
            }
            foreach (var val in vertexMap.Values)
            {
                if(val.prev != null || val.distance == 0)
                {
                    if (val.distance == 0)
                    {
                        sb.Append(val.name + ";");
                        startingVert = val.name;
                    }
                    else
                    {
                        var pointer = val;
                        while (pointer.prev != null)
                        {
                            sb.Append(pointer.name + "<-");
                            pointer = pointer.prev;
                        }
                        sb.Append(startingVert + ";");
                    }
                }
                else
                {
                    sb.Append(val.name + ";");
                }
            }
            return sb.ToString();
        }

        public void AddUndirectedEdge(string source, string dest, double cost)
        {
            AddEdge(source, dest, cost);
            vertexMap[dest].adj.AddLast(new Edge(vertexMap[source], cost));
        }


        public void AddVertex(string name, string regio)
        {
            if (!vertexMap.ContainsKey(name))
            {
                vertexMap.Add(name, new Vertex(name, regio));
                vertexMap[name].distance = INFINITY;
            }
        }


        public void RegioDijkstra(string name)
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
                    if (w.known == false)
                    {
                        if (v.distance + e.cost < w.distance)
                        {
                            w.distance = v.distance + e.cost;
                            w.prev = v;
                        }
                        Q.Add(w);
                    }
                }
            }
        }
    }
}
