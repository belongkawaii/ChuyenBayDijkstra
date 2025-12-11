//using ChuyenBayDijkstra;
//using System;
//using System.Collections.Generic;

//namespace Flight_Dịkstra
//{

//    public class Dijkstra
//    {
//        private List<double> _dist;
//        private List<int> _prev;
//        private Graph _graph;

//        public List<double> Dist
//        {
//            get => _dist;
//            set => _dist = value;
//        }
//        public List<int> Prev
//        {
//            get => _prev;
//            set => _prev = value;
//        }
//        public Graph Graph
//        {
//            get => _graph;
//            set => _graph = value;
//        }
//        public Dijkstra(List<double> dist, List<int> prev, Graph graph)
//        {
//            _dist = dist;
//            _prev = prev;
//            _graph = graph;
//        }

//        public Dijkstra()
//        {
//            _dist = new List<double>();
//            _prev = new List<int>();
//            _graph = new Graph();
//        }

//        public List<int> GetShortestPath(int startId, int destId)
//        {
//            if (Math.Abs(_dist[destId] - Double.MaxValue) < 10e-9)
//            {
//                return new List<int>();
//            }
//            var st = new Stack<int>();
//            st.Push(destId);

//            while (st.Peek() != startId)
//            {
//                st.Push(_prev[st.Peek()]);
//            }

//            var res = new List<int>();
//            while (st.Count != 0)
//            {
//                res.Add(st.Pop());
//            }

//            return res;
//        }

//        public double GetDistance(int destId)
//        {
//            return _dist[destId];
//        }
//    }
//}