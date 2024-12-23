using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Loan_Spa
{
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hàm dùng để thực thi câu lệnh SQL trả về dữ liệu
        /// </summary>
        private object ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            string connectionString = "Server=.; Database=QLSpa_1; Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực thi truy vấn: " + ex.Message, "Lỗi");
                }
            }

            return result;
        }


        
        // Hàm hiển thị kết quả lên giao diện với định dạng số đẹp
        private void DisplayResults(decimal tongDoanhThu, decimal tongChiPhi, decimal tongLai, decimal tongLo)
        {
            // Định dạng lại số với phân cách hàng nghìn và không có số thập phân
            txt_tongDoanhThu.Text = tongDoanhThu.ToString("N0") + " đ";  // N0: không có chữ số thập phân
            txt_tongChiPhi.Text = tongChiPhi.ToString("N0") + " đ";
            txt_tongLai.Text = tongLai.ToString("N0") + " đ";
            txt_tongLo.Text = tongLo.ToString("N0") + " đ";
        }



        private decimal TinhTongDoanhThu(DateTime fromDate, DateTime toDate)
        {
            string query = @"
        SELECT SUM(TongTien) AS TongDoanhThu
        FROM HoaDon
        WHERE NgayLap BETWEEN @FromDate AND @ToDate";

            SqlParameter[] parameters = {
        new SqlParameter("@FromDate", fromDate),
        new SqlParameter("@ToDate", toDate)
    };

            var result = ExecuteQuery(query, parameters);
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        private decimal TinhTongChiPhi(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                            SELECT ISNULL(SUM(ct.soLuong * ct.donGia), 0) AS TongChiPhi
                            FROM CT_NHAPHANG_HANGHOA ct
                            INNER JOIN NHAPHANG nh ON ct.maNH = nh.maNH
                            WHERE nh.ngayLap BETWEEN @FromDate AND @ToDate";

            SqlParameter[] parameters = {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

            var result = ExecuteQuery(query, parameters);
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }


        private (decimal TongLai, decimal TongLo) TinhLaiLo(DateTime fromDate, DateTime toDate)
        {
            decimal tongDoanhThu = TinhTongDoanhThu(fromDate, toDate);
            decimal tongChiPhi = TinhTongChiPhi(fromDate, toDate);

            decimal chenhLech = tongDoanhThu - tongChiPhi;

            decimal tongLai = chenhLech >= 0 ? chenhLech : 0;
            decimal tongLo = chenhLech < 0 ? Math.Abs(chenhLech) : 0;

            return (tongLai, tongLo);
        }


        // Tính tổng doanh thu, tổng chi phí, tổng lãi và tổng lỗ theo tuần
        private void LoadTongDoanhThuTheoTuan()
        {
            //DateTime startOfWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek + 1); // Bắt đầu tuần
            DateTime startOfWeek = DateTime.Now.AddDays(-((int)DateTime.Now.DayOfWeek == 0 ? 6 : (int)DateTime.Now.DayOfWeek - 1));
            DateTime toDate = DateTime.Now; // Giới hạn đến ngày hôm nay

            var tongDoanhThu = TinhTongDoanhThu(startOfWeek, toDate);
            var tongChiPhi = TinhTongChiPhi(startOfWeek, toDate);
            var (tongLai, tongLo) = TinhLaiLo(startOfWeek, toDate);

            // Gọi hàm DisplayResults để hiển thị kết quả
            DisplayResults(tongDoanhThu, tongChiPhi, tongLai, tongLo);
        }

        // Tính tổng doanh thu, tổng chi phí, tổng lãi và tổng lỗ theo tháng
        private void LoadTongDoanhThuTheoThang()
        {
            DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Bắt đầu tháng
            DateTime toDate = DateTime.Now; // Giới hạn đến ngày hôm nay

            var tongDoanhThu = TinhTongDoanhThu(startOfMonth, toDate);
            var tongChiPhi = TinhTongChiPhi(startOfMonth, toDate);
            var (tongLai, tongLo) = TinhLaiLo(startOfMonth, toDate);

            // Gọi hàm DisplayResults để hiển thị kết quả
            DisplayResults(tongDoanhThu, tongChiPhi, tongLai, tongLo);
        }

        // Tính tổng doanh thu, tổng chi phí, tổng lãi và tổng lỗ theo năm
        private void LoadTongDoanhThuTheoNam()
        {
            DateTime startOfYear = new DateTime(DateTime.Now.Year, 1, 1); // Bắt đầu năm
            DateTime toDate = DateTime.Now; // Giới hạn đến ngày hôm nay

            var tongDoanhThu = TinhTongDoanhThu(startOfYear, toDate);
            var tongChiPhi = TinhTongChiPhi(startOfYear, toDate);
            var (tongLai, tongLo) = TinhLaiLo(startOfYear, toDate);

            // Gọi hàm DisplayResults để hiển thị kết quả
            DisplayResults(tongDoanhThu, tongChiPhi, tongLai, tongLo);
        }

        // Tính tổng doanh thu, tổng chi phí, tổng lãi và tổng lỗ trong khoảng thời gian người dùng chọn
        private void LoadTongDoanhThuTheoKhoangThoiGian(DateTime fromDate, DateTime toDate)
        {
            var tongDoanhThu = TinhTongDoanhThu(fromDate, toDate);
            var tongChiPhi = TinhTongChiPhi(fromDate, toDate);
            var (tongLai, tongLo) = TinhLaiLo(fromDate, toDate);

            // Gọi hàm DisplayResults để hiển thị kết quả
            DisplayResults(tongDoanhThu, tongChiPhi, tongLai, tongLo);
        }

        // Xử lý sự kiện khi nút báo cáo được nhấn
        private void btn_taoBaoCao_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtp_tuNgay.Value;
            DateTime toDate = dtp_denNgay.Value;

            // Kiểm tra các điều kiện lựa chọn và gọi các hàm tương ứng
            if (rdb_theoTuan.Checked)
                LoadTongDoanhThuTheoTuan();
            else if (rdb_theoThang.Checked)
                LoadTongDoanhThuTheoThang();
            else if (rdb_theoNam.Checked)
                LoadTongDoanhThuTheoNam();
            else if (rdb_khoang.Checked)
                LoadTongDoanhThuTheoKhoangThoiGian(fromDate, toDate);
        }

        // Thiết lập mặc định cho DateTimePicker nếu cần
        private void BaoCao_Load(object sender, EventArgs e)
        {
            dtp_tuNgay.Value = DateTime.Now.AddDays(-7); // Mặc định là 7 ngày trước
            dtp_denNgay.Value = DateTime.Now; // Mặc định là ngày hiện tại
        }
    }
}
