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

        string finalRouteText = ""; // chuỗi lộ trình
        double finalTotalCost = 0; // tổng chi phí


        // ====== ANIMATION ======
        Timer animationTimer;
        int currentSegment = 0;      // đang đi đoạn nào
        float t = 0f;                // 0 → 1 (tiến trình trên đoạn)
        PointF planePosition;        // vị trí máy bay

        List<Tuple<int, int>> drawnSegments = new List<Tuple<int, int>>(); // đoạn đã vẽ đỏ
        Image planeImage;

        #endregion

        // ====== CONSTRUCTOR ======
        public MenuFlight()
        {
            InitializeComponent();
            planeImage = Properties.Resources.Planet;
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

            InitAnimationTimer();
        }

        #region Load Data
        // ====== LOAD DATA TỪ DATABASE ======
        private void LoadDataFromDatabase()
        {
            FlightDijkstraDataContext db = new FlightDijkstraDataContext();
            cities = db.Cities.Select(c => new City
            {
                Id = c.city_id,
                Name = c.name,
                Latitude = c.latitude ?? 0, // Sử dụng 0 nếu null
                Longitude = c.longitude ?? 0 
            }).ToList();

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
        private PointF ConvertToPanel(double lat, double lon)  // lay kinh do va vi do
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


                string text = f.Price.ToString("N0");

                // Lưu trạng thái graphics
                var state = g.Save();

                // Dịch gốc tọa độ tới trung điểm
                g.TranslateTransform(midX, midY);


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

            // ====== VẼ CÁC ĐOẠN ĐÃ BAY QUA (ĐƯỜNG ĐỎ + GIÁ TIỀN) ======
            foreach (var seg in drawnSegments)
            {
                int fromId = seg.Item1;
                int toId = seg.Item2;

                City a = cities.First(c => c.Id == fromId);
                City b = cities.First(c => c.Id == toId);

                PointF p1 = ConvertToPanel(a.Latitude, a.Longitude);
                PointF p2 = ConvertToPanel(b.Latitude, b.Longitude);

                // Vẽ đường đỏ
                using (Pen redPen = new Pen(Color.Red, 3))
                {
                    g.DrawLine(redPen, p1, p2);
                }

                // ====== GIÁ TIỀN ======
                double price = GetFlightPrice(fromId, toId);
                string text = price.ToString("N0");

                float midX = (p1.X + p2.X) / 2;
                float midY = (p1.Y + p2.Y) / 2;

                SizeF size = g.MeasureString(text, Font);

                // Nền trắng cho dễ nhìn
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

            if (animationTimer != null && animationTimer.Enabled)
            {
                g.DrawImage(
                    planeImage,
                    planePosition.X - 15,
                    planePosition.Y - 15,
                    30,
                    30
                );
            }
        }

        // ====== ANIMATION FLY ======


        #endregion

        #region ANIMATION
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentSegment >= shortestPathCityIds.Count - 1)
            {
                animationTimer.Stop();

                MessageBox.Show(
                    $"Lộ trình:\n{finalRouteText}\n\nTổng chi phí: ${finalTotalCost:N0}",
                    "Kết quả tìm đường",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }


            City from = cities.First(c => c.Id == shortestPathCityIds[currentSegment]);
            City to = cities.First(c => c.Id == shortestPathCityIds[currentSegment + 1]);

            PointF p1 = ConvertToPanel(from.Latitude, from.Longitude);
            PointF p2 = ConvertToPanel(to.Latitude, to.Longitude);

            // Nội suy vị trí
            planePosition = new PointF(
                p1.X + (p2.X - p1.X) * t,
                p1.Y + (p2.Y - p1.Y) * t
            );

            t += 0.02f;

            // Khi đi hết đoạn
            if (t >= 1f)
            {
                t = 0f;
                drawnSegments.Add(Tuple.Create(from.Id, to.Id));
                currentSegment++;
            }

            panelHeader.Invalidate();
        }

        private void InitAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 30; // càng nhỏ càng mượt
            animationTimer.Tick += AnimationTimer_Tick;
        }
        #endregion

        #region Events Click

        private void btnAddCity_Click(object sender, EventArgs e)
        {
            btnClean_Click(sender, e);
            frmListCities frm = new frmListCities();
            frm.FormClosing += Frm_FormClosing; 
            frm.Show();
            this.Hide();

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

            finalTotalCost = CalculateTotalCost(path);
            finalRouteText = BuildRouteText(path);

            lblTotalPrice.Text = "$" + finalTotalCost.ToString("N0");
            lblLoTrinh.Text = finalRouteText;

            drawnSegments.Clear();
            currentSegment = 0;
            t = 0f;

            // đặt máy bay ở điểm xuất phát
            City startCity = cities.First(c => c.Id == shortestPathCityIds[0]);
            planePosition = ConvertToPanel(startCity.Latitude, startCity.Longitude);

            animationTimer.Start();

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
            btnClean_Click(sender, e);
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
