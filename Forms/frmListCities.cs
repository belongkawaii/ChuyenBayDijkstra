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

namespace ChuyenBayDijkstra.Forms
{
    public partial class frmListCities : Form
    {
        public frmListCities()
        {
            InitializeComponent();
        }

        #region Load Data
        private void frmListCities_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            FlightDijkstraDataContext db = new FlightDijkstraDataContext();
            dgvListCities.DataSource = db.Cities.OrderBy(p => p.city_id);
            if(db.Cities.ToList().Count > 0)
            {
                hienThiDuLieuDong(0);
            }
        }

        private void dgvListCities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idRow = e.RowIndex;
            if(idRow == -1)
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
            int idCity = Convert.ToInt32(dgvListCities.Rows[idRow].Cells[0].Value);

            City city = db.Cities.Where(p => p.city_id == idCity).SingleOrDefault();

            if(city != null)
            {
                txtCityId.Text = city.city_id.ToString();
                txtCityName.Text = city.name;
                txtCountry.Text = city.country;
                txtCodeAir.Text = city.airport_code;
                txtLatitude.Text = city.latitude.ToString();
                txtLongitude.Text = city.longitude.ToString();
            }

        }

        #endregion

        #region Event Click
        //Thoat -> Quay ve form chinh
        private void btnThoat_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        //Them vao 1 thanh pho neu du lieu hop le
        private void btnThem_Click(object sender, EventArgs e)
        {
            int idCity = Convert.ToInt32(txtCityId.Text);
            string nameCity = txtCityName.Text;
            string country = txtCountry.Text;
            string airCode = txtCodeAir.Text;
            float latitude = Convert.ToSingle(txtLatitude.Text);
            float longitude = Convert.ToSingle(txtLongitude.Text);

            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            City city = db.Cities.Where(p => p.city_id == idCity).SingleOrDefault();

            if(city != null)
            {
                MessageBox.Show("Mã thành phố đã tồn tại! Bạn vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCityId.Focus();
                return;
            }
            else
            {
                city = new City();
                city.city_id = idCity;
                city.name = nameCity;
                city.country = country;
                city.airport_code = airCode;
                city.latitude = latitude;
                city.longitude = longitude;

                db.Cities.InsertOnSubmit(city);
                db.SubmitChanges();

                loadData();
                MessageBox.Show($"Bạn đã thêm thành phố {nameCity} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Xoa 1 thanh pho
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idCity = Convert.ToInt32(txtCityId.Text);
            string nameCity = txtCityName.Text;

            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            City city = db.Cities.Where(p => p.city_id == idCity).SingleOrDefault();

            if (city == null)
            {
                MessageBox.Show("Mã thành phố không tồn tại! Bạn vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCityId.Focus();
                return;
            }
            else
            {
                bool isUsed = db.Flights.Any(f => f.source_city_id == idCity || f.dest_city_id == idCity);

                if (isUsed)
                {
                    DialogResult rs = MessageBox.Show(
                        "Thành phố này đang được sử dụng.\n" +
                        "Nếu xóa, toàn bộ dữ liệu liên quan sẽ bị xóa theo.\n\n" +
                        "Bạn có chắc chắn muốn tiếp tục?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (rs == DialogResult.No)
                        return;

                    // Xóa tất cả flight liên quan
                    var flights = db.Flights.Where(f => f.source_city_id == idCity || f.dest_city_id == idCity);

                    db.Flights.DeleteAllOnSubmit(flights);

                    db.Cities.DeleteOnSubmit(city);
                    db.SubmitChanges();
                    loadData();
                    MessageBox.Show($"Bạn đã xóa thành phố {nameCity} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    db.Cities.DeleteOnSubmit(city);
                    db.SubmitChanges();
                    loadData();
                    MessageBox.Show($"Bạn đã xóa thành phố {nameCity} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
        }

        //Sua thong tin nao do cua thanh pho da co trong db (tru id)
        private void btnSua_Click(object sender, EventArgs e)
        {
            int idCity = Convert.ToInt32(txtCityId.Text);
            string nameCity = txtCityName.Text;
            string country = txtCountry.Text;
            string airCode = txtCodeAir.Text;
            float latitude = Convert.ToSingle(txtLatitude.Text);
            float longitude = Convert.ToSingle(txtLongitude.Text);

            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            City city = db.Cities.Where(p => p.city_id == idCity).SingleOrDefault();

            if (city == null)
            {
                MessageBox.Show("Mã thành phố không tồn tại! Bạn vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCityId.Focus();
                return;
            }
            else
            {
                city.name = nameCity;
                city.country = country;
                city.airport_code = airCode;
                city.latitude = latitude;
                city.longitude = longitude;

                db.SubmitChanges();

                loadData();
                MessageBox.Show($"Bạn đã sửa thông tin thành phố {nameCity} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Tìm theo tên thành phố
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            FlightDijkstraDataContext db = new FlightDijkstraDataContext();

            // Nếu không nhập gì → load lại toàn bộ
            if (string.IsNullOrEmpty(keyword))
            {
                loadData();
                return;
            }

            // Kiểm tra keyword có phải số không (để tìm theo ID)
            int id;
            bool isNumber = int.TryParse(keyword, out id);

            var result = db.Cities.Where(c => c.name.ToLower().Contains(keyword.ToLower()) || (isNumber && c.city_id == id)).ToList();

            if (result.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy thành phố phù hợp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }

            dgvListCities.DataSource = result;
        }

        #endregion

        
    }
}
