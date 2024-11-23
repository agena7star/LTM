using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawLuckyWheel
{
    public partial class DangKy : Form
    {
        // Constructor cho form DangKy
        public DangKy()
        {
            InitializeComponent(); // Khởi tạo các thành phần của form
        }

        // Sự kiện khi form DangKy được tải lên
        private void DangKy_Load(object sender, EventArgs e)
        {

        }

        // Phương thức kiểm tra tên tài khoản hợp lệ (chứa 6-24 ký tự, gồm chữ và số)
        public bool checkAccount(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,24}$"); // Biểu thức chính quy kiểm tra điều kiện
        }

        // Phương thức kiểm tra email hợp lệ (có định dạng "@gmail.com" hoặc "@gmail.com.vn")
        public bool checkEmail(string em)
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,30}@gmail.com(.vn|)$"); // Biểu thức chính quy kiểm tra điều kiện
        }

        Modify modify = new Modify(); // Đối tượng để thao tác với cơ sở dữ liệu

        // Sự kiện khi người dùng nhấn vào button1 để đăng ký tài khoản
        private void button1_Click(object sender, EventArgs e)
        {
            string tentk = txtTaiKhoan.Text; // Lấy giá trị từ trường nhập tài khoản
            string matkhau = txtMatKhau.Text; // Lấy giá trị từ trường nhập mật khẩu
            string xnmatkhau = txtXNMatKhau.Text; // Lấy giá trị từ trường xác nhận mật khẩu
            string email = txtEmail.Text; // Lấy giá trị từ trường nhập email

            // Kiểm tra tên tài khoản có hợp lệ không
            if (!checkAccount(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài 6 -24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!");
                return;
            }

            // Kiểm tra mật khẩu có hợp lệ không
            if (!checkAccount(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu dài 6 -24 ký tự, với các ký tự chữ và số, chữ hoa và chữ thường!");
                return;
            }

            // Kiểm tra mật khẩu xác nhận khớp với mật khẩu đã nhập không
            if (xnmatkhau != matkhau)
            {
                MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác!");
                return;
            }

            // Kiểm tra định dạng email
            if (!checkEmail(email))
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email!");
                return;
            }

            // Kiểm tra email đã tồn tại trong cơ sở dữ liệu chưa
            if (modify.TaiKhoans("Select * from TaiKhoan where Email ='" + email + "'").Count != 0)
            {
                MessageBox.Show("Email này đã được đăng ký, vui lòng nhập email khác!");
                return;
            }

            try
            {
                // Thực hiện câu lệnh SQL để thêm tài khoản mới
                string query = "Insert into TaiKhoan values('" + tentk + "' , '" + matkhau + "','" + email + "')";
                modify.Command(query); // Gọi phương thức để thực thi câu lệnh SQL

                // Hiển thị thông báo đăng ký thành công và hỏi người dùng có muốn đăng nhập không
                if (MessageBox.Show("Đăng ký tài khoản thành công! Bạn có muốn đăng nhập luôn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close(); // Đóng form đăng ký nếu người dùng chọn Yes
                }
            }
            catch
            {
                // Hiển thị thông báo nếu tên tài khoản đã tồn tại
                MessageBox.Show("Tên tài khoản này đã được đăng ký, vui lòng đăng ký tên tài khoản khác!");
            }
        }

        // Sự kiện khi nội dung trong txtTaiKhoan thay đổi (chưa có nội dung thực thi)
        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
