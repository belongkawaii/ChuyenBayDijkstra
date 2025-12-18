using ChuyenBayDijkstra.DatabaseScript;
using ChuyenBayDijkstra.Services;
using System;
using System.Collections.Generic;
using System.Drawing;      
using System.Linq;         
using System.Windows.Forms;

namespace ChuyenBayDijkstra.Forms
{
    public partial class MenuFlight : Form
    {
        #region DataStructure
        public class City
        {
            public int Id;           // ID thành phố (từ DB)
            public string Name;      // Tên thành phố
            public double Latitude;  // Vĩ độ
            public double Longitude; // Kinh độ
        }
        public class Flight
        {
            public int FlightId;      // ID chuyến bay
            public int SourceCityId;  // Thành phố xuất phát
            public int DestCityId;    // Thành phố đích
            public double Price;      // Chi phí
        }

        // Danh sách thành phố
        List<City> cities = new List<City>();

        // Danh sách chuyến bay
        List<Flight> flights = new List<Flight>();

        // ====== MAP CITY_ID ↔ INDEX ======
        // Dijkstra chỉ làm việc với index 0..n-1
        Dictionary<int, int> cityIdToIndex;  // city_id → index
        Dictionary<int, int> indexToCityId;  // index → city_id

        // ====== KẾT QUẢ DIJKSTRA ======
        // Danh sách city_id theo thứ tự đường đi ngắn nhất
        List<int> shortestPathCityIds = new List<int>();
        #endregion

        // ====== CONSTRUCTOR ======
        public MenuFlight()
        {
            // Hàm mặc định của WinForms
            InitializeComponent();
        }

        // ====== SỰ KIỆN FORM LOAD ======
        private void MenuFlight_Load(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ Database
            LoadDataFromDatabase();

            // 2. Map city_id sang index
            BuildCityIndexMap();

            // 3. Đổ dữ liệu vào ComboBox
            LoadDataIntoComboboxes();

            cbbStart.SelectedIndex = -1;
            cbbEnd.SelectedIndex = -1;
        }

        #region Load Data
        // ====== LOAD DATA TỪ DATABASE ======
        private void LoadDataFromDatabase()
        {
            // DataContext (LINQ to SQL)
            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            // Map DB.City → City (domain object)
            cities = db.Cities.Select(c => new City
            {
                Id = c.city_id,
                Name = c.name,
                Latitude = c.latitude ?? 0,   // Null-safe
                Longitude = c.longitude ?? 0
            }).ToList();

            // Map DB.Flight → Flight (domain object)
            flights = db.Flights.Select(f => new Flight
            {
                FlightId = f.flight_id,
                SourceCityId = f.source_city_id,
                DestCityId = f.dest_city_id,
                Price = f.price
            }).ToList();

            // Bật DoubleBuffer để vẽ mượt
            panelHeader.EnableDoubleBuffer();

            // Yêu cầu vẽ lại panel
            panelHeader.Invalidate();
        }

        // ====== MAP CITY_ID ↔ INDEX ======
        private void BuildCityIndexMap()
        {
            cityIdToIndex = new Dictionary<int, int>();
            indexToCityId = new Dictionary<int, int>();

            // Gán index cho từng thành phố
            for (int i = 0; i < cities.Count; i++)
            {
                cityIdToIndex[cities[i].Id] = i;
                indexToCityId[i] = cities[i].Id;
            }
        }

        // ====== LOAD COMBOBOX ======
        private void LoadDataIntoComboboxes()
        {
            // Tạo danh sách hiển thị (Id + Name)
            var list = cities.Select(c => new { c.Id, c.Name }).ToList();

            // ComboBox Start
            cbbStart.DataSource = list;
            cbbStart.DisplayMember = "Name";
            cbbStart.ValueMember = "Id";

            // ComboBox End
            cbbEnd.DataSource = list.ToList();
            cbbEnd.DisplayMember = "Name";
            cbbEnd.ValueMember = "Id";

            // ComboBox Addition (có None)
            var listAdd = new List<object>();
            listAdd.Add(new { Id = -1, Name = "None" });
            listAdd.AddRange(list);

            cbbAddition.DataSource = listAdd;
            cbbAddition.DisplayMember = "Name";
            cbbAddition.ValueMember = "Id";
        }
        #endregion

        #region Dijkstra Logic
        // ====== BUILD GRAPH CHO DIJKSTRA ======
        private Dijkstra BuildDijkstraGraph()
        {
            // Khởi tạo Dijkstra với số node = số thành phố
            Dijkstra dj = new Dijkstra(cities.Count);

            // Thêm cạnh (edge) cho mỗi chuyến bay
            foreach (var f in flights)
            {
                int u = cityIdToIndex[f.SourceCityId]; // index nguồn
                int v = cityIdToIndex[f.DestCityId];   // index đích
                dj.AddEdge(u, v, f.Price);
            }

            return dj;
        }

        // ====== TÌM ĐƯỜNG ĐI ======
        private List<int> FindPath(int startCityId, int endCityId)
        {
            var dj = BuildDijkstraGraph();

            int start = cityIdToIndex[startCityId];
            int end = cityIdToIndex[endCityId];

            // Chạy Dijkstra
            dj.Run(start);

            // Lấy path dạng index
            var pathIndex = dj.GetPath(start, end);

            // Convert index → city_id
            return pathIndex.Select(i => indexToCityId[i]).ToList();
        }
        #endregion

        #region Hàm kết quả
        // ====== TÍNH TỔNG CHI PHÍ ======
        private double CalculateTotalCost(List<int> pathCityIds)
        {
            double sum = 0;

            // Duyệt từng cặp thành phố liên tiếp
            for (int i = 0; i < pathCityIds.Count - 1; i++)
            {
                int u = pathCityIds[i];
                int v = pathCityIds[i + 1];

                // Tìm flight tương ứng
                var flight = flights.FirstOrDefault(f =>
                    f.SourceCityId == u && f.DestCityId == v);

                if (flight != null)
                    sum += flight.Price;
            }

            return sum;
        }

        // ====== CHUỖI LỘ TRÌNH ======
        private string BuildRouteText(List<int> pathCityIds)
        {
            var names = pathCityIds
                .Select(id => cities.First(c => c.Id == id).Name)
                .ToList();

            return string.Join(" → ", names);
        }

        // ====== Lấy giá tiền chuyến bay giữa 2 thành phố ======
        private double GetFlightPrice(int fromCityId, int toCityId)
        {
            var flight = flights.FirstOrDefault(f =>
                f.SourceCityId == fromCityId &&
                f.DestCityId == toCityId);

            return flight != null ? flight.Price : 0;
        }

        #endregion

        #region Drawing
        // ====== CHUYỂN LAT/LON → TỌA ĐỘ PANEL ======
        private PointF ConvertToPanel(double lat, double lon)
        {
            float x = (float)((lon + 180) / 360f * panelHeader.Width);
            float y = (float)((90 - lat) / 180f * panelHeader.Height);
            return new PointF(x, y);
        }

        // ====== VẼ PANEL ======
        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Flight thường (xanh + giá tiền xoay theo đường)
            foreach (var f in flights)
            {
                City a = cities.First(c => c.Id == f.SourceCityId);
                City b = cities.First(c => c.Id == f.DestCityId);

                PointF p1 = ConvertToPanel(a.Latitude, a.Longitude);
                PointF p2 = ConvertToPanel(b.Latitude, b.Longitude);

                // Vẽ đường bay
                g.DrawLine(Pens.LightBlue, p1, p2);

                // ====== VẼ GIÁ TIỀN XOAY THEO ĐƯỜNG ======
                float midX = (p1.X + p2.X) / 2;
                float midY = (p1.Y + p2.Y) / 2;

                // Tính góc nghiêng của đoạn thẳng
                float angle = (float)(Math.Atan2(p2.Y - p1.Y, p2.X - p1.X) * 180 / Math.PI);

                string text = f.Price.ToString("N0");

                // Lưu trạng thái graphics
                var state = g.Save();

                // Dịch gốc tọa độ tới trung điểm
                g.TranslateTransform(midX, midY);

                // Xoay theo góc đoạn thẳng
                g.RotateTransform(angle);

                // Vẽ chữ (không nền)
                using (Font boldFont = new Font(Font, FontStyle.Bold))
                {
                    g.DrawString(
                        text,
                        boldFont,
                        Brushes.DarkGreen,
                        0, 0,
                        new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        });
                }


                // Phục hồi graphics
                g.Restore(state);
            }



            // Vẽ đường đi ngắn nhất (màu đỏ + giá tiền)
            for (int i = 0; i < shortestPathCityIds.Count - 1; i++)
            {
                int fromId = shortestPathCityIds[i];
                int toId = shortestPathCityIds[i + 1];

                City a = cities.First(c => c.Id == fromId);
                City b = cities.First(c => c.Id == toId);

                PointF p1 = ConvertToPanel(a.Latitude, a.Longitude);
                PointF p2 = ConvertToPanel(b.Latitude, b.Longitude);

                // Vẽ đường đỏ
                g.DrawLine(new Pen(Color.Red, 3), p1, p2);

                // Lấy giá tiền
                double price = GetFlightPrice(fromId, toId);

                // Tính trung điểm
                float midX = (p1.X + p2.X) / 2;
                float midY = (p1.Y + p2.Y) / 2;

                // Nền trắng để chữ dễ nhìn
                string text = price.ToString("N0");
                SizeF size = g.MeasureString(text, Font);

                g.FillRectangle(
                    Brushes.White,
                    midX - size.Width / 2,
                    midY - size.Height / 2,
                    size.Width,
                    size.Height);

                // Vẽ giá tiền
                g.DrawString(
                    text,
                    Font,
                    Brushes.DarkRed,
                    midX - size.Width / 2,
                    midY - size.Height / 2);
            }

            // Vẽ thành phố
            foreach (var c in cities)
            {
                PointF p = ConvertToPanel(c.Latitude, c.Longitude);
                g.FillEllipse(Brushes.Red, p.X - 4, p.Y - 4, 18, 18);
                g.DrawString(c.Name, Font, Brushes.Black, p.X + 5, p.Y + 5);
            }
        }
        #endregion

        #region Events Click

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmListCities frm = new frmListCities();
            frm.FormClosing += Frm_FormClosing;
            frm.Show();
            this.Hide();

        }

        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            // 1. Lấy dữ liệu từ Database
            LoadDataFromDatabase();

            // 2. Map city_id sang index
            BuildCityIndexMap();

            // 3. Đổ dữ liệu vào ComboBox
            LoadDataIntoComboboxes();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbbStart.SelectedIndex == -1 || cbbEnd.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn thành phố xuất phát và đích!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
                

            if (cbbStart.SelectedIndex == cbbEnd.SelectedIndex)
            {
                MessageBox.Show("Thành phố xuất phát và đích không được trùng nhau!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
                

            int startId = (int)cbbStart.SelectedValue;
            int endId = (int)cbbEnd.SelectedValue;
            int addId = (int)cbbAddition.SelectedValue;

            shortestPathCityIds.Clear();

            List<int> path;

            if (addId == -1)
            {
                path = FindPath(startId, endId);
            }
            else
            {
                var p1 = FindPath(startId, addId);
                var p2 = FindPath(addId, endId);

                if (p1.Count == 0 || p2.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy đường đi phù hợp!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                p1.RemoveAt(p1.Count - 1);
                p1.AddRange(p2);
                path = p1;
            }

            if (path.Count == 0)
            {
                MessageBox.Show("Không tìm thấy đường đi phù hợp!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            shortestPathCityIds = path;

            double totalCost = CalculateTotalCost(path);
            string routeText = BuildRouteText(path);

            lblTotalPrice.Text = "$" + totalCost.ToString("N0");
            lblLoTrinh.Text = routeText;

            MessageBox.Show(
                $"Lộ trình:\n{routeText}\n\nTổng chi phí: ${totalCost:N0}",
                "Kết quả tìm đường",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            panelHeader.Invalidate();
        }


        private void btnClean_Click(object sender, EventArgs e)
        {
            cbbStart.SelectedIndex = -1;
            cbbEnd.SelectedIndex = -1;
            cbbAddition.SelectedValue = -1;
            lblTotalPrice.Text = "$0";
            shortestPathCityIds.Clear();
            panelHeader.Invalidate();
            lblLoTrinh.Text = "";
        }

        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            frmListFlights frm = new frmListFlights();
            frm.FormClosing += Frm_FormClosing;
            frm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        
    }
}
