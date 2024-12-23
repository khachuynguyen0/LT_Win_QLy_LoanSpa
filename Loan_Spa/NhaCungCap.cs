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
    public partial class NhaCungCap : Form
    {
        public NhaCungCap()
        {
            InitializeComponent();
            dtgv_nhaCungCap.SelectionChanged += Dtgv_nhaCungCap_SelectionChanged;
        }

        private void Dtgv_nhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgv_nhaCungCap.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgv_nhaCungCap.SelectedRows[0];

                txt_maNCC.Text = selectedRow.Cells["MaNCC"].Value?.ToString();
                txt_tenNCC.Text = selectedRow.Cells["TenNCC"].Value?.ToString();
                txt_SDT.Text = selectedRow.Cells["SDT"].Value?.ToString();
                txt_tongNo.Text = selectedRow.Cells["TongNo"].Value?.ToString();
                txt_tongTien.Text = selectedRow.Cells["TongTien"].Value?.ToString();
            }
            else
            {
                txt_maNCC.Clear();
                txt_tenNCC.Clear();
                txt_SDT.Clear();
                txt_tongNo.Clear();
                txt_tongTien.Clear();
            }
        }

        private void LoadData()
        {
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "SELECT * FROM NCC"; // Lấy dữ liệu từ bảng NCC

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dtgv_nhaCungCap.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }

        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_themNCC_Click(object sender, EventArgs e)
        {
            string tenNCC = txt_tenNCC.Text;
            string sdt = txt_SDT.Text;
            decimal tongNo, tongTien;

            if (string.IsNullOrEmpty(tenNCC) || string.IsNullOrEmpty(sdt) ||
                !decimal.TryParse(txt_tongNo.Text, out tongNo) || !decimal.TryParse(txt_tongTien.Text, out tongTien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin nhà cung cấp!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "INSERT INTO NCC (TenNCC, SDT, TongNo, TongTien) VALUES (@TenNCC, @SDT, @TongNo, @TongTien)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@TongNo", tongNo);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhà cung cấp thành công!");
                    LoadData();

                    txt_tenNCC.Clear();
                    txt_SDT.Clear();
                    txt_tongNo.Clear();
                    txt_tongTien.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        private void btn_suaNCC_Click(object sender, EventArgs e)
        {
            if (dtgv_nhaCungCap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để sửa!", "Thông báo");
                return;
            }

            string maNCC = txt_maNCC.Text;
            string tenNCC = txt_tenNCC.Text;
            string sdt = txt_SDT.Text;
            decimal tongNo, tongTien;

            if (!decimal.TryParse(txt_tongNo.Text, out tongNo) || !decimal.TryParse(txt_tongTien.Text, out tongTien))
            {
                MessageBox.Show("Tổng nợ và tổng tiền phải là số hợp lệ!", "Lỗi nhập liệu");
                return;
            }

            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "UPDATE NCC SET TenNCC = @TenNCC, SDT = @SDT, TongNo = @TongNo, TongTien = @TongTien WHERE MaNCC = @MaNCC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmd.Parameters.AddWithValue("@TenNCC", tenNCC);
                    cmd.Parameters.AddWithValue("@SDT", sdt);
                    cmd.Parameters.AddWithValue("@TongNo", tongNo);
                    cmd.Parameters.AddWithValue("@TongTien", tongTien);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa nhà cung cấp thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
                }
            }
        }

        private void dtgv_nhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu dòng được nhấp hợp lệ
            if (e.RowIndex >= 0 && e.RowIndex < dtgv_nhaCungCap.Rows.Count)
            {
                DataGridViewRow selectedRow = dtgv_nhaCungCap.Rows[e.RowIndex];

                // Gán giá trị vào các TextBox
                txt_maNCC.Text = selectedRow.Cells["MaNCC"].Value?.ToString() ?? string.Empty;
                txt_tenNCC.Text = selectedRow.Cells["TenNCC"].Value?.ToString() ?? string.Empty;
                txt_SDT.Text = selectedRow.Cells["SDT"].Value?.ToString() ?? string.Empty;
                txt_tongNo.Text = selectedRow.Cells["TongNo"].Value?.ToString() ?? string.Empty;
                txt_tongTien.Text = selectedRow.Cells["TongTien"].Value?.ToString() ?? string.Empty;
            }
        }

        private void btn_xoaNCC_Click(object sender, EventArgs e)
        {
            if (dtgv_nhaCungCap.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa!", "Thông báo");
                return;
            }

            string maNCC = dtgv_nhaCungCap.SelectedRows[0].Cells[0].Value.ToString();
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";
            string query = "DELETE FROM NCC WHERE MaNCC = @MaNCC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa nhà cung cấp thành công!");
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
