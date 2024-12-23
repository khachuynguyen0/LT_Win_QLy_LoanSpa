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
    public partial class HangHoa : Form
    {
        public HangHoa()
        {
            InitializeComponent();
            dtgv_hangHoa.SelectionChanged += Dtgv_hangHoa_SelectionChanged;
        }

        private void Dtgv_hangHoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_hangHoa.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgv_hangHoa.SelectedRows[0];

                txt_maHH.Text = selectedRow.Cells["MaHH"].Value?.ToString();
                txt_tenHH.Text = selectedRow.Cells["TenHH"].Value?.ToString();
                txt_giaMua.Text = selectedRow.Cells["GiaMua"].Value?.ToString();
                txt_SLTon.Text = selectedRow.Cells["SLTon"].Value?.ToString();
            }
            else
            {
                txt_maHH.Clear();
                txt_tenHH.Clear();
                txt_giaMua.Clear();
                txt_SLTon.Clear();
            }
        }

        private void LoadData()
        {
            // Chuỗi kết nối tới database
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "SELECT * FROM HangHoa"; // Lệnh SQL để lấy dữ liệu từ bảng HangHoa

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán dữ liệu cho DataGridView
                    dtgv_hangHoa.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void HangHoa_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btn_themHH_Click(object sender, EventArgs e)
        {
            string tenhh = txt_tenHH.Text;      // Tên hàng hóa
            decimal giamua;
            int slton;

            // Kiểm tra nếu các trường dữ liệu trống hoặc không hợp lệ
            if (string.IsNullOrEmpty(tenhh) ||
                !decimal.TryParse(txt_giaMua.Text, out giamua) ||
                !int.TryParse(txt_SLTon.Text, out slton))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin hàng hóa!", "Lỗi nhập liệu");
                return;
            }

            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";

            // Lệnh SQL để thêm hàng hóa
            string query = "INSERT INTO HangHoa (TenHH, GiaMua, SLTon) VALUES (@TenHH, @GiaMua, @SLTon)";

            // Mở kết nối và thực hiện lệnh SQL
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();  // Mở kết nối
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenHH", tenhh);  // Thêm tên hàng hóa
                    cmd.Parameters.AddWithValue("@GiaMua", giamua);  // Thêm giá mua
                    cmd.Parameters.AddWithValue("@SLTon", slton);  // Thêm số lượng tồn

                    // Thực thi lệnh INSERT
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm hàng hóa thành công!");

                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();

                    // Xóa dữ liệu nhập sau khi thêm
                    txt_tenHH.Clear();
                    txt_giaMua.Clear();
                    txt_SLTon.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_suaHH_Click(object sender, EventArgs e)
        {
            if (dtgv_hangHoa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hàng hóa để sửa!", "Thông báo");
                return;
            }

            string mahh = txt_maHH.Text;
            string tenhh = txt_tenHH.Text;
            decimal giamua;
            int slton;

            if (!decimal.TryParse(txt_giaMua.Text, out giamua) || !int.TryParse(txt_SLTon.Text, out slton))
            {
                MessageBox.Show("Giá mua và số lượng tồn phải là số hợp lệ!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "UPDATE HangHoa SET TenHH = @TenHH, GiaMua = @GiaMua, SLTon = @SLTon WHERE MaHH = @MaHH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHH", mahh);
                    cmd.Parameters.AddWithValue("@TenHH", tenhh);
                    cmd.Parameters.AddWithValue("@GiaMua", giamua);
                    cmd.Parameters.AddWithValue("@SLTon", slton);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa hàng hóa thành công!");

                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
                }
            }
        }

        private void dtgv_hangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo rằng dòng được chọn không phải là dòng mới hoặc ngoài phạm vi
            if (e.RowIndex >= 0 && e.RowIndex < dtgv_hangHoa.Rows.Count)
            {
                DataGridViewRow selectedRow = dtgv_hangHoa.Rows[e.RowIndex];

                // Gán giá trị từ các ô (Cells) của dòng được chọn vào các TextBox
                txt_maHH.Text = selectedRow.Cells["MaHH"].Value?.ToString() ?? string.Empty;
                txt_tenHH.Text = selectedRow.Cells["TenHH"].Value?.ToString() ?? string.Empty;
                txt_giaMua.Text = selectedRow.Cells["GiaMua"].Value?.ToString() ?? string.Empty;
                txt_SLTon.Text = selectedRow.Cells["SLTon"].Value?.ToString() ?? string.Empty;
            }
        }


        private void btn_xoaHH_Click(object sender, EventArgs e)
        {
            if (dtgv_hangHoa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hàng hóa để xóa!", "Thông báo");
                return;
            }

            string mahh = dtgv_hangHoa.SelectedRows[0].Cells[0].Value.ToString();
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";

            string query = "DELETE FROM HangHoa WHERE MaHH = @MaHH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHH", mahh);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa hàng hóa thành công!");

                    // Cập nhật lại dữ liệu trên DataGridView
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
