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
    public partial class PhieuNhapHang : Form
    {
        public PhieuNhapHang()
        {
            InitializeComponent();
            dtgv_phieuNhapHang.SelectionChanged += Dtgv_phieuNhap_SelectionChanged;
        }

        // Khi chọn một dòng trong DataGridView, hiển thị thông tin chi tiết ở các TextBox.
        private void Dtgv_phieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_phieuNhapHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgv_phieuNhapHang.SelectedRows[0];

                txt_maNH.Text = selectedRow.Cells["MaNH"].Value?.ToString();
                dtp_ngayLap.Text = selectedRow.Cells["NgayLap"].Value?.ToString();
                txt_tongTien.Text = selectedRow.Cells["TongTien"].Value?.ToString();
                txt_trangThai.Text = selectedRow.Cells["TrangThai"].Value?.ToString();
                txt_maNCC.Text = selectedRow.Cells["MaNCC"].Value?.ToString();
            }
        }

        // Lấy dữ liệu từ cơ sở dữ liệu và hiển thị lên DataGridView.
        private void LoadData()
        {
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "SELECT * FROM NHAPHANG"; // Lệnh SQL để lấy dữ liệu từ bảng NHAPHANG

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dtgv_phieuNhapHang.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_chiTiet_Click(object sender, EventArgs e)
        {
            //thông tin chi tiết từ phiếu nhập hàng và hàng hóa
            if (dtgv_phieuNhapHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để xem chi tiết!", "Thông báo");
                return;
            }

            // Lấy mã phiếu nhập từ dòng được chọn
            string maNH = dtgv_phieuNhapHang.SelectedRows[0].Cells["MaNH"].Value?.ToString();

            if (string.IsNullOrEmpty(maNH))
            {
                MessageBox.Show("Không thể lấy mã phiếu nhập từ dòng được chọn!", "Lỗi");
                return;
            }

            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";

            // Truy vấn lấy chi tiết các sản phẩm từ bảng CT_NHAPHANG_HANGHOA liên quan đến phiếu nhập này
            string query = "SELECT HH.TenHH, CTNH.SoLuong, CTNH.DonGia " +
                           "FROM CT_NHAPHANG_HANGHOA CTNH " +
                           "JOIN HANGHOA HH ON CTNH.MaHH = HH.MaHH " +
                           "WHERE CTNH.MaNH = @MaNH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNH", maNH);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Không có chi tiết nào cho phiếu nhập này!", "Thông báo");
                        return;
                    }

                    // Tạo chuỗi để chứa thông tin chi tiết
                    StringBuilder chiTiet = new StringBuilder();
                    chiTiet.AppendLine($"Chi tiết phiếu nhập #{maNH}:\n");
                    chiTiet.AppendLine("Tên Hàng Hóa\tSố Lượng\tĐơn Giá");

                    // Đọc dữ liệu từ DataReader
                    while (reader.Read())
                    {
                        string tenHH = reader["TenHH"].ToString();
                        int soLuong = Convert.ToInt32(reader["SoLuong"]);
                        decimal donGia = Convert.ToDecimal(reader["DonGia"]);

                        chiTiet.AppendLine($"{tenHH}\t{soLuong}\t{donGia:C0}");
                    }

                    // Hiển thị thông tin chi tiết trong MessageBox
                    MessageBox.Show(chiTiet.ToString(), "Chi Tiết Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết phiếu nhập: " + ex.Message, "Lỗi");
                }
            }
        }

        private void PhieuNhapHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_themPNH_Click(object sender, EventArgs e)
        {
            string ngayLap = dtp_ngayLap.Value.ToString("yyyy-MM-dd");  // Định dạng ngày
            decimal tongTien;
            int trangThai, maNCC;

            if (!decimal.TryParse(txt_tongTien.Text, out tongTien) ||
                !int.TryParse(txt_trangThai.Text, out trangThai) ||
                !int.TryParse(txt_maNCC.Text, out maNCC))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin phiếu nhập hàng!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "INSERT INTO NHAPHANG (NgayLap, TongTien, TrangThai, MaNCC) VALUES (@NgayLap, @TongTien, @TrangThai, @MaNCC)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm phiếu nhập hàng thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm phiếu nhập hàng: " + ex.Message);
                }
            }
        }

        private void btn_suaPNH_Click(object sender, EventArgs e)
        {
            if (dtgv_phieuNhapHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để sửa!", "Thông báo");
                return;
            }

            string maNH = txt_maNH.Text;
            string ngayLap = dtp_ngayLap.Value.ToString("yyyy-MM-dd");
            decimal tongTien;
            int trangThai, maNCC;

            if (!decimal.TryParse(txt_tongTien.Text, out tongTien) ||
                !int.TryParse(txt_trangThai.Text, out trangThai) ||
                !int.TryParse(txt_maNCC.Text, out maNCC))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin phiếu nhập hàng!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "UPDATE NHAPHANG SET NgayLap = @NgayLap, TongTien = @TongTien, TrangThai = @TrangThai, MaNCC = @MaNCC WHERE MaNH = @MaNH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNH", maNH);
                    cmd.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa phiếu nhập hàng thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa phiếu nhập hàng: " + ex.Message);
                }
            }
        }

        private void btn_xoaPNH_Click(object sender, EventArgs e)
        {
            if (dtgv_phieuNhapHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để xóa!", "Thông báo");
                return;
            }

            string maNH = dtgv_phieuNhapHang.SelectedRows[0].Cells[0].Value.ToString();
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "DELETE FROM NHAPHANG WHERE MaNH = @MaNH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNH", maNH);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa phiếu nhập hàng thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa phiếu nhập hàng: " + ex.Message);
                }
            }
        }

        
    }
}
