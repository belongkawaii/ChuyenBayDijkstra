using ChuyenBayDijkstra;
using System;
using System.Collections.Generic;
using ChuyenBayDijkstra.Forms;
using ChuyenBayDijkstra.DatabaseScript;

namespace ChuyenBayDijkstra.Services
{

    public class Dijkstra
    {
        private List<double> _dist;
        private List<int> _prev;
        private List<List<Flight>> _adjlist;

        public List<double> Dist
        {
            get => _dist;
            set => _dist = value;
        }
        public List<int> Prev
        {
            get => _prev;
            set => _prev = value;
        }
        public List<List<Flight>> Adjlist
        {
            get => _adjlist;
            set => _adjlist = value;
        }
        public Dijkstra(List<double> dist, List<int> prev, List<List<Flight>> adjlist)
        {
            _dist = dist;
            _prev = prev;
            _adjlist = adjlist;
        }

        public Dijkstra()
        {
            _dist = new List<double>();
            _prev = new List<int>();
            _adjlist = new List<List<Flight>>();
        }

        public List<int> GetShortestPath(int startId, int destId)
        {
            if (Math.Abs(_dist[destId] - Double.MaxValue) < 10e-9)
            {
                return new List<int>();
            }
            var st = new Stack<int>();
            st.Push(destId);

            while (st.Peek() != startId)
            {
                st.Push(_prev[st.Peek()]);
            }

            var res = new List<int>();
            while (st.Count != 0)
            {
                res.Add(st.Pop());
            }

            return res;
        }

        public double GetDistance(int destId)
        {
            return _dist[destId];
        }
    }
}