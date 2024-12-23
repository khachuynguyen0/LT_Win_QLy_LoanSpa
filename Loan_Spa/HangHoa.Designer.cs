namespace Loan_Spa
{
    partial class HangHoa
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
            this.menuStrip_loanSpa = new System.Windows.Forms.MenuStrip();
            this.tổngQuanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngHóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dịchVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giaoDịchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuNhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đốiTácToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgv_hangHoa = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_thongTinHangHoa = new System.Windows.Forms.Label();
            this.btn_xoaHH = new System.Windows.Forms.Button();
            this.btn_suaHH = new System.Windows.Forms.Button();
            this.btn_themHH = new System.Windows.Forms.Button();
            this.txt_SLTon = new System.Windows.Forms.TextBox();
            this.txt_giaMua = new System.Windows.Forms.TextBox();
            this.txt_tenHH = new System.Windows.Forms.TextBox();
            this.txt_maHH = new System.Windows.Forms.TextBox();
            this.lbl_SLTon = new System.Windows.Forms.Label();
            this.lbl_giaMua = new System.Windows.Forms.Label();
            this.lbl_tenHH = new System.Windows.Forms.Label();
            this.lbl_maHH = new System.Windows.Forms.Label();
            this.menuStrip_loanSpa.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_hangHoa)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_loanSpa
            // 
            this.menuStrip_loanSpa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.menuStrip_loanSpa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.menuStrip_loanSpa.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip_loanSpa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tổngQuanToolStripMenuItem,
            this.hàngHóaToolStripMenuItem,
            this.dịchVụToolStripMenuItem,
            this.giaoDịchToolStripMenuItem,
            this.đốiTácToolStripMenuItem,
            this.báoCáoToolStripMenuItem});
            this.menuStrip_loanSpa.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_loanSpa.Name = "menuStrip_loanSpa";
            this.menuStrip_loanSpa.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip_loanSpa.Size = new System.Drawing.Size(976, 31);
            this.menuStrip_loanSpa.TabIndex = 1;
            this.menuStrip_loanSpa.Text = "menuStrip1";
            // 
            // tổngQuanToolStripMenuItem
            // 
            this.tổngQuanToolStripMenuItem.Name = "tổngQuanToolStripMenuItem";
            this.tổngQuanToolStripMenuItem.Size = new System.Drawing.Size(112, 27);
            this.tổngQuanToolStripMenuItem.Text = "Tổng Quan";
            // 
            // hàngHóaToolStripMenuItem
            // 
            this.hàngHóaToolStripMenuItem.Name = "hàngHóaToolStripMenuItem";
            this.hàngHóaToolStripMenuItem.Size = new System.Drawing.Size(104, 27);
            this.hàngHóaToolStripMenuItem.Text = "Hàng Hóa";
            // 
            // dịchVụToolStripMenuItem
            // 
            this.dịchVụToolStripMenuItem.Name = "dịchVụToolStripMenuItem";
            this.dịchVụToolStripMenuItem.Size = new System.Drawing.Size(86, 27);
            this.dịchVụToolStripMenuItem.Text = "Dịch Vụ";
            // 
            // giaoDịchToolStripMenuItem
            // 
            this.giaoDịchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hóaĐơnToolStripMenuItem,
            this.phiếuNhậpHàngToolStripMenuItem});
            this.giaoDịchToolStripMenuItem.Name = "giaoDịchToolStripMenuItem";
            this.giaoDịchToolStripMenuItem.Size = new System.Drawing.Size(101, 27);
            this.giaoDịchToolStripMenuItem.Text = "Giao Dịch";
            // 
            // hóaĐơnToolStripMenuItem
            // 
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            this.hóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(234, 28);
            this.hóaĐơnToolStripMenuItem.Text = "Hóa Đơn";
            // 
            // phiếuNhậpHàngToolStripMenuItem
            // 
            this.phiếuNhậpHàngToolStripMenuItem.Name = "phiếuNhậpHàngToolStripMenuItem";
            this.phiếuNhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(234, 28);
            this.phiếuNhậpHàngToolStripMenuItem.Text = "Phiếu Nhập Hàng";
            // 
            // đốiTácToolStripMenuItem
            // 
            this.đốiTácToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kháchHàngToolStripMenuItem,
            this.nhàCungCấpToolStripMenuItem});
            this.đốiTácToolStripMenuItem.Name = "đốiTácToolStripMenuItem";
            this.đốiTácToolStripMenuItem.Size = new System.Drawing.Size(83, 27);
            this.đốiTácToolStripMenuItem.Text = "Đối Tác";
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(209, 28);
            this.kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            // 
            // nhàCungCấpToolStripMenuItem
            // 
            this.nhàCungCấpToolStripMenuItem.Name = "nhàCungCấpToolStripMenuItem";
            this.nhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(209, 28);
            this.nhàCungCấpToolStripMenuItem.Text = "Nhà Cung Cấp";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(89, 27);
            this.báoCáoToolStripMenuItem.Text = "Báo Cáo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgv_hangHoa);
            this.panel1.Location = new System.Drawing.Point(9, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 403);
            this.panel1.TabIndex = 2;
            // 
            // dtgv_hangHoa
            // 
            this.dtgv_hangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgv_hangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_hangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgv_hangHoa.Location = new System.Drawing.Point(0, 0);
            this.dtgv_hangHoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgv_hangHoa.Name = "dtgv_hangHoa";
            this.dtgv_hangHoa.RowHeadersWidth = 62;
            this.dtgv_hangHoa.RowTemplate.Height = 28;
            this.dtgv_hangHoa.Size = new System.Drawing.Size(428, 403);
            this.dtgv_hangHoa.TabIndex = 0;
            this.dtgv_hangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_hangHoa_CellClick);
            this.dtgv_hangHoa.SelectionChanged += new System.EventHandler(this.Dtgv_hangHoa_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_thongTinHangHoa);
            this.panel2.Controls.Add(this.btn_xoaHH);
            this.panel2.Controls.Add(this.btn_suaHH);
            this.panel2.Controls.Add(this.btn_themHH);
            this.panel2.Controls.Add(this.txt_SLTon);
            this.panel2.Controls.Add(this.txt_giaMua);
            this.panel2.Controls.Add(this.txt_tenHH);
            this.panel2.Controls.Add(this.txt_maHH);
            this.panel2.Controls.Add(this.lbl_SLTon);
            this.panel2.Controls.Add(this.lbl_giaMua);
            this.panel2.Controls.Add(this.lbl_tenHH);
            this.panel2.Controls.Add(this.lbl_maHH);
            this.panel2.Location = new System.Drawing.Point(439, 38);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 401);
            this.panel2.TabIndex = 3;
            // 
            // lbl_thongTinHangHoa
            // 
            this.lbl_thongTinHangHoa.AutoSize = true;
            this.lbl_thongTinHangHoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_thongTinHangHoa.Location = new System.Drawing.Point(3, 2);
            this.lbl_thongTinHangHoa.Name = "lbl_thongTinHangHoa";
            this.lbl_thongTinHangHoa.Size = new System.Drawing.Size(213, 25);
            this.lbl_thongTinHangHoa.TabIndex = 14;
            this.lbl_thongTinHangHoa.Text = "Thông Tin Hàng Hóa";
            // 
            // btn_xoaHH
            // 
            this.btn_xoaHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_xoaHH.Location = new System.Drawing.Point(345, 298);
            this.btn_xoaHH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_xoaHH.Name = "btn_xoaHH";
            this.btn_xoaHH.Size = new System.Drawing.Size(67, 27);
            this.btn_xoaHH.TabIndex = 12;
            this.btn_xoaHH.Text = "Xóa";
            this.btn_xoaHH.UseVisualStyleBackColor = true;
            this.btn_xoaHH.Click += new System.EventHandler(this.btn_xoaHH_Click);
            // 
            // btn_suaHH
            // 
            this.btn_suaHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_suaHH.Location = new System.Drawing.Point(225, 298);
            this.btn_suaHH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_suaHH.Name = "btn_suaHH";
            this.btn_suaHH.Size = new System.Drawing.Size(67, 27);
            this.btn_suaHH.TabIndex = 11;
            this.btn_suaHH.Text = "Sửa";
            this.btn_suaHH.UseVisualStyleBackColor = true;
            this.btn_suaHH.Click += new System.EventHandler(this.btn_suaHH_Click);
            // 
            // btn_themHH
            // 
            this.btn_themHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_themHH.Location = new System.Drawing.Point(94, 298);
            this.btn_themHH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_themHH.Name = "btn_themHH";
            this.btn_themHH.Size = new System.Drawing.Size(67, 27);
            this.btn_themHH.TabIndex = 10;
            this.btn_themHH.Text = "Thêm";
            this.btn_themHH.UseVisualStyleBackColor = true;
            this.btn_themHH.Click += new System.EventHandler(this.btn_themHH_Click);
            // 
            // txt_SLTon
            // 
            this.txt_SLTon.Location = new System.Drawing.Point(225, 218);
            this.txt_SLTon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_SLTon.Name = "txt_SLTon";
            this.txt_SLTon.Size = new System.Drawing.Size(229, 22);
            this.txt_SLTon.TabIndex = 8;
            // 
            // txt_giaMua
            // 
            this.txt_giaMua.Location = new System.Drawing.Point(225, 171);
            this.txt_giaMua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_giaMua.Name = "txt_giaMua";
            this.txt_giaMua.Size = new System.Drawing.Size(229, 22);
            this.txt_giaMua.TabIndex = 7;
            // 
            // txt_tenHH
            // 
            this.txt_tenHH.Location = new System.Drawing.Point(225, 122);
            this.txt_tenHH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_tenHH.Name = "txt_tenHH";
            this.txt_tenHH.Size = new System.Drawing.Size(229, 22);
            this.txt_tenHH.TabIndex = 6;
            // 
            // txt_maHH
            // 
            this.txt_maHH.Location = new System.Drawing.Point(225, 80);
            this.txt_maHH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_maHH.Name = "txt_maHH";
            this.txt_maHH.Size = new System.Drawing.Size(229, 22);
            this.txt_maHH.TabIndex = 5;
            // 
            // lbl_SLTon
            // 
            this.lbl_SLTon.AutoSize = true;
            this.lbl_SLTon.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_SLTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_SLTon.Location = new System.Drawing.Point(39, 222);
            this.lbl_SLTon.Name = "lbl_SLTon";
            this.lbl_SLTon.Size = new System.Drawing.Size(119, 18);
            this.lbl_SLTon.TabIndex = 3;
            this.lbl_SLTon.Text = "Số  Lượng Tồn";
            // 
            // lbl_giaMua
            // 
            this.lbl_giaMua.AutoSize = true;
            this.lbl_giaMua.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_giaMua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_giaMua.Location = new System.Drawing.Point(39, 176);
            this.lbl_giaMua.Name = "lbl_giaMua";
            this.lbl_giaMua.Size = new System.Drawing.Size(71, 18);
            this.lbl_giaMua.TabIndex = 2;
            this.lbl_giaMua.Text = "Giá Mua";
            // 
            // lbl_tenHH
            // 
            this.lbl_tenHH.AutoSize = true;
            this.lbl_tenHH.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_tenHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_tenHH.Location = new System.Drawing.Point(39, 127);
            this.lbl_tenHH.Name = "lbl_tenHH";
            this.lbl_tenHH.Size = new System.Drawing.Size(116, 18);
            this.lbl_tenHH.TabIndex = 1;
            this.lbl_tenHH.Text = "Tên Hàng Hóa";
            // 
            // lbl_maHH
            // 
            this.lbl_maHH.AutoSize = true;
            this.lbl_maHH.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lbl_maHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_maHH.Location = new System.Drawing.Point(39, 80);
            this.lbl_maHH.Name = "lbl_maHH";
            this.lbl_maHH.Size = new System.Drawing.Size(111, 18);
            this.lbl_maHH.TabIndex = 0;
            this.lbl_maHH.Text = "Mã Hàng Hóa";
            // 
            // HangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 475);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip_loanSpa);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HangHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hàng Hóa";
            this.Load += new System.EventHandler(this.HangHoa_Load);
            this.menuStrip_loanSpa.ResumeLayout(false);
            this.menuStrip_loanSpa.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_hangHoa)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_loanSpa;
        private System.Windows.Forms.ToolStripMenuItem tổngQuanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hàngHóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dịchVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giaoDịchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuNhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đốiTácToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgv_hangHoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_SLTon;
        private System.Windows.Forms.Label lbl_giaMua;
        private System.Windows.Forms.Label lbl_tenHH;
        private System.Windows.Forms.Label lbl_maHH;
        private System.Windows.Forms.Button btn_xoaHH;
        private System.Windows.Forms.Button btn_suaHH;
        private System.Windows.Forms.Button btn_themHH;
        private System.Windows.Forms.TextBox txt_SLTon;
        private System.Windows.Forms.TextBox txt_giaMua;
        private System.Windows.Forms.TextBox txt_tenHH;
        private System.Windows.Forms.TextBox txt_maHH;
        private System.Windows.Forms.Label lbl_thongTinHangHoa;
    }
}