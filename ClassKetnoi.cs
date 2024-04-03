using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLCHMyPham
{

    class ClassKetnoi
    {
        public SqlConnection conn;

        public void ketnoi()
        {
        conn = new SqlConnection(@"Data Source=DESKTOP-R9N8N7D\SQLEXPRESS;Initial Catalog=QLCH_MyPham;Integrated Security=True");
        conn.Open();
        }
}
   
}
