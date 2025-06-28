namespace WinForm_Khambenh
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTimngay = new Button();
            label12 = new Label();
            label11 = new Label();
            txtTim = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            label10 = new Label();
            dtpNgayKham = new DateTimePicker();
            label5 = new Label();
            chkCapCuu = new CheckBox();
            txtKhoaKham = new TextBox();
            label9 = new Label();
            dtpDenNgay = new DateTimePicker();
            dtpTuNgay = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            txtLoaiBenh = new TextBox();
            txtMaBenhNhan = new TextBox();
            txtMaHoSo = new TextBox();
            btnXoa = new Button();
            btnTim = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnTimngay
            // 
            btnTimngay.Location = new Point(976, 228);
            btnTimngay.Name = "btnTimngay";
            btnTimngay.Size = new Size(165, 55);
            btnTimngay.TabIndex = 58;
            btnTimngay.Text = "Tìm kiếm ngày";
            btnTimngay.UseVisualStyleBackColor = true;
            btnTimngay.Click += btnTimngay_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(664, 82);
            label12.Name = "label12";
            label12.Size = new Size(184, 30);
            label12.TabIndex = 57;
            label12.Text = "Tìm kiếm giới hạn:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(664, 328);
            label11.Name = "label11";
            label11.Size = new Size(194, 30);
            label11.TabIndex = 56;
            label11.Text = "Tìm kiếm liên quan:";
            // 
            // txtTim
            // 
            txtTim.Location = new Point(864, 328);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(277, 35);
            txtTim.TabIndex = 55;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(165, 468);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(183, 56);
            btnThem.TabIndex = 54;
            btnThem.Text = "THÊM";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(394, 468);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(201, 56);
            btnSua.TabIndex = 53;
            btnSua.Text = "SỬA";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(51, 389);
            label10.Name = "label10";
            label10.Size = new Size(94, 30);
            label10.TabIndex = 52;
            label10.Text = "Cấp cứu:";
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.Location = new Point(211, 324);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(322, 35);
            dtpNgayKham.TabIndex = 51;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 328);
            label5.Name = "label5";
            label5.Size = new Size(124, 30);
            label5.TabIndex = 50;
            label5.Text = "Ngày khám:";
            // 
            // chkCapCuu
            // 
            chkCapCuu.AutoSize = true;
            chkCapCuu.Location = new Point(211, 388);
            chkCapCuu.Name = "chkCapCuu";
            chkCapCuu.Size = new Size(64, 34);
            chkCapCuu.TabIndex = 49;
            chkCapCuu.Text = "Có";
            chkCapCuu.UseVisualStyleBackColor = true;
            // 
            // txtKhoaKham
            // 
            txtKhoaKham.Location = new Point(210, 143);
            txtKhoaKham.Name = "txtKhoaKham";
            txtKhoaKham.Size = new Size(323, 35);
            txtKhoaKham.TabIndex = 48;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(51, 144);
            label9.Name = "label9";
            label9.Size = new Size(122, 30);
            label9.TabIndex = 47;
            label9.Text = "Khoa khám:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(864, 176);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(277, 35);
            dtpDenNgay.TabIndex = 46;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(864, 121);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(275, 35);
            dtpTuNgay.TabIndex = 45;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(738, 180);
            label8.Name = "label8";
            label8.Size = new Size(107, 30);
            label8.TabIndex = 44;
            label8.Text = "Đến ngày:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(754, 126);
            label7.Name = "label7";
            label7.Size = new Size(92, 30);
            label7.TabIndex = 43;
            label7.Text = "Từ ngày:";
            // 
            // txtLoaiBenh
            // 
            txtLoaiBenh.Location = new Point(210, 264);
            txtLoaiBenh.Name = "txtLoaiBenh";
            txtLoaiBenh.Size = new Size(322, 35);
            txtLoaiBenh.TabIndex = 42;
            // 
            // txtMaBenhNhan
            // 
            txtMaBenhNhan.Location = new Point(211, 201);
            txtMaBenhNhan.Name = "txtMaBenhNhan";
            txtMaBenhNhan.Size = new Size(322, 35);
            txtMaBenhNhan.TabIndex = 41;
            // 
            // txtMaHoSo
            // 
            txtMaHoSo.Location = new Point(210, 82);
            txtMaHoSo.Name = "txtMaHoSo";
            txtMaHoSo.Size = new Size(323, 35);
            txtMaHoSo.TabIndex = 40;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(664, 468);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(202, 56);
            btnXoa.TabIndex = 39;
            btnXoa.Text = "XÓA";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(976, 379);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(163, 50);
            btnTim.TabIndex = 38;
            btnTim.Text = "TÌM KIẾM";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 267);
            label4.Name = "label4";
            label4.Size = new Size(109, 30);
            label4.TabIndex = 37;
            label4.Text = "Loại bệnh:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 206);
            label3.Name = "label3";
            label3.Size = new Size(154, 30);
            label3.TabIndex = 36;
            label3.Text = "Mã bệnh nhân:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 85);
            label2.Name = "label2";
            label2.Size = new Size(106, 30);
            label2.TabIndex = 35;
            label2.Text = "Mã hồ sơ:";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 568);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 72;
            dataGridView1.RowTemplate.Height = 37;
            dataGridView1.Size = new Size(1200, 598);
            dataGridView1.TabIndex = 34;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(394, 15);
            label1.Name = "label1";
            label1.Size = new Size(397, 38);
            label1.TabIndex = 33;
            label1.Text = "QUẢN LÝ HỒ SƠ KHÁM BỆNH ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 1166);
            Controls.Add(btnTimngay);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txtTim);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(label10);
            Controls.Add(dtpNgayKham);
            Controls.Add(label5);
            Controls.Add(chkCapCuu);
            Controls.Add(txtKhoaKham);
            Controls.Add(label9);
            Controls.Add(dtpDenNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtLoaiBenh);
            Controls.Add(txtMaBenhNhan);
            Controls.Add(txtMaHoSo);
            Controls.Add(btnXoa);
            Controls.Add(btnTim);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTimngay;
        private Label label12;
        private Label label11;
        private TextBox txtTim;
        private Button btnThem;
        private Button btnSua;
        private Label label10;
        private DateTimePicker dtpNgayKham;
        private Label label5;
        private CheckBox chkCapCuu;
        private TextBox txtKhoaKham;
        private Label label9;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private Label label8;
        private Label label7;
        private TextBox txtLoaiBenh;
        private TextBox txtMaBenhNhan;
        private TextBox txtMaHoSo;
        private Button btnXoa;
        private Button btnTim;
        private Label label4;
        private Label label3;
        private Label label2;
        private DataGridView dataGridView1;
        private Label label1;
    }
}
