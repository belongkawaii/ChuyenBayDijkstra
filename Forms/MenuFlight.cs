using ChuyenBayDijkstra.DatabaseScript;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChuyenBayDijkstra.Services;

namespace ChuyenBayDijkstra.Forms
{
    public partial class MenuFlight : Form
    {

        #region DataStructure

        class DijkstraResult
        {
            public double TotalCost { get; set; }
            public List<int> Path { get; set; } = new List<int>();
        }

        public class City
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        public class Flight
        {
            public int FlightId { get; set; }
            public int SourceCityId { get; set; }
            public int DestCityId { get; set; }
            public double Price { get; set; }
        }

        List<City> cities = new List<City>();
        List<Flight> flights = new List<Flight>();
        List<List<Flight>> adjlist = new List<List<Flight>>();
        List<int> lastPath = null;   // luu path cuoi cung de ve tren panel

        #endregion


        private void BuildAdjList()
        {
            adjlist = new List<List<Flight>>();

            if (flights.Count == 0) return;

            int maxId = cities.Max(c => c.Id);

            for (int i = 0; i <= maxId; i++)
                adjlist.Add(new List<Flight>());

            foreach (var f in flights)
            {
                if (f.SourceCityId < adjlist.Count)
                    adjlist[f.SourceCityId].Add(f);
            }
        }

        public MenuFlight()
        {
            InitializeComponent();
            BuildAdjList();
        }


        private void LoadDataIntoComboboxes()
        {
            // Load cbbStart, cbbEnd (ko co None) 
            var cityList = cities
                .Select(c => new { c.Id, c.Name })
                .ToList();

            cbbStart.DataSource = new List<object>(cityList);
            cbbStart.DisplayMember = "Name";
            cbbStart.ValueMember = "Id";

            cbbEnd.DataSource = new List<object>(cityList);
            cbbEnd.DisplayMember = "Name";
            cbbEnd.ValueMember = "Id";

            // load cbbAddition (co None)
            var cityListWithNone = new List<object>
            {
            new { Id = -1, Name = "None" }
            };
            cityListWithNone.AddRange(cityList);

            cbbAddition.DataSource = cityListWithNone;
            cbbAddition.DisplayMember = "Name";
            cbbAddition.ValueMember = "Id";
        }


        private void LoadDataFromDatabase()
        {
            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            // Map DatabaseScript.City to MenuFlight.City
            cities = db.Cities
                .Select(c => new City
                {
                    Id = c.city_id,
                    Name = c.name,
                    Latitude = c.latitude ?? 0,
                    Longitude = c.longitude ?? 0
                })
                .ToList();

            flights = db.Flights
                .Select(f => new Flight
                {
                    FlightId = f.flight_id,
                    SourceCityId = f.source_city_id,
                    DestCityId = f.dest_city_id,
                    Price = f.price
                })
                .ToList();
            panelHeader.EnableDoubleBuffer();

            panelHeader.Invalidate();
        }

        //CONVERT LAT & LON TO PANEL XY
        private PointF ConvertToPanel(double lat, double lon)
        {
            float x = (float)((lon + 180) / 360f * panelHeader.Width);
            float y = (float)((90 - lat) / 180f * panelHeader.Height);
            return new PointF(x, y);
        }

        //ve panel
        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // ve flight
            foreach (var f in flights)
            {
                City src = cities.FirstOrDefault(c => c.Id == f.SourceCityId);
                City dst = cities.FirstOrDefault(c => c.Id == f.DestCityId);

                if (src == null || dst == null)
                    continue;

                PointF p1 = ConvertToPanel(src.Latitude, src.Longitude);
                PointF p2 = ConvertToPanel(dst.Latitude, dst.Longitude);

                // ve duong noi
                g.DrawLine(Pens.Blue, p1, p2);

                // ghi gia tien o giua
                float midX = (p1.X + p2.X) / 2;
                float midY = (p1.Y + p2.Y) / 2;

                g.DrawString(f.Price.ToString(),
                             new Font("Arial", 10),
                             Brushes.DarkGreen,
                             midX, midY);
            }

            // ve city
            foreach (var city in cities)
            {
                PointF p = ConvertToPanel(city.Latitude, city.Longitude);

                // Node
                g.FillEllipse(Brushes.Red, p.X - 5, p.Y - 5, 10, 10);
                g.DrawEllipse(Pens.Black, p.X - 5, p.Y - 5, 10, 10);

                // Tên thành phố
                g.DrawString(city.Name,
                             new Font("Arial", 9),
                             Brushes.Black,
                             p.X + 6, p.Y + 6);
            }

            // =====================
            // VE PATH DIJKSTRA (DO)
            // =====================
            if (lastPath != null && lastPath.Count > 1)
            {
                using (Pen redPen = new Pen(Color.Red, 4))
                {
                    for (int i = 0; i < lastPath.Count - 1; i++)
                    {
                        City a = cities.FirstOrDefault(c => c.Id == lastPath[i]);
                        City b = cities.FirstOrDefault(c => c.Id == lastPath[i + 1]);

                        if (a == null || b == null) continue;

                        PointF p1 = ConvertToPanel(a.Latitude, a.Longitude);
                        PointF p2 = ConvertToPanel(b.Latitude, b.Longitude);

                        g.DrawLine(redPen, p1, p2);
                    }
                }
            }
        }

        private DijkstraResult DijkstraWithAddition(int startId, int addId, int endId)
        {
            var part1 = Dijkstra(startId, addId);
            var part2 = Dijkstra(addId, endId);

            if (part1 == null || part2 == null)
                return null;

            // ghep 2 path (bo di node addId o giua)
            part1.Path.RemoveAt(part1.Path.Count - 1);
            part1.Path.AddRange(part2.Path);

            return new DijkstraResult
            {
                TotalCost = part1.TotalCost + part2.TotalCost,
                Path = part1.Path
            };
        }

        private void ShowResult(DijkstraResult result)
        {
            if (result == null)
            {
                MessageBox.Show("Không tìm được đường đi!", "Dijkstra",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PATH:");

            foreach (int id in result.Path)
            {
                var city = cities.FirstOrDefault(c => c.Id == id);
                sb.Append(city != null ? city.Name : id.ToString());
                sb.Append(" -> ");
            }

            sb.Length -= 4; //xoa " -> "
            sb.AppendLine();
            sb.AppendLine($"TOTAL PRICE: {result.TotalCost}");

            MessageBox.Show(sb.ToString(), "DIJKSTRA RESULT",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void MenuFlight_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            BuildAdjList();
            LoadDataIntoComboboxes();

        }
        private DijkstraResult Dijkstra(int startId, int endId)
        {
            int maxId = cities.Max(c => c.Id);

            double[] dist = new double[maxId + 1];
            int[] prev = new int[maxId + 1];
            bool[] visited = new bool[maxId + 1];

            for (int i = 0; i <= maxId; i++)
            {
                dist[i] = double.MaxValue;
                prev[i] = -1;
            }

            dist[startId] = 0;

            for (int i = 0; i <= maxId; i++)
            {
                // chon node u chua tham va co dist nho nhat
                double minDist = double.MaxValue;
                int u = -1;

                for (int j = 0; j <= maxId; j++)
                {
                    if (!visited[j] && dist[j] < minDist)
                    {
                        minDist = dist[j];
                        u = j;
                    }
                }

                if (u == -1) break;
                if (u == endId) break;

                visited[u] = true;

                // cach cap nhat dist cho cac dinh ke v
                foreach (var f in adjlist[u])
                {
                    int v = f.DestCityId;
                    double cost = f.Price;

                    if (dist[u] + cost < dist[v])
                    {
                        dist[v] = dist[u] + cost;
                        prev[v] = u;
                    }
                }
            }

            // dung path
            List<int> path = new List<int>();
            int cur = endId;

            if (prev[cur] == -1 && cur != startId)
                return null; // ko tim duoc duong di

            while (cur != -1)
            {
                path.Add(cur);
                cur = prev[cur];
            }

            path.Reverse();

            return new DijkstraResult
            {
                TotalCost = dist[endId],
                Path = path
            };
        }



        #region Click Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbbStart.SelectedValue == null || cbbEnd.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Start và End");
                return;
            }

            int startId = (int)cbbStart.SelectedValue;
            int endId = (int)cbbEnd.SelectedValue;
            int addId = (int)cbbAddition.SelectedValue;

            DijkstraResult result;

            if (addId == -1)
                result = Dijkstra(startId, endId);
            else
                result = DijkstraWithAddition(startId, addId, endId);

            if (result == null)
            {
                MessageBox.Show("Không tìm được đường đi!");
                lastPath = null;
                panelHeader.Invalidate();
                return;
            }

            // 🔴 LUU PATH DE VE
            lastPath = result.Path;

            panelHeader.Invalidate();   // repaint để vẽ đường đỏ

            ShowResult(result);
        }


        private void btnClean_Click(object sender, EventArgs e)
        {
            cbbStart.SelectedIndex = -1;
            cbbEnd.SelectedIndex = -1;
            cbbAddition.SelectedValue = -1;

            // 🔴 XOA PATH
            lastPath = null;

            panelHeader.Invalidate();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
