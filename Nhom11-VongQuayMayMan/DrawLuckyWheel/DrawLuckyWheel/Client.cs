using System;
using System.Net.Sockets;
using System.Text;

namespace DrawLuckyWheel
{
    public class Client
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private const string serverAddress = "127.0.0.1"; // Địa chỉ IP của server (localhost cho thử nghiệm)
        private const int serverPort = 8080; // Cổng mà server đang lắng nghe

        public Client()
        {
            tcpClient = new TcpClient();
        }

        public void ConnectToServer()
        {
            try
            {
                // Kết nối tới server
                tcpClient.Connect(serverAddress, serverPort);
                stream = tcpClient.GetStream();
                Console.WriteLine("Connected to server.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to server: {ex.Message}");
            }
        }

        public void SendRequest(string message)
        {
            try
            {
                // Chuyển đổi thông điệp thành byte array và gửi đến server
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                stream.Write(messageBytes, 0, messageBytes.Length);
                Console.WriteLine($"Sent to server: {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }

        public void ReceiveResponse()
        {
            try
            {
                // Đọc phản hồi từ server
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received from server: {response}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving response: {ex.Message}");
            }
        }

        public void CloseConnection()
        {
            try
            {
                // Đóng kết nối với server
                stream.Close();
                tcpClient.Close();
                Console.WriteLine("Connection closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing connection: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            Client client = new Client();
            client.ConnectToServer();

            // Gửi yêu cầu tới server
            client.SendRequest("SPIN");

            // Nhận phản hồi từ server
            client.ReceiveResponse();

            // Đóng kết nối
            client.CloseConnection();
        }
    }
}
