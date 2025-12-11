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
            // ---- CBB START & END (KHÔNG có None) ----
            var cityList = cities
                .Select(c => new { c.Id, c.Name })
                .ToList();

            cbbStart.DataSource = new List<object>(cityList);
            cbbStart.DisplayMember = "Name";
            cbbStart.ValueMember = "Id";

            cbbEnd.DataSource = new List<object>(cityList);
            cbbEnd.DisplayMember = "Name";
            cbbEnd.ValueMember = "Id";

            // ---- CBB ADDITION (CÓ None) ----
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
        // ================================
        //   CONVERT LAT & LON TO PANEL XY
        // ================================
        private PointF ConvertToPanel(double lat, double lon)
        {
            float x = (float)((lon + 180) / 360f * panelHeader.Width);
            float y = (float)((90 - lat) / 180f * panelHeader.Height);
            return new PointF(x, y);
        }

        // ================================
        //            DRAW MAP
        // ================================
        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // ----------- Vẽ Flight (Connecting Lines) ---------------------
            foreach (var f in flights)
            {
                City src = cities.FirstOrDefault(c => c.Id == f.SourceCityId);
                City dst = cities.FirstOrDefault(c => c.Id == f.DestCityId);

                if (src == null || dst == null)
                    continue;

                PointF p1 = ConvertToPanel(src.Latitude, src.Longitude);
                PointF p2 = ConvertToPanel(dst.Latitude, dst.Longitude);

                // Vẽ đường nối
                g.DrawLine(Pens.Blue, p1, p2);

                // Ghi giá tiền
                float midX = (p1.X + p2.X) / 2;
                float midY = (p1.Y + p2.Y) / 2;

                g.DrawString(f.Price.ToString(),
                             new Font("Arial", 10),
                             Brushes.DarkGreen,
                             midX, midY);
            }

            // ----------- Vẽ City (Nodes) ---------------------
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
        }
        private void MenuFlight_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            LoadDataIntoComboboxes();
        }
        // ================================
        //          BUTTON EVENTS
        // ================================
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnClean_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
