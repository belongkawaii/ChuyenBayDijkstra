using System;
using System.Collections.Generic;
using System.Linq;

namespace ChuyenBayDijkstra.Services
{
    public class Edge
    {
        public int To;
        public double Weight;

        public Edge(int to, double weight)
        {
            To = to;
            Weight = weight;
        }
    }

    public class Dijkstra
    {
        private List<List<Edge>> adj;
        private double[] dist;
        private int[] prev;

        public Dijkstra(int n)
        {
            adj = new List<List<Edge>>();
            for (int i = 0; i < n; i++)
                adj.Add(new List<Edge>());
        }

        public void AddEdge(int from, int to, double weight)
        {
            adj[from].Add(new Edge(to, weight));
        }

        public void Run(int start)
        {
            int n = adj.Count;
            dist = new double[n];
            prev = new int[n];
            bool[] visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                dist[i] = double.MaxValue;
                prev[i] = -1;
            }

            dist[start] = 0;

            for (int i = 0; i < n; i++)
            {
                int u = -1;
                double best = double.MaxValue;

                for (int j = 0; j < n; j++)
                {
                    if (!visited[j] && dist[j] < best)
                    {
                        best = dist[j];
                        u = j;
                    }
                }

                if (u == -1) break;

                visited[u] = true;

                foreach (var e in adj[u])
                {
                    if (visited[e.To]) continue;

                    double nd = dist[u] + e.Weight;
                    if (nd < dist[e.To])
                    {
                        dist[e.To] = nd;
                        prev[e.To] = u;
                    }
                }
            }
        }

        public List<int> GetPath(int start, int end)
        {
            var path = new List<int>();
            if (dist[end] == double.MaxValue) return path;

            for (int v = end; v != -1; v = prev[v])
                path.Add(v);

            path.Reverse();
            return path;
        }

        public double GetDistance(int end)
        {
            return dist[end];
        }
    }
}
