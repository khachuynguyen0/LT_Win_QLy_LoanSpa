using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loan_Spa
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
            dtgv_khachHang.SelectionChanged += Dtgv_khachHang_SelectionChanged;
        }

        private void Dtgv_khachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_khachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgv_khachHang.SelectedRows[0];

                txt_maKH.Text = selectedRow.Cells["MaKH"].Value?.ToString();
                txt_tenKH.Text = selectedRow.Cells["TenKH"].Value?.ToString();
                txt_SDT.Text = selectedRow.Cells["SDT"].Value?.ToString();
                dtp_ngayLap.Text = selectedRow.Cells["NgayLap"].Value?.ToString();
                txt_tongTien.Text = selectedRow.Cells["TongTien"].Value?.ToString();
            }
            else
            {
                txt_maKH.Clear();
                txt_tenKH.Clear();
                txt_SDT.Clear();
                dtp_ngayLap.Value = DateTime.Now;
                txt_tongTien.Clear();
            }
        }

        private void LoadData()
        {
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "SELECT * FROM KHACHHANG";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dtgv_khachHang.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_themKH_Click(object sender, EventArgs e)
        {
            string tenKH = txt_tenKH.Text;
            string sdt = txt_SDT.Text;
            decimal tongTien;
            DateTime ngayLap = dtp_ngayLap.Value; // Lấy giá trị từ DateTimePicker

            if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(sdt) ||
                !decimal.TryParse(txt_tongTien.Text, out tongTien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin khách hàng!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "INSERT INTO KHACHHANG (TenKH, SDT, NgayLap, TongTien) VALUES (@TenKH, @SDT, @NgayLap, @TongTien)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenKH", tenKH);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm khách hàng thành công!");
                    LoadData();

                    txt_tenKH.Clear();
                    txt_SDT.Clear();
                    txt_tongTien.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_suaKH_Click(object sender, EventArgs e)
        {
            if (dtgv_khachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Thông báo");
                return;
            }

            string maKH = txt_maKH.Text;
            string tenKH = txt_tenKH.Text;
            string sdt = txt_SDT.Text;
            decimal tongTien;
            DateTime ngayLap = dtp_ngayLap.Value; // Lấy giá trị từ DateTimePicker

            if (!decimal.TryParse(txt_tongTien.Text, out tongTien))
            {
                MessageBox.Show("Tổng tiền phải là số hợp lệ!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "UPDATE KHACHHANG SET TenKH = @TenKH, SDT = @SDT, NgayLap = @NgayLap, TongTien = @TongTien WHERE MaKH = @MaKH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.Parameters.AddWithValue("@TenKH", tenKH);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa khách hàng thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
                }
            }
        }

        private void dtgv_khachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ số dòng được chọn (đảm bảo không ngoài phạm vi)
            if (e.RowIndex >= 0 && e.RowIndex < dtgv_khachHang.Rows.Count)
            {
                DataGridViewRow selectedRow = dtgv_khachHang.Rows[e.RowIndex];

                // Gán giá trị từ các ô vào các TextBox và DateTimePicker
                txt_maKH.Text = selectedRow.Cells["MaKH"].Value?.ToString() ?? string.Empty;
                txt_tenKH.Text = selectedRow.Cells["TenKH"].Value?.ToString() ?? string.Empty;
                txt_SDT.Text = selectedRow.Cells["SDT"].Value?.ToString() ?? string.Empty;

                // Đảm bảo rằng cột "NgayLap" không phải DBNull trước khi gán giá trị
                if (selectedRow.Cells["NgayLap"].Value != DBNull.Value)
                {
                    dtp_ngayLap.Value = Convert.ToDateTime(selectedRow.Cells["NgayLap"].Value);
                }
                else
                {
                    dtp_ngayLap.Value = DateTime.Now;
                }

                txt_tongTien.Text = selectedRow.Cells["TongTien"].Value?.ToString() ?? string.Empty;
            }
        }

        private void btn_xoaKH_Click(object sender, EventArgs e)
        {
            if (dtgv_khachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo");
                return;
            }

            string maKH = dtgv_khachHang.SelectedRows[0].Cells[0].Value.ToString();
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "DELETE FROM KHACHHANG WHERE MaKH = @MaKH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKH", maKH);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa khách hàng thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                }
            }
        }

        
    }
}
