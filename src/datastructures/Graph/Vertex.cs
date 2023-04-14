using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace AD
{
    public partial class Vertex : IVertex, IComparable<Vertex>
    {
        public string name;
        public LinkedList<Edge> adj;
        public double distance;
        public Vertex prev;
        public bool known;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        /// <summary>
        ///    Creates a new Vertex instance.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public Vertex(string name)
        {
            this.name = name;
            this.adj = new LinkedList<Edge>();
            this.distance = System.Double.MaxValue;
            this.prev = null;
            this.known = false;
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public string GetName()
        {
            return name;
        }
        public LinkedList<Edge> GetAdjacents()
        {
            return adj;
        }

        public double GetDistance()
        {
            return distance;
        }

        public Vertex GetPrevious()
        {
            return prev;
        }

        public bool GetKnown()
        {
            return known;
        }

        public void Reset()
        {
            distance = System.Double.MaxValue;
            prev = null;
            known = false;
        }


        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Vertex to its string representation.
        ///    <para>Output will be like : name (distance) [ adj1 (cost) adj2 (cost) .. ]</para>
        ///    <para>Adjecents are ordered ascending by name. If no distance is
        ///    calculated yet, the distance and the parantheses are omitted.</para>
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns> 
        public override string ToString()
        {

            StringBuilder vertexToString = new StringBuilder();

            vertexToString.Append($"{name}");

            if(distance != System.Double.MaxValue)
            {
                vertexToString.Append($"({distance})");
            }

            vertexToString.Append("[");

            if (adj.Count > 0)
            {
                foreach (var item in adj.OrderBy(x => x.dest.name).ThenBy(x => x.cost))
                {
                    vertexToString.Append($"{item.dest.name}({item.cost})");
                }
            }

            vertexToString.Append("]");

            return vertexToString.ToString();
        }

        int IComparable<Vertex>.CompareTo(Vertex other)
        {
            return this.distance.CompareTo(other.distance);
        }
    }
}