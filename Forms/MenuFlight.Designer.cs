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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelFunction = new System.Windows.Forms.Panel();
            this.grbChoice = new System.Windows.Forms.GroupBox();
            this.grbButton = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbStart = new System.Windows.Forms.ComboBox();
            this.cbbEnd = new System.Windows.Forms.ComboBox();
            this.cbbAddition = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelFunction.SuspendLayout();
            this.grbChoice.SuspendLayout();
            this.grbButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackgroundImage = global::ChuyenBayDijkstra.Properties.Resources.windows_wallpaper_27;
            this.panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1300, 900);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // panelFunction
            // 
            this.panelFunction.Controls.Add(this.grbButton);
            this.panelFunction.Controls.Add(this.grbChoice);
            this.panelFunction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFunction.Location = new System.Drawing.Point(0, 636);
            this.panelFunction.Name = "panelFunction";
            this.panelFunction.Size = new System.Drawing.Size(1300, 264);
            this.panelFunction.TabIndex = 1;
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
            this.grbChoice.Name = "grbChoice";
            this.grbChoice.Size = new System.Drawing.Size(1300, 264);
            this.grbChoice.TabIndex = 0;
            this.grbChoice.TabStop = false;
            this.grbChoice.Text = "Lựa Chọn";
            // 
            // grbButton
            // 
            this.grbButton.Controls.Add(this.btnClear);
            this.grbButton.Controls.Add(this.btnExit);
            this.grbButton.Controls.Add(this.btnAdd);
            this.grbButton.Controls.Add(this.btnSearch);
            this.grbButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.grbButton.Location = new System.Drawing.Point(700, 0);
            this.grbButton.Name = "grbButton";
            this.grbButton.Size = new System.Drawing.Size(600, 264);
            this.grbButton.TabIndex = 1;
            this.grbButton.TabStop = false;
            this.grbButton.Text = "Chức Năng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(42, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nơi Xuất Phát";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(42, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Điểm Đến";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(42, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "ĐIỀU KIỆN (NẾU CÓ)";
            // 
            // cbbStart
            // 
            this.cbbStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.cbbStart.FormattingEnabled = true;
            this.cbbStart.Location = new System.Drawing.Point(356, 30);
            this.cbbStart.Name = "cbbStart";
            this.cbbStart.Size = new System.Drawing.Size(273, 34);
            this.cbbStart.TabIndex = 3;
            // 
            // cbbEnd
            // 
            this.cbbEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.cbbEnd.FormattingEnabled = true;
            this.cbbEnd.Location = new System.Drawing.Point(356, 112);
            this.cbbEnd.Name = "cbbEnd";
            this.cbbEnd.Size = new System.Drawing.Size(273, 34);
            this.cbbEnd.TabIndex = 4;
            // 
            // cbbAddition
            // 
            this.cbbAddition.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.cbbAddition.FormattingEnabled = true;
            this.cbbAddition.Location = new System.Drawing.Point(356, 194);
            this.cbbAddition.Name = "cbbAddition";
            this.cbbAddition.Size = new System.Drawing.Size(273, 34);
            this.cbbAddition.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic);
            this.btnSearch.Location = new System.Drawing.Point(62, 42);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(192, 56);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "TÌM KIẾM";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic);
            this.btnAdd.Location = new System.Drawing.Point(350, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(192, 56);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "THÊM ĐIỂM";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic);
            this.btnExit.Location = new System.Drawing.Point(350, 178);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(192, 56);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "THOÁT";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic);
            this.btnClear.Location = new System.Drawing.Point(62, 178);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(192, 56);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "XÓA";
            this.btnClear.UseVisualStyleBackColor = true;
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
            this.Name = "MenuFlight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuFlight";
            this.Load += new System.EventHandler(this.MenuFlight_Load);
            this.panelFunction.ResumeLayout(false);
            this.grbChoice.ResumeLayout(false);
            this.grbChoice.PerformLayout();
            this.grbButton.ResumeLayout(false);
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
    }
}