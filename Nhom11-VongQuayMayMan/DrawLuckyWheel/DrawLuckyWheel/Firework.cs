using AxWMPLib;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawLuckyWheel
{
    public partial class Firework : Form
    {
        private Label resultLabel;

        public Firework(string resultText)
        {
            InitializeComponent();
            SetupVideo(resultText);
        }

        private void SetupVideo(string resultText)
        {
            // Kiểm tra và dừng video nếu nó đang phát

            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop(); // Dừng video nếu đang phát
            }

            // Thiết lập lại video cho mỗi lần mở form
            axWindowsMediaPlayer1.URL = @"D:\Năm 3-HK1 -2024-2025\HQT CSDL\DrawLuckyWheel\DrawLuckyWheel (1)\DrawLuckyWheel\Resources\FireworkVideo.mp4"; // Đường dẫn đến video
            axWindowsMediaPlayer1.uiMode = "none";  // Ẩn giao diện điều khiển của Media Player
            axWindowsMediaPlayer1.stretchToFit = true;  // Kéo giãn video để phù hợp với form
            axWindowsMediaPlayer1.settings.setMode("loop", true);  // Lặp lại video

            // Bắt đầu phát video từ đầu
            axWindowsMediaPlayer1.Ctlcontrols.play();

            // Tạo và thiết lập label hiển thị kết quả
            resultLabel = new Label
            {
                Text = "Kết quả: " + resultText,  // Set the result text
                ForeColor = Color.Black,  // Set text color to white
                Font = new Font("Arial", 30, FontStyle.Bold),  // Set font style and size
                AutoSize = true,  // Let the label size adjust automatically
                Location = new Point(this.ClientSize.Width / 2 - 110, this.ClientSize.Height / 2 - 40)  // Center the label
            };

            // Thêm label vào form
            this.Controls.Add(resultLabel);

            // Đưa label lên phía trước video
            resultLabel.BringToFront();
        }

        // Khi form được đóng, dừng video
        private void OKbtn_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();  // Dừng video khi form đóng
            this.Close();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void Firework_Load(object sender, EventArgs e)
        {

        }
    }
}
