namespace ChuyenBayDijkstra.Forms
{
    partial class frmListCities
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
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.grbChucNang = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grbHienThi = new System.Windows.Forms.GroupBox();
            this.txtLatitude = new System.Windows.Forms.TextBox();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.txtLongitude = new System.Windows.Forms.TextBox();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.txtCodeAir = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.txtCityName = new System.Windows.Forms.TextBox();
            this.txtCityId = new System.Windows.Forms.TextBox();
            this.lblCodeAir = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCityName = new System.Windows.Forms.Label();
            this.lblCityId = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblListCities = new System.Windows.Forms.Label();
            this.dgvListCities = new System.Windows.Forms.DataGridView();
            this.city_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airport_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter.SuspendLayout();
            this.grbChucNang.SuspendLayout();
            this.grbHienThi.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCities)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.grbChucNang);
            this.pnlFooter.Controls.Add(this.grbHienThi);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 478);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1072, 218);
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
            this.grbChucNang.Location = new System.Drawing.Point(687, 0);
            this.grbChucNang.Name = "grbChucNang";
            this.grbChucNang.Size = new System.Drawing.Size(385, 218);
            this.grbChucNang.TabIndex = 1;
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
            this.grbHienThi.Controls.Add(this.txtLatitude);
            this.grbHienThi.Controls.Add(this.lblLatitude);
            this.grbHienThi.Controls.Add(this.txtLongitude);
            this.grbHienThi.Controls.Add(this.lblLongitude);
            this.grbHienThi.Controls.Add(this.txtCodeAir);
            this.grbHienThi.Controls.Add(this.txtCountry);
            this.grbHienThi.Controls.Add(this.txtCityName);
            this.grbHienThi.Controls.Add(this.txtCityId);
            this.grbHienThi.Controls.Add(this.lblCodeAir);
            this.grbHienThi.Controls.Add(this.lblCountry);
            this.grbHienThi.Controls.Add(this.lblCityName);
            this.grbHienThi.Controls.Add(this.lblCityId);
            this.grbHienThi.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbHienThi.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHienThi.Location = new System.Drawing.Point(0, 0);
            this.grbHienThi.Name = "grbHienThi";
            this.grbHienThi.Size = new System.Drawing.Size(687, 218);
            this.grbHienThi.TabIndex = 0;
            this.grbHienThi.TabStop = false;
            this.grbHienThi.Text = "Thông tin thành phố";
            // 
            // txtLatitude
            // 
            this.txtLatitude.Location = new System.Drawing.Point(537, 82);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(130, 34);
            this.txtLatitude.TabIndex = 11;
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(437, 89);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(70, 26);
            this.lblLatitude.TabIndex = 10;
            this.lblLatitude.Text = "Vĩ độ:";
            // 
            // txtLongitude
            // 
            this.txtLongitude.Location = new System.Drawing.Point(537, 33);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(130, 34);
            this.txtLongitude.TabIndex = 9;
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new System.Drawing.Point(437, 40);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(94, 26);
            this.lblLongitude.TabIndex = 8;
            this.lblLongitude.Text = "Kinh độ:";
            // 
            // txtCodeAir
            // 
            this.txtCodeAir.Location = new System.Drawing.Point(185, 175);
            this.txtCodeAir.Name = "txtCodeAir";
            this.txtCodeAir.Size = new System.Drawing.Size(231, 34);
            this.txtCodeAir.TabIndex = 7;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(185, 130);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(231, 34);
            this.txtCountry.TabIndex = 6;
            // 
            // txtCityName
            // 
            this.txtCityName.Location = new System.Drawing.Point(185, 81);
            this.txtCityName.Name = "txtCityName";
            this.txtCityName.Size = new System.Drawing.Size(231, 34);
            this.txtCityName.TabIndex = 5;
            // 
            // txtCityId
            // 
            this.txtCityId.Location = new System.Drawing.Point(185, 32);
            this.txtCityId.Name = "txtCityId";
            this.txtCityId.Size = new System.Drawing.Size(128, 34);
            this.txtCityId.TabIndex = 4;
            // 
            // lblCodeAir
            // 
            this.lblCodeAir.AutoSize = true;
            this.lblCodeAir.Location = new System.Drawing.Point(26, 183);
            this.lblCodeAir.Name = "lblCodeAir";
            this.lblCodeAir.Size = new System.Drawing.Size(130, 26);
            this.lblCodeAir.TabIndex = 3;
            this.lblCodeAir.Text = "Mã sân bay: ";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(26, 138);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(108, 26);
            this.lblCountry.TabIndex = 2;
            this.lblCountry.Text = "Quốc gia: ";
            // 
            // lblCityName
            // 
            this.lblCityName.AutoSize = true;
            this.lblCityName.Location = new System.Drawing.Point(26, 89);
            this.lblCityName.Name = "lblCityName";
            this.lblCityName.Size = new System.Drawing.Size(160, 26);
            this.lblCityName.TabIndex = 1;
            this.lblCityName.Text = "Tên thành phố: ";
            // 
            // lblCityId
            // 
            this.lblCityId.AutoSize = true;
            this.lblCityId.Location = new System.Drawing.Point(26, 40);
            this.lblCityId.Name = "lblCityId";
            this.lblCityId.Size = new System.Drawing.Size(153, 26);
            this.lblCityId.TabIndex = 0;
            this.lblCityId.Text = "Mã thành phố: ";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnTimKiem);
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Controls.Add(this.lblListCities);
            this.pnlHeader.Controls.Add(this.dgvListCities);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1072, 478);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(965, 77);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(95, 34);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(693, 77);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(266, 34);
            this.txtSearch.TabIndex = 2;
            // 
            // lblListCities
            // 
            this.lblListCities.AutoSize = true;
            this.lblListCities.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListCities.ForeColor = System.Drawing.Color.LightCoral;
            this.lblListCities.Location = new System.Drawing.Point(310, 9);
            this.lblListCities.Name = "lblListCities";
            this.lblListCities.Size = new System.Drawing.Size(459, 35);
            this.lblListCities.TabIndex = 1;
            this.lblListCities.Text = "DANH SÁCH CÁC THÀNH PHỐ";
            // 
            // dgvListCities
            // 
            this.dgvListCities.AllowUserToAddRows = false;
            this.dgvListCities.AllowUserToDeleteRows = false;
            this.dgvListCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListCities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.city_id,
            this.name,
            this.country,
            this.airport_code,
            this.latitude,
            this.longitude});
            this.dgvListCities.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListCities.Location = new System.Drawing.Point(0, 117);
            this.dgvListCities.Name = "dgvListCities";
            this.dgvListCities.ReadOnly = true;
            this.dgvListCities.RowHeadersWidth = 51;
            this.dgvListCities.RowTemplate.Height = 24;
            this.dgvListCities.Size = new System.Drawing.Size(1072, 361);
            this.dgvListCities.TabIndex = 0;
            this.dgvListCities.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListCities_CellClick);
            // 
            // city_id
            // 
            this.city_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.city_id.DataPropertyName = "city_id";
            this.city_id.HeaderText = "Mã thành phố";
            this.city_id.MinimumWidth = 6;
            this.city_id.Name = "city_id";
            this.city_id.ReadOnly = true;
            this.city_id.Width = 116;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Tên thành phố";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // country
            // 
            this.country.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.country.DataPropertyName = "country";
            this.country.HeaderText = "Quốc gia";
            this.country.MinimumWidth = 6;
            this.country.Name = "country";
            this.country.ReadOnly = true;
            // 
            // airport_code
            // 
            this.airport_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.airport_code.DataPropertyName = "airport_code";
            this.airport_code.HeaderText = "Mã sân bay";
            this.airport_code.MinimumWidth = 6;
            this.airport_code.Name = "airport_code";
            this.airport_code.ReadOnly = true;
            this.airport_code.Width = 106;
            // 
            // latitude
            // 
            this.latitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.latitude.DataPropertyName = "latitude";
            this.latitude.HeaderText = "Vĩ độ";
            this.latitude.MinimumWidth = 6;
            this.latitude.Name = "latitude";
            this.latitude.ReadOnly = true;
            // 
            // longitude
            // 
            this.longitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.longitude.DataPropertyName = "longitude";
            this.longitude.HeaderText = "Kinh độ";
            this.longitude.MinimumWidth = 6;
            this.longitude.Name = "longitude";
            this.longitude.ReadOnly = true;
            // 
            // frmListCities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 696);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Name = "frmListCities";
            this.Text = "Danh sách các thành phố";
            this.Load += new System.EventHandler(this.frmListCities_Load);
            this.pnlFooter.ResumeLayout(false);
            this.grbChucNang.ResumeLayout(false);
            this.grbHienThi.ResumeLayout(false);
            this.grbHienThi.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.GroupBox grbHienThi;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.DataGridView dgvListCities;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblListCities;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox grbChucNang;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblCityId;
        private System.Windows.Forms.Label lblCodeAir;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCityName;
        private System.Windows.Forms.TextBox txtCodeAir;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TextBox txtCityName;
        private System.Windows.Forms.TextBox txtCityId;
        private System.Windows.Forms.TextBox txtLatitude;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.TextBox txtLongitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn city_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn airport_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitude;
    }
}