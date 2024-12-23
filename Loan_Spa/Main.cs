using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Loan_Spa
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HangHoa hangHoa = new HangHoa();
            hangHoa.FormClosed += SubForm_FormClosed; // Gắn sự kiện FormClosed
            hangHoa.Show();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DichVu dichVu = new DichVu();
            dichVu.FormClosed += SubForm_FormClosed; // Gắn sự kiện FormClosed
            dichVu.Show();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon hoaDon = new HoaDon();
            hoaDon.FormClosed += SubForm_FormClosed; // Gắn sự kiện FormClosed
            hoaDon.Show();
        }

        private void phiếuNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhieuNhapHang phieuNhapHang = new PhieuNhapHang();
            phieuNhapHang.FormClosed += SubForm_FormClosed; // Gắn sự kiện FormClosed
            phieuNhapHang.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang khachHang = new KhachHang();
            khachHang.FormClosed += SubForm_FormClosed; // Gắn sự kiện FormClosed
            khachHang.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhaCungCap nhaCungCap = new NhaCungCap();
            nhaCungCap.FormClosed += SubForm_FormClosed; // Gắn sự kiện FormClosed
            nhaCungCap.Show();
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCao baoCao = new BaoCao();
            baoCao.FormClosed += SubForm_FormClosed; // Gắn sự kiện FormClosed
            baoCao.Show();
        }

        private void LoadTongQuan()
        {
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Lấy số lượng khách hàng đã có hóa đơn hôm nay
                    textBox1.Text = GetCount("SELECT COUNT(DISTINCT KH.maKH) " +
                        "FROM KHACHHANG KH JOIN HOADON HD ON KH.maKH = HD.maKH " +
                        "WHERE CONVERT(DATE, HD.ngayLap) = CONVERT(DATE, GETDATE())", conn).ToString();

                    // Lấy tổng thu hôm nay
                    textBox2.Text = GetSum(@"
                                            SELECT ISNULL(SUM(tongSauGiam), 0) 
                                            FROM HOADON 
                                            WHERE CONVERT(DATE, ngayLap) = CONVERT(DATE, GETDATE())", conn).ToString("C0");

                    // Lấy tổng chi hôm nay
                    textBox3.Text = GetSum(@"
                                            SELECT ISNULL(SUM(tongTien), 0) 
                                            FROM NHAPHANG 
                                            WHERE CONVERT(DATE, ngayLap) = CONVERT(DATE, GETDATE())", conn).ToString("C0");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu tổng quan: " + ex.Message, "Lỗi");
                }
            }
        }

        // Phương thức lấy số lượng
        private int GetCount(string query, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }

        // Phương thức lấy tổng số tiền
        private decimal GetSum(string query, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                var result = cmd.ExecuteScalar();
                return result != DBNull.Value ? (decimal)result : 0; // Tránh lỗi khi không có giá trị
            }
        }

        private void SubForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadTongQuan(); // Làm mới dữ liệu khi form con đóng
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadTongQuan(); // Tải dữ liệu ban đầu
        }
    }
}
