using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Loan_Spa
{
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
            dtgv_hoaDon.SelectionChanged += Dtgv_hoaDon_SelectionChanged;
        }

        private void Dtgv_hoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_hoaDon.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgv_hoaDon.SelectedRows[0];

                txt_maHD.Text = selectedRow.Cells["MaHD"].Value?.ToString();
                dtp_ngayLap.Text = selectedRow.Cells["NgayLap"].Value?.ToString();
                txt_tongTien.Text = selectedRow.Cells["TongTien"].Value?.ToString();
                txt_giamGia.Text = selectedRow.Cells["GiamGia"].Value?.ToString();
                txt_tongSauGiam.Text = selectedRow.Cells["TongSauGiam"].Value?.ToString();
                txt_soTienDaThanhToan.Text = selectedRow.Cells["SoTienDaThanhToan"].Value?.ToString();
                txt_maKH.Text = selectedRow.Cells["MaKH"].Value?.ToString();

            }
        }


        private void LoadData()
        {
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "SELECT * FROM HOADON";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dtgv_hoaDon.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }



        private void btn_chiTiet_Click(object sender, EventArgs e)
        {
            //show ra các dịch vụ mà khách đã sử dụng
            if (dtgv_hoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xem chi tiết!", "Thông báo");
                return;
            }

            // Lấy mã hóa đơn từ dòng được chọn
            string maHD = dtgv_hoaDon.SelectedRows[0].Cells["MaHD"].Value?.ToString();

            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Không thể lấy mã hóa đơn từ dòng được chọn!", "Lỗi");
                return;
            }

            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "SELECT DV.TenDV, CTHD.SoLuong, CTHD.DonGia " +
                           "FROM CTHD_HOADON_DICHVU CTHD " +
                           "JOIN DICHVU DV ON CTHD.MaDV = DV.MaDV " +
                           "WHERE CTHD.MaHD = @MaHD";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHD", maHD);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Không có chi tiết nào cho hóa đơn này!", "Thông báo");
                        return;
                    }

                    // Tạo chuỗi để chứa thông tin chi tiết
                    StringBuilder chiTiet = new StringBuilder();
                    chiTiet.AppendLine($"Chi tiết hóa đơn #{maHD}:\n");
                    chiTiet.AppendLine("Tên Dịch Vụ\tSố Lượng\tĐơn Giá");

                    // Đọc dữ liệu từ DataReader
                    while (reader.Read())
                    {
                        string tenDV = reader["TenDV"].ToString();
                        int soLuong = Convert.ToInt32(reader["SoLuong"]);
                        decimal donGia = Convert.ToDecimal(reader["DonGia"]);

                        chiTiet.AppendLine($"{tenDV}\t{soLuong}\t{donGia:C0}");
                    }

                    // Hiển thị thông tin chi tiết trong MessageBox
                    MessageBox.Show(chiTiet.ToString(), "Chi Tiết Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Lỗi");
                }
            }
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_themHD_Click(object sender, EventArgs e)
        {
            string ngayLap = dtp_ngayLap.Value.ToString("yyyy-MM-dd");  // Lấy giá trị từ DateTimePicker và định dạng
            decimal tongTien, giamGia, tongSauGiam, soTienDaThanhToan;
            int maKH;

            if (!decimal.TryParse(txt_tongTien.Text, out tongTien) ||
                !decimal.TryParse(txt_giamGia.Text, out giamGia) ||
                !decimal.TryParse(txt_tongSauGiam.Text, out tongSauGiam) ||
                !decimal.TryParse(txt_soTienDaThanhToan.Text, out soTienDaThanhToan) ||
                !int.TryParse(txt_maKH.Text, out maKH))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin hóa đơn!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "INSERT INTO HOADON (NgayLap, TongTien, GiamGia, TongSauGiam, SoTienDaThanhToan, MaKH) " +
                           "VALUES (@NgayLap, @TongTien, @GiamGia, @TongSauGiam, @SoTienDaThanhToan, @MaKH)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NgayLap", ngayLap);  // Gán giá trị NgayLap
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);
                    cmd.Parameters.AddWithValue("@GiamGia", giamGia);
                    cmd.Parameters.AddWithValue("@TongSauGiam", tongSauGiam);
                    cmd.Parameters.AddWithValue("@SoTienDaThanhToan", soTienDaThanhToan);
                    cmd.Parameters.AddWithValue("@MaKH", maKH);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm hóa đơn thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message);
                }
            }
        }

        private void btn_suaHD_Click(object sender, EventArgs e)
        {
            if (dtgv_hoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để sửa!", "Thông báo");
                return;
            }

            string maHD = txt_maHD.Text;
            string ngayLap = dtp_ngayLap.Value.ToString("yyyy-MM-dd");  // Lấy giá trị từ DateTimePicker và định dạng
            decimal tongTien, giamGia, tongSauGiam, soTienDaThanhToan;
            int maKH;

            if (!decimal.TryParse(txt_tongTien.Text, out tongTien) ||
                !decimal.TryParse(txt_giamGia.Text, out giamGia) ||
                !decimal.TryParse(txt_tongSauGiam.Text, out tongSauGiam) ||
                !decimal.TryParse(txt_soTienDaThanhToan.Text, out soTienDaThanhToan) ||
                !int.TryParse(txt_maKH.Text, out maKH))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin hóa đơn!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "UPDATE HOADON SET NgayLap = @NgayLap, TongTien = @TongTien, GiamGia = @GiamGia, " +
                           "TongSauGiam = @TongSauGiam, SoTienDaThanhToan = @SoTienDaThanhToan, MaKH = @MaKH WHERE MaHD = @MaHD";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    cmd.Parameters.AddWithValue("@NgayLap", ngayLap);  // Gán giá trị NgayLap
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);
                    cmd.Parameters.AddWithValue("@GiamGia", giamGia);
                    cmd.Parameters.AddWithValue("@TongSauGiam", tongSauGiam);
                    cmd.Parameters.AddWithValue("@SoTienDaThanhToan", soTienDaThanhToan);
                    cmd.Parameters.AddWithValue("@MaKH", maKH);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa hóa đơn thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa hóa đơn: " + ex.Message);
                }
            }
        }

        // Hàm xử lý sự kiện CellClick
        private void dtgv_hoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dtgv_hoaDon.Rows[e.RowIndex];

                // Kiểm tra và gán giá trị cho các TextBox/DateTimePicker
                txt_maHD.Text = selectedRow.Cells["MaHD"].Value?.ToString() ?? string.Empty;

                // Kiểm tra giá trị NULL trước khi gán cho DateTimePicker
                if (selectedRow.Cells["NgayLap"].Value != DBNull.Value)
                {
                    dtp_ngayLap.Value = Convert.ToDateTime(selectedRow.Cells["NgayLap"].Value);
                }
                else
                {
                    dtp_ngayLap.Value = DateTime.Now; // Giá trị mặc định
                }

                txt_tongTien.Text = selectedRow.Cells["TongTien"].Value?.ToString() ?? "0";
                txt_giamGia.Text = selectedRow.Cells["GiamGia"].Value?.ToString() ?? "0";
                txt_tongSauGiam.Text = selectedRow.Cells["TongSauGiam"].Value?.ToString() ?? "0";
                txt_soTienDaThanhToan.Text = selectedRow.Cells["SoTienDaThanhToan"].Value?.ToString() ?? "0";
                txt_maKH.Text = selectedRow.Cells["MaKH"].Value?.ToString() ?? string.Empty;
            }
        }

        private void btn_xoaHD_Click(object sender, EventArgs e)
        {
            if (dtgv_hoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa!", "Thông báo");
                return;
            }

            string maHD = dtgv_hoaDon.SelectedRows[0].Cells[0].Value.ToString();
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "DELETE FROM HOADON WHERE MaHD = @MaHD";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHD", maHD);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa hóa đơn thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message);
                }
            }
        }


    }
}
