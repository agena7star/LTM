using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DrawLuckyWheel
{
    internal class Connection
    {
        private  static string  stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\NĂM 3-HK1 -2024-2025\HQT CSDL\DRAWLUCKYWHEEL\DRAWLUCKYWHEEL (1)\DRAWLUCKYWHEEL\DATABASE1.MDF"";Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
