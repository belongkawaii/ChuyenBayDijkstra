namespace ChuyenBayDijkstra.Forms
{
    partial class MenuFlight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuFlight));
            this.panelFunction = new System.Windows.Forms.Panel();
            this.grbButton = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grbChoice = new System.Windows.Forms.GroupBox();
            this.cbbAddition = new System.Windows.Forms.ComboBox();
            this.cbbEnd = new System.Windows.Forms.ComboBox();
            this.cbbStart = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblLoTrinh = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lbltext = new System.Windows.Forms.Label();
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.panelFunction.SuspendLayout();
            this.grbButton.SuspendLayout();
            this.grbChoice.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFunction
            // 
            this.panelFunction.Controls.Add(this.grbButton);
            this.panelFunction.Controls.Add(this.grbChoice);
            this.panelFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFunction.Location = new System.Drawing.Point(0, 647);
            this.panelFunction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelFunction.Name = "panelFunction";
            this.panelFunction.Size = new System.Drawing.Size(1300, 253);
            this.panelFunction.TabIndex = 1;
            // 
            // grbButton
            // 
            this.grbButton.Controls.Add(this.btnAddFlight);
            this.grbButton.Controls.Add(this.btnClear);
            this.grbButton.Controls.Add(this.btnExit);
            this.grbButton.Controls.Add(this.btnAdd);
            this.grbButton.Controls.Add(this.btnSearch);
            this.grbButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.grbButton.Location = new System.Drawing.Point(700, 0);
            this.grbButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbButton.Name = "grbButton";
            this.grbButton.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbButton.Size = new System.Drawing.Size(600, 253);
            this.grbButton.TabIndex = 1;
            this.grbButton.TabStop = false;
            this.grbButton.Text = "Chức Năng";
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic);
            this.btnClear.Location = new System.Drawing.Point(61, 116);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(192, 57);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "XÓA";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic);
            this.btnExit.Location = new System.Drawing.Point(203, 185);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(192, 57);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "THOÁT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(349, 42);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(192, 57);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "THÊM THÀNH PHỐ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic);
            this.btnSearch.Location = new System.Drawing.Point(61, 42);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(192, 57);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "TÌM KIẾM";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grbChoice
            // 
            this.grbChoice.Controls.Add(this.cbbAddition);
            this.grbChoice.Controls.Add(this.cbbEnd);
            this.grbChoice.Controls.Add(this.cbbStart);
            this.grbChoice.Controls.Add(this.label3);
            this.grbChoice.Controls.Add(this.label2);
            this.grbChoice.Controls.Add(this.label1);
            this.grbChoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbChoice.Location = new System.Drawing.Point(0, 0);
            this.grbChoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbChoice.Name = "grbChoice";
            this.grbChoice.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbChoice.Size = new System.Drawing.Size(1300, 253);
            this.grbChoice.TabIndex = 0;
            this.grbChoice.TabStop = false;
            this.grbChoice.Text = "Lựa Chọn";
            // 
            // cbbAddition
            // 
            this.cbbAddition.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.cbbAddition.FormattingEnabled = true;
            this.cbbAddition.Location = new System.Drawing.Point(399, 188);
            this.cbbAddition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbAddition.Name = "cbbAddition";
            this.cbbAddition.Size = new System.Drawing.Size(273, 39);
            this.cbbAddition.TabIndex = 5;
            // 
            // cbbEnd
            // 
            this.cbbEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.cbbEnd.FormattingEnabled = true;
            this.cbbEnd.Location = new System.Drawing.Point(399, 112);
            this.cbbEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbEnd.Name = "cbbEnd";
            this.cbbEnd.Size = new System.Drawing.Size(273, 39);
            this.cbbEnd.TabIndex = 4;
            // 
            // cbbStart
            // 
            this.cbbStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.cbbStart.FormattingEnabled = true;
            this.cbbStart.Location = new System.Drawing.Point(399, 21);
            this.cbbStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbStart.Name = "cbbStart";
            this.cbbStart.Size = new System.Drawing.Size(273, 39);
            this.cbbStart.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(53, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "ĐIỀU KIỆN (NẾU CÓ)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(53, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Điểm Đến";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(53, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nơi Xuất Phát";
            // 
            // panelHeader
            // 
            this.panelHeader.BackgroundImage = global::ChuyenBayDijkstra.Properties.Resources.Background;
            this.panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeader.Controls.Add(this.lblLoTrinh);
            this.panelHeader.Controls.Add(this.lblTotalPrice);
            this.panelHeader.Controls.Add(this.lbltext);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1300, 647);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // lblLoTrinh
            // 
            this.lblLoTrinh.AutoSize = true;
            this.lblLoTrinh.BackColor = System.Drawing.Color.Transparent;
            this.lblLoTrinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoTrinh.Location = new System.Drawing.Point(25, 586);
            this.lblLoTrinh.Name = "lblLoTrinh";
            this.lblLoTrinh.Size = new System.Drawing.Size(0, 32);
            this.lblLoTrinh.TabIndex = 3;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.BackColor = System.Drawing.Color.White;
            this.lblTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(245, 9);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(48, 32);
            this.lblTotalPrice.TabIndex = 2;
            this.lblTotalPrice.Text = "$0";
            // 
            // lbltext
            // 
            this.lbltext.AutoSize = true;
            this.lbltext.BackColor = System.Drawing.Color.Transparent;
            this.lbltext.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltext.Location = new System.Drawing.Point(6, 10);
            this.lbltext.Name = "lbltext";
            this.lbltext.Size = new System.Drawing.Size(223, 32);
            this.lbltext.TabIndex = 1;
            this.lbltext.Text = "TỔNG CHI PHÍ:";
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFlight.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFlight.Location = new System.Drawing.Point(349, 116);
            this.btnAddFlight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.Size = new System.Drawing.Size(192, 57);
            this.btnAddFlight.TabIndex = 4;
            this.btnAddFlight.Text = "THÊM CHUYẾN BAY";
            this.btnAddFlight.UseVisualStyleBackColor = true;
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);
            // 
            // MenuFlight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 900);
            this.Controls.Add(this.panelFunction);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuFlight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuFlight";
            this.Load += new System.EventHandler(this.MenuFlight_Load);
            this.panelFunction.ResumeLayout(false);
            this.grbButton.ResumeLayout(false);
            this.grbChoice.ResumeLayout(false);
            this.grbChoice.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelFunction;
        private System.Windows.Forms.GroupBox grbButton;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grbChoice;
        private System.Windows.Forms.ComboBox cbbAddition;
        private System.Windows.Forms.ComboBox cbbEnd;
        private System.Windows.Forms.ComboBox cbbStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbltext;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblLoTrinh;
        private System.Windows.Forms.Button btnAddFlight;
    }
}