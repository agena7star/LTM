using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawLuckyWheel
{
    public partial class FormDangNhap : Form
    {
        // Constructor của FormDangNhap
        public FormDangNhap()
        {
            InitializeComponent(); // Khởi tạo các thành phần của form
        }

        Modify modify = new Modify(); // Tạo một đối tượng Modify để thao tác với cơ sở dữ liệu

        // Sự kiện khi nhấn nút Đăng Nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Lấy thông tin tên tài khoản và mật khẩu từ các ô nhập liệu
            string tentk = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;

            // Kiểm tra nếu ô tên tài khoản trống
            if (tentk.Trim() == "")
            {
                MessageBox.Show("Vui Lòng Nhập Tên Tài Khoản!");
            }
            // Kiểm tra nếu ô mật khẩu trống
            else if (matkhau.Trim() == "")
            {
                MessageBox.Show("Vui Lòng Nhập Mật Khẩu!");
            }
            else
            {
                // Chuỗi truy vấn SQL để kiểm tra tên tài khoản và mật khẩu
                string query = "Select * from TaiKhoan where TenTaiKhoan = '" + tentk + "' and MatKhau = '" + matkhau + "'";

                // Nếu truy vấn trả về kết quả (nghĩa là thông tin đăng nhập hợp lệ)
                if (modify.TaiKhoans(query).Count > 0)
                {
                    // Hiển thị thông báo đăng nhập thành công
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide(); // Ẩn form đăng nhập

                    
                    FormMeNu menu = new FormMeNu();
                    menu.ShowDialog(); // Hiển thị form vòng quay dưới dạng dialog
                    this.Close(); // Đóng form đăng nhập sau khi đóng form vòng quay
                }
                else
                {
                    // Hiển thị thông báo khi tên tài khoản hoặc mật khẩu không chính xác
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Sự kiện khi nhấn nút Thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát ứng dụng
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        // Sự kiện khi nhấn vào link "Quên Mật Khẩu"
        private void linkLabel_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở form QuenMatKhau
            QuenMatKhau quenmatkhau = new QuenMatKhau();
            quenmatkhau.ShowDialog(); // Hiển thị form QuenMatKhau dưới dạng dialog
        }

        // Sự kiện khi nhấn vào link "Đăng Ký"
        private void linkLabel_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở form Đăng Ký
            DangKy dangky = new DangKy();
            dangky.ShowDialog(); // Hiển thị form Đăng Ký dưới dạng dialog
        }

        // Sự kiện khác khi nhấn nút Thoát
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát ứng dụng
        }
    }
}
