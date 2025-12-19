namespace ChuyenBayDijkstra.Forms
{
    partial class frmListFlights
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListFlights));
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.grbChucNang = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grbHienThi = new System.Windows.Forms.GroupBox();
            this.cbbDestCity = new System.Windows.Forms.ComboBox();
            this.cbbSourceCity = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblAirline = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.txtAirline = new System.Windows.Forms.TextBox();
            this.txtFlightId = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDestCity = new System.Windows.Forms.Label();
            this.lblSourceCity = new System.Windows.Forms.Label();
            this.lblFlightId = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvFlight = new System.Windows.Forms.DataGridView();
            this.flight_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.source_city_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dest_city_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblListFlights = new System.Windows.Forms.Label();
            this.pnlFooter.SuspendLayout();
            this.grbChucNang.SuspendLayout();
            this.grbHienThi.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlight)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.grbChucNang);
            this.pnlFooter.Controls.Add(this.grbHienThi);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 621);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1282, 232);
            this.pnlFooter.TabIndex = 0;
            // 
            // grbChucNang
            // 
            this.grbChucNang.Controls.Add(this.btnThoat);
            this.grbChucNang.Controls.Add(this.btnXoa);
            this.grbChucNang.Controls.Add(this.btnSua);
            this.grbChucNang.Controls.Add(this.btnThem);
            this.grbChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbChucNang.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbChucNang.Location = new System.Drawing.Point(865, 0);
            this.grbChucNang.Name = "grbChucNang";
            this.grbChucNang.Size = new System.Drawing.Size(417, 232);
            this.grbChucNang.TabIndex = 3;
            this.grbChucNang.TabStop = false;
            this.grbChucNang.Text = "Chức năng";
            // 
            // btnThoat
            // 
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(235, 151);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(135, 38);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(235, 63);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(135, 38);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "XÓA";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(54, 151);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(135, 38);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "SỬA";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(54, 63);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 38);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "THÊM";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // grbHienThi
            // 
            this.grbHienThi.Controls.Add(this.cbbDestCity);
            this.grbHienThi.Controls.Add(this.cbbSourceCity);
            this.grbHienThi.Controls.Add(this.txtPrice);
            this.grbHienThi.Controls.Add(this.lblAirline);
            this.grbHienThi.Controls.Add(this.txtDuration);
            this.grbHienThi.Controls.Add(this.lblDuration);
            this.grbHienThi.Controls.Add(this.txtAirline);
            this.grbHienThi.Controls.Add(this.txtFlightId);
            this.grbHienThi.Controls.Add(this.lblPrice);
            this.grbHienThi.Controls.Add(this.lblDestCity);
            this.grbHienThi.Controls.Add(this.lblSourceCity);
            this.grbHienThi.Controls.Add(this.lblFlightId);
            this.grbHienThi.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbHienThi.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHienThi.Location = new System.Drawing.Point(0, 0);
            this.grbHienThi.Name = "grbHienThi";
            this.grbHienThi.Size = new System.Drawing.Size(865, 232);
            this.grbHienThi.TabIndex = 2;
            this.grbHienThi.TabStop = false;
            this.grbHienThi.Text = "Thông tin chuyến bay";
            // 
            // cbbDestCity
            // 
            this.cbbDestCity.FormattingEnabled = true;
            this.cbbDestCity.Location = new System.Drawing.Point(253, 135);
            this.cbbDestCity.Name = "cbbDestCity";
            this.cbbDestCity.Size = new System.Drawing.Size(241, 34);
            this.cbbDestCity.TabIndex = 13;
            // 
            // cbbSourceCity
            // 
            this.cbbSourceCity.FormattingEnabled = true;
            this.cbbSourceCity.Location = new System.Drawing.Point(253, 89);
            this.cbbSourceCity.Name = "cbbSourceCity";
            this.cbbSourceCity.Size = new System.Drawing.Size(241, 34);
            this.cbbSourceCity.TabIndex = 12;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(682, 81);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(177, 34);
            this.txtPrice.TabIndex = 11;
            // 
            // lblAirline
            // 
            this.lblAirline.AutoSize = true;
            this.lblAirline.Location = new System.Drawing.Point(26, 186);
            this.lblAirline.Name = "lblAirline";
            this.lblAirline.Size = new System.Drawing.Size(182, 26);
            this.lblAirline.TabIndex = 10;
            this.lblAirline.Text = "Hãng hàng không:";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(682, 32);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(177, 34);
            this.txtDuration.TabIndex = 9;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(560, 40);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(107, 26);
            this.lblDuration.TabIndex = 8;
            this.lblDuration.Text = "Thời gian:";
            // 
            // txtAirline
            // 
            this.txtAirline.Location = new System.Drawing.Point(253, 183);
            this.txtAirline.Name = "txtAirline";
            this.txtAirline.Size = new System.Drawing.Size(241, 34);
            this.txtAirline.TabIndex = 7;
            // 
            // txtFlightId
            // 
            this.txtFlightId.Location = new System.Drawing.Point(253, 40);
            this.txtFlightId.Name = "txtFlightId";
            this.txtFlightId.Size = new System.Drawing.Size(173, 34);
            this.txtFlightId.TabIndex = 4;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(560, 84);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(50, 26);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Giá:";
            // 
            // lblDestCity
            // 
            this.lblDestCity.AutoSize = true;
            this.lblDestCity.Location = new System.Drawing.Point(26, 138);
            this.lblDestCity.Name = "lblDestCity";
            this.lblDestCity.Size = new System.Drawing.Size(160, 26);
            this.lblDestCity.TabIndex = 2;
            this.lblDestCity.Text = "Thành phố đến:";
            // 
            // lblSourceCity
            // 
            this.lblSourceCity.AutoSize = true;
            this.lblSourceCity.Location = new System.Drawing.Point(26, 89);
            this.lblSourceCity.Name = "lblSourceCity";
            this.lblSourceCity.Size = new System.Drawing.Size(211, 26);
            this.lblSourceCity.TabIndex = 1;
            this.lblSourceCity.Text = "Thành phố xuất phát:";
            // 
            // lblFlightId
            // 
            this.lblFlightId.AutoSize = true;
            this.lblFlightId.Location = new System.Drawing.Point(26, 40);
            this.lblFlightId.Name = "lblFlightId";
            this.lblFlightId.Size = new System.Drawing.Size(161, 26);
            this.lblFlightId.TabIndex = 0;
            this.lblFlightId.Text = "Mã chuyến bay:";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvFlight);
            this.pnlMain.Controls.Add(this.btnTimKiem);
            this.pnlMain.Controls.Add(this.txtSearch);
            this.pnlMain.Controls.Add(this.lblListFlights);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1282, 621);
            this.pnlMain.TabIndex = 1;
            // 
            // dgvFlight
            // 
            this.dgvFlight.AllowUserToAddRows = false;
            this.dgvFlight.AllowUserToDeleteRows = false;
            this.dgvFlight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.flight_id,
            this.source_city_id,
            this.dest_city_id,
            this.price,
            this.duration,
            this.airline});
            this.dgvFlight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvFlight.Location = new System.Drawing.Point(0, 116);
            this.dgvFlight.Name = "dgvFlight";
            this.dgvFlight.ReadOnly = true;
            this.dgvFlight.RowHeadersWidth = 51;
            this.dgvFlight.RowTemplate.Height = 24;
            this.dgvFlight.Size = new System.Drawing.Size(1282, 505);
            this.dgvFlight.TabIndex = 7;
            this.dgvFlight.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFlight_CellClick);
            // 
            // flight_id
            // 
            this.flight_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.flight_id.DataPropertyName = "flight_id";
            this.flight_id.HeaderText = "Mã chuyến bay";
            this.flight_id.MinimumWidth = 6;
            this.flight_id.Name = "flight_id";
            this.flight_id.ReadOnly = true;
            // 
            // source_city_id
            // 
            this.source_city_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.source_city_id.DataPropertyName = "source_city_id";
            this.source_city_id.HeaderText = "Mã thành phố xuất phát";
            this.source_city_id.MinimumWidth = 6;
            this.source_city_id.Name = "source_city_id";
            this.source_city_id.ReadOnly = true;
            // 
            // dest_city_id
            // 
            this.dest_city_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dest_city_id.DataPropertyName = "dest_city_id";
            this.dest_city_id.HeaderText = "Mã thành phố đến";
            this.dest_city_id.MinimumWidth = 6;
            this.dest_city_id.Name = "dest_city_id";
            this.dest_city_id.ReadOnly = true;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "Giá tiền ($)";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // duration
            // 
            this.duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.duration.DataPropertyName = "duration";
            this.duration.HeaderText = "Thời gian bay dự kiến (phút)";
            this.duration.MinimumWidth = 6;
            this.duration.Name = "duration";
            this.duration.ReadOnly = true;
            // 
            // airline
            // 
            this.airline.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.airline.DataPropertyName = "airline";
            this.airline.HeaderText = "Hãng hàng không";
            this.airline.MinimumWidth = 6;
            this.airline.Name = "airline";
            this.airline.ReadOnly = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(1171, 61);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(95, 34);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(899, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(266, 34);
            this.txtSearch.TabIndex = 5;
            // 
            // lblListFlights
            // 
            this.lblListFlights.AutoSize = true;
            this.lblListFlights.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListFlights.ForeColor = System.Drawing.Color.LightCoral;
            this.lblListFlights.Location = new System.Drawing.Point(437, 9);
            this.lblListFlights.Name = "lblListFlights";
            this.lblListFlights.Size = new System.Drawing.Size(477, 35);
            this.lblListFlights.TabIndex = 4;
            this.lblListFlights.Text = "DANH SÁCH CÁC CHUYẾN BAY";
            // 
            // frmListFlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 853);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListFlights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DANH SÁCH CHUYẾN BAY";
            this.Load += new System.EventHandler(this.frmListFlights_Load);
            this.pnlFooter.ResumeLayout(false);
            this.grbChucNang.ResumeLayout(false);
            this.grbHienThi.ResumeLayout(false);
            this.grbHienThi.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grbChucNang;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox grbHienThi;
        private System.Windows.Forms.TextBox txtAirline;
        private System.Windows.Forms.TextBox txtFlightId;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDestCity;
        private System.Windows.Forms.Label lblSourceCity;
        private System.Windows.Forms.Label lblFlightId;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblAirline;
        private System.Windows.Forms.DataGridView dgvFlight;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblListFlights;
        private System.Windows.Forms.DataGridViewTextBoxColumn flight_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn source_city_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dest_city_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn airline;
        private System.Windows.Forms.ComboBox cbbDestCity;
        private System.Windows.Forms.ComboBox cbbSourceCity;
    }
}