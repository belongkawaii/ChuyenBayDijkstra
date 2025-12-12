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
        private Graph _graph;

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
        public Graph Graph
        {
            get => _graph;
            set => _graph = value;
        }

        public Dijkstra(List<double> dist, List<int> prev, Graph graph)
        {
            _dist = dist;
            _prev = prev;
            _graph = graph;
        }

        public Dijkstra()
        {
            _dist = new List<double>();
            _prev = new List<int>();
            _graph = new Graph();
        }

        // Hàm Run 
        public void Run(int startId)
        {
            if (_graph == null) return;

            // Lấy số lượng node thực tế
            int n = 0;

            // Adj có thể chứa null, hoặc không đúng số lượng -> lấy max index có flight
            if (_graph.Adj != null && _graph.Adj.Count > 0)
                n = Math.Max(n, _graph.Adj.Count);

            // lấy max city_id từ flights
            if (_graph.AllFlights != null && _graph.AllFlights.Count > 0)
            {
                int maxNode = _graph.AllFlights
                    .SelectMany(f => new[] { f.source_city_id, f.dest_city_id })
                    .Max();

                n = Math.Max(n, maxNode + 1);
            }

            if (n == 0)
                throw new Exception("Graph is empty. No cities or flights loaded.");

            if (startId < 0 || startId >= n)
                throw new ArgumentOutOfRangeException(nameof(startId), "startId is out of range.");

            // Init dist & prev
            _dist = Enumerable.Repeat(double.MaxValue, n).ToList();
            _prev = Enumerable.Repeat(-1, n).ToList();
            bool[] visited = new bool[n];

            _dist[startId] = 0;

            var pq = new SortedSet<(double dist, int id)>(
                Comparer<(double dist, int id)>.Create((a, b) =>
                {
                    int cmp = a.dist.CompareTo(b.dist);
                    return cmp != 0 ? cmp : a.id.CompareTo(b.id);
                })
            );

            double[] inSet = Enumerable.Repeat(double.MaxValue, n).ToArray();

            pq.Add((0, startId));
            inSet[startId] = 0;

            while (pq.Count > 0)
            {
                var current = pq.Min;
                pq.Remove(current);
                double curDist = current.dist;
                int u = current.id;

                if (curDist > _dist[u]) continue;
                if (visited[u]) continue;
                visited[u] = true;

                // bảo vệ out-of-range
                if (_graph.Adj == null || u >= _graph.Adj.Count || _graph.Adj[u] == null)
                    continue;

                foreach (var flight in _graph.Adj[u])
                {
                    if (flight == null) continue;

                    int v = flight.dest_city_id;
                    double weight = Convert.ToDouble(flight.price);

                    if (v < 0 || v >= n) continue;
                    if (visited[v]) continue;

                    double newDist = _dist[u] + weight;

                    if (newDist < _dist[v])
                    {
                        if (inSet[v] != double.MaxValue)
                            pq.Remove((inSet[v], v));

                        _dist[v] = newDist;
                        _prev[v] = u;
                        inSet[v] = newDist;
                        pq.Add((newDist, v));
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