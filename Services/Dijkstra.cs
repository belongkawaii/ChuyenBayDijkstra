using ChuyenBayDijkstra.DatabaseScript;
using ChuyenBayDijkstra.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flight_Dijkstra
{
    public class Dijkstra
    {
        private List<double> _dist;
        private List<int> _prev;
        private List<List<Flight>> _adj;

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
        public List<List<Flight>> Adj
        {
            get => _adj;
            set => _adj = value;
        }

        public Dijkstra(List<double> dist, List<int> prev, List<List<Flight>> adj)
        {
            _dist = dist;
            _prev = prev;
            _adj = adj;
        }

        public Dijkstra()
        {
            _dist = new List<double>();
            _prev = new List<int>();
            _adj = new List<List<Flight>>();
        }

        // Hàm Run 
        public void Run(int startId)
        {
            if (_adj == null || _adj.Count == 0)
                throw new Exception("Graph is empty");

            int n = _adj.Count;

            if (startId < 0 || startId >= n)
                throw new ArgumentOutOfRangeException(nameof(startId));

            _dist = Enumerable.Repeat(double.MaxValue, n).ToList();
            _prev = Enumerable.Repeat(-1, n).ToList();
            bool[] visited = new bool[n];

            var pq = new SortedSet<(double dist, int id)>(
                Comparer<(double dist, int id)>.Create((a, b) =>
                {
                    int cmp = a.dist.CompareTo(b.dist);
                    return cmp != 0 ? cmp : a.id.CompareTo(b.id);
                })
            );

            _dist[startId] = 0;
            pq.Add((0, startId));

            while (pq.Count > 0)
            {
                var cur = pq.Min;
                pq.Remove(cur);

                int u = cur.id;
                if (visited[u]) continue;
                visited[u] = true;

                if (u >= _adj.Count || _adj[u] == null) continue;

                foreach (var f in _adj[u])
                {
                    int v = f.dest_city_id;
                    double w = f.price;

                    if (v < 0 || v >= n) continue;
                    if (visited[v]) continue;

                    double nd = _dist[u] + w;

                    if (nd < _dist[v])
                    {
                        pq.Remove((_dist[v], v)); 
                        _dist[v] = nd;
                        _prev[v] = u;
                        pq.Add((nd, v));
                    }
                }
            }
        }



        public List<int> GetShortestPath(int startId, int destId)
        {
            // Kiểm tra đã chạy thuật toán chưa
            if (_dist == null || _dist.Count == 0)
            {
                throw new InvalidOperationException("Chưa chạy thuật toán Dijkstra. Hãy gọi Run() trước.");
            }

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
            if (_dist == null || destId >= _dist.Count)
            {
                throw new ArgumentException("Không tìm thấy thành phố với ID này.");
            }
            return _dist[destId];
        }
    }
}