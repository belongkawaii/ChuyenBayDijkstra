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
using static ChuyenBayDijkstra.Forms.MenuFlight;
using Flight = ChuyenBayDijkstra.DatabaseScript.Flight;

namespace ChuyenBayDijkstra.Forms
{
    public partial class frmListFlights : Form
    {
        public frmListFlights()
        {
            InitializeComponent();
        }

        #region LoadData
        private void frmListFlights_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            FlightDijkstraDataContext db = new FlightDijkstraDataContext();
            dgvFlight.AutoGenerateColumns = false;

            dgvFlight.DataSource = db.Flights.OrderBy(p => p.flight_id);

            if (db.Flights.ToList().Count > 0)
            {
                hienThiDuLieuDong(0);
            }
        }

        private void dgvFlight_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idRow = e.RowIndex;
            if (idRow == -1)
            {
                return;
            }
            else
            {
                hienThiDuLieuDong(idRow);
            }
        }

        
        private void hienThiDuLieuDong(int idRow)
        {
            FlightDijkstraDataContext db = new FlightDijkstraDataContext();
            int idFlight = Convert.ToInt32(dgvFlight.Rows[idRow].Cells[0].Value);

            Flight f = db.Flights.Where(p => p.flight_id == idFlight).SingleOrDefault();

            if (f != null)
            {
                loadSourceCityComboBox();
                loadDestCityComboBox();

                txtFlightId.Text = f.flight_id.ToString();
                cbbSourceCity.SelectedValue = f.source_city_id;
                cbbDestCity.SelectedValue = f.dest_city_id;
                txtPrice.Text = f.price.ToString();
                txtDuration.Text = f.duration.ToString();
                txtAirline.Text = f.airline;
            }

        }

        private void loadSourceCityComboBox()
        {
            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            var cities = db.Cities
                           .Select(c => new
                           {
                               c.city_id,
                               c.name
                           })
                           .ToList();

            cbbSourceCity.DataSource = cities;
            cbbSourceCity.DisplayMember = "name"; // HIỂN THỊ
            cbbSourceCity.ValueMember = "city_id";     // GIÁ TRỊ THẬT
        }

        private void loadDestCityComboBox()
        {
            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            var cities = db.Cities
                           .Select(c => new
                           {
                               c.city_id,
                               c.name
                           })
                           .ToList();

            cbbDestCity.DataSource = cities;
            cbbDestCity.DisplayMember = "name"; // HIỂN THỊ
            cbbDestCity.ValueMember = "city_id";     // GIÁ TRỊ THẬT
        }


        #endregion

        #region Enven Click

        //Them vao 1 chuyen bay neu ma chuyen bay chua ton tai
        private void btnThem_Click(object sender, EventArgs e)
        {
            int idFlight = Convert.ToInt32(txtFlightId.Text);
            int sourceCity = Convert.ToInt32(cbbSourceCity.SelectedValue);
            int destCity = Convert.ToInt32(cbbDestCity.SelectedValue);
            float price = Convert.ToSingle(txtPrice.Text);
            int duration = Convert.ToInt32(txtDuration.Text);
            string airline = txtAirline.Text;

            string sourceCity1 = cbbSourceCity.Text;
            string destCity1 = cbbDestCity.Text;

            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            Flight f = db.Flights.Where(p => p.flight_id == idFlight).SingleOrDefault();

            if (f != null)
            {
                MessageBox.Show("Mã chuyến bay đã tồn tại! Bạn vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFlightId.Focus();
                return;
            }
            else
            {
                f = new Flight();
                f.flight_id = idFlight;
                f.source_city_id = sourceCity;
                f.dest_city_id = destCity;
                f.price = price;
                f.duration = duration;
                f.airline = airline;

                db.Flights.InsertOnSubmit(f);
                db.SubmitChanges();

                loadData();
                MessageBox.Show($"Bạn đã thêm chuyến bay mới từ {sourceCity1} đến {destCity1} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Xoa chuyen bay theo ma chuyen bay
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idFlight = Convert.ToInt32(txtFlightId.Text);
            string sourceCity = cbbSourceCity.Text;
            string destCity = cbbDestCity.Text;

            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            Flight f = db.Flights.Where(p => p.flight_id == idFlight).SingleOrDefault();

            if (f == null)
            {
                MessageBox.Show("Mã chuyến bay không tồn tại! Bạn vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFlightId.Focus();
                return;
            }
            else
            {
                    db.Flights.DeleteOnSubmit(f);
                    db.SubmitChanges();
                    loadData();
                    MessageBox.Show($"Bạn đã xóa chuyến bay từ thành phố {sourceCity} đến thành phố {destCity} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Sua chuyen bay theo ma chuyen bay (chi duoc sua gia tien, thoi gian, hang hang khong)
        private void btnSua_Click(object sender, EventArgs e)
        {
            int idFlight = Convert.ToInt32(txtFlightId.Text);
            int sourceCity = Convert.ToInt32(cbbSourceCity.SelectedValue);
            int destCity = Convert.ToInt32(cbbDestCity.SelectedValue);
            float price = Convert.ToSingle(txtPrice.Text);
            int duration = Convert.ToInt32(txtDuration.Text);
            string airline = txtAirline.Text;

            string sourceCity1 = cbbSourceCity.Text;
            string destCity1 = cbbDestCity.Text;

            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            Flight f = db.Flights.Where(p => p.flight_id == idFlight).SingleOrDefault();

            if (f == null)
            {
                MessageBox.Show("Mã chuyến bay không tồn tại! Bạn vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFlightId.Focus();
                return;
            }
            else
            {   
                f.price = price;
                f.duration = duration;
                f.airline = airline;

                db.SubmitChanges();

                loadData();
                MessageBox.Show($"Bạn đã sửa thông tin chuyến bay từ thành phố {sourceCity1} đến thành phố {destCity1} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Tim kiem theo ma chuyen bay || Ten thanh pho di va den
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            // Không nhập gì → load lại toàn bộ
            if (string.IsNullOrEmpty(keyword))
            {
                loadData();
                return;
            }

            // Kiểm tra keyword có phải số không (để tìm theo mã chuyến bay)
            int idFlight;
            bool isNumber = int.TryParse(keyword, out idFlight);

            var result =
                            from f in db.Flights
                            join c1 in db.Cities on f.source_city_id equals c1.city_id
                            join c2 in db.Cities on f.dest_city_id equals c2.city_id
                            where
                                (isNumber && f.flight_id == idFlight)
                                || c1.name.ToLower().Contains(keyword.ToLower())
                                || c2.name.ToLower().Contains(keyword.ToLower())
                            select new
                            {
                                f.flight_id,
                                SourceCity = c1.name,
                                DestCity = c2.name,
                                f.price,
                                f.duration,
                                f.airline
                            };

            var list = result.ToList();

            if (list.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy chuyến bay phù hợp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            dgvFlight.DataSource = list;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

    }
}
