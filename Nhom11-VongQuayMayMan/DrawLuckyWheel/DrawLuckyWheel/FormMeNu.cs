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
    public partial class FormMeNu : Form
    {
        public FormMeNu()
        {
            InitializeComponent();
        }

        private void btnSL_Click(object sender, EventArgs e)
        {
            // Mở form vòng quay
            FormVongQuay home = new FormVongQuay();
            home.ShowDialog(); // Hiển thị form vòng quay dưới dạng dialog
            this.Close(); // Đóng form đăng nhập sau khi đóng form vòng quay
        }

        private void btnCnt_Click(object sender, EventArgs e)
        {
            FormConnect formCN1 = new FormConnect();
            FormConnect formCN2 = new FormConnect();

            formCN1.Show();  // Show the first player's form
            formCN2.Show();  // Show the second player's form
        }

        private void FormMeNu_Load(object sender, EventArgs e)
        {

        }
    }
    
}
