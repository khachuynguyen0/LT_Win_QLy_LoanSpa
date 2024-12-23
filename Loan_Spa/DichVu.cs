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
    public partial class DichVu : Form
    {
        public DichVu()
        {
            InitializeComponent();
            dtgv_dichVu.SelectionChanged += Dtgv_dichVu_SelectionChanged;
        }

        private void Dtgv_dichVu_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_dichVu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgv_dichVu.SelectedRows[0];

                txt_maDV.Text = selectedRow.Cells["MaDV"].Value?.ToString();
                txt_tenDV.Text = selectedRow.Cells["TenDV"].Value?.ToString();
                txt_giaDV.Text = selectedRow.Cells["GiaDV"].Value?.ToString();
            }
            else
            {
                txt_maDV.Clear();
                txt_tenDV.Clear();
                txt_giaDV.Clear();
            }
        }

        private void LoadData()
        {
            // Chuỗi kết nối tới database
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "SELECT * FROM DICHVU"; // Lệnh SQL để lấy dữ liệu từ bảng DICHVU

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán dữ liệu cho DataGridView
                    dtgv_dichVu.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btn_themDV_Click_1(object sender, EventArgs e)
        {
            string tenDV = txt_tenDV.Text;      // Tên dịch vụ
            decimal giaDV;

            // Kiểm tra nếu các trường dữ liệu trống hoặc không hợp lệ
            if (string.IsNullOrEmpty(tenDV) ||
                !decimal.TryParse(txt_giaDV.Text, out giaDV))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin dịch vụ!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "INSERT INTO DICHVU (TenDV, GiaDV) VALUES (@TenDV, @GiaDV)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();  // Mở kết nối
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDV", tenDV);  // Thêm tên dịch vụ
                    cmd.Parameters.AddWithValue("@GiaDV", giaDV);  // Thêm giá dịch vụ

                    // Thực thi lệnh INSERT
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm dịch vụ thành công!");

                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();

                    // Xóa dữ liệu nhập sau khi thêm
                    txt_tenDV.Clear();
                    txt_giaDV.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_suaDV_Click_1(object sender, EventArgs e)
        {
            if (dtgv_dichVu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để sửa!", "Thông báo");
                return;
            }

            string maDV = txt_maDV.Text;
            string tenDV = txt_tenDV.Text;
            decimal giaDV;

            if (!decimal.TryParse(txt_giaDV.Text, out giaDV))
            {
                MessageBox.Show("Giá dịch vụ phải là số hợp lệ!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "UPDATE DICHVU SET TenDV = @TenDV, GiaDV = @GiaDV WHERE MaDV = @MaDV";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDV", maDV);
                    cmd.Parameters.AddWithValue("@TenDV", tenDV);
                    cmd.Parameters.AddWithValue("@GiaDV", giaDV);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa dịch vụ thành công!");

                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
                }
            }
        }


        private void dtgv_dichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu ô được nhấp là checkbox (có thể thay đổi tùy theo cột checkbox)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewColumn column = dtgv_dichVu.Columns[e.ColumnIndex];
                if (column is DataGridViewCheckBoxColumn)
                {
                    bool isChecked = (bool)dtgv_dichVu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    MessageBox.Show($"Checkbox trạng thái: {isChecked}");
                }
                else
                {
                    MessageBox.Show("Bạn đã nhấp vào nội dung ô không phải checkbox.");
                }
            }
        }

        private void dtgv_dichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra ô có hợp lệ không (loại trừ header)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dtgv_dichVu.Rows[e.RowIndex];

                // Hiển thị dữ liệu vào các TextBox
                txt_maDV.Text = selectedRow.Cells["MaDV"].Value?.ToString();
                txt_tenDV.Text = selectedRow.Cells["TenDV"].Value?.ToString();
                txt_giaDV.Text = selectedRow.Cells["GiaDV"].Value?.ToString();
            }
        }

        private void btn_xoaDV_Click_1(object sender, EventArgs e)
        {
            if (dtgv_dichVu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Thông báo");
                return;
            }

            string maDV = dtgv_dichVu.SelectedRows[0].Cells[0].Value.ToString();
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;"    ;
            string query = "DELETE FROM DICHVU WHERE MaDV = @MaDV";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDV", maDV);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa dịch vụ thành công!");

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
