using WinForm_Khambenh.Data;
using WinForm_Khambenh.Model;

namespace WinForm_Khambenh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using var db = new AppDbContext();
            dataGridView1.DataSource = db.HoSoKhamBenhs.ToList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTim.Text.Trim().ToLower();
            using var db = new AppDbContext();

            var ketQua = db.HoSoKhamBenhs.Where(h =>
                   h.MaHoSo.ToString().Contains(tuKhoa) ||
                   h.MaBenhNhan.ToString().Contains(tuKhoa) ||
                   h.KhoaKham.ToLower().Contains(tuKhoa) ||
                   h.LoaiBenh.ToLower().Contains(tuKhoa) ||
                   h.NgayKham.ToString().Contains(tuKhoa) ||
                   (h.CapCuu ? "true" : "false").Contains(tuKhoa)
            ).ToList();

            dataGridView1.DataSource = ketQua;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int maHoSo = (int)dataGridView1.SelectedRows[0].Cells["MaHoSo"].Value;
                    using var db = new AppDbContext();
                    var hoSo = db.HoSoKhamBenhs.Find(maHoSo);
                    if (hoSo != null)
                    {
                        db.HoSoKhamBenhs.Remove(hoSo);
                        db.SaveChanges();
                        LoadData();
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                var row = dataGridView1.CurrentRow;
                txtMaHoSo.Text = row.Cells["MaHoSo"].Value.ToString();
                txtKhoaKham.Text = row.Cells["KhoaKham"].Value.ToString();
                txtMaBenhNhan.Text = row.Cells["MaBenhNhan"].Value.ToString();
                txtLoaiBenh.Text = row.Cells["LoaiBenh"].Value.ToString();
                dtpNgayKham.Value = Convert.ToDateTime(row.Cells["NgayKham"].Value);
                chkCapCuu.Checked = Convert.ToBoolean(row.Cells["CapCuu"].Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();

            // Validate
            if (!int.TryParse(txtMaHoSo.Text, out int maHoSo))
            {
                MessageBox.Show("Mã hồ sơ phải là số nguyên!");
                txtMaHoSo.Focus(); return;
            }
            if (!int.TryParse(txtMaBenhNhan.Text, out int maBN) ||
                string.IsNullOrWhiteSpace(txtKhoaKham.Text) ||
                string.IsNullOrWhiteSpace(txtLoaiBenh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin."); return;
            }

            // Check duplicate
            if (db.HoSoKhamBenhs.Any(x => x.MaHoSo == maHoSo))
            {
                MessageBox.Show($"Mã {maHoSo} đã tồn tại!"); txtMaHoSo.Focus(); return;
            }

            // Add
            var hs = new HoSoKhamBenh
            {
                MaHoSo = maHoSo,
                KhoaKham = txtKhoaKham.Text.Trim(),
                MaBenhNhan = maBN,
                LoaiBenh = txtLoaiBenh.Text.Trim(),
                NgayKham = dtpNgayKham.Value,
                CapCuu = chkCapCuu.Checked
            };
            db.HoSoKhamBenhs.Add(hs);
            db.SaveChanges();

            LoadData();
            MessageBox.Show("Thêm hồ sơ thành công! 🚀");
            ClearInputs();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using var db = new AppDbContext();
                int maHoSo = int.Parse(txtMaHoSo.Text);
                var hs = db.HoSoKhamBenhs.FirstOrDefault(x => x.MaHoSo == maHoSo);

                if (hs != null)
                {
                    hs.KhoaKham = txtKhoaKham.Text;
                    hs.MaBenhNhan = int.Parse(txtMaBenhNhan.Text);
                    hs.LoaiBenh = txtLoaiBenh.Text;
                    hs.NgayKham = dtpNgayKham.Value;
                    hs.CapCuu = chkCapCuu.Checked;

                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Cập nhật hồ sơ thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hồ sơ để sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa hồ sơ: " + ex.Message);
            }
            ClearInputs();
        }
        private void ClearInputs()
        {
            txtMaHoSo.Clear();
            txtKhoaKham.Clear();
            txtMaBenhNhan.Clear();
            txtLoaiBenh.Clear();
            dtpNgayKham.Value = DateTime.Today;
            chkCapCuu.Checked = false;
            txtMaHoSo.Focus();
        }

        private void btnTimngay_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            using var db = new AppDbContext();
            var ketQua = db.HoSoKhamBenhs
                .Where(h => h.NgayKham >= tuNgay && h.NgayKham <= denNgay)
                .ToList();

            dataGridView1.DataSource = ketQua;
        }
    }
}
