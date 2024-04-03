using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLCHMyPham
{
    public class Ketnoi
    {
        private string con_str = "";
        private SqlConnection conn = null;

        public Ketnoi()
        {
            con_str = @"Data Source=DESKTOP-HIEU\SQLEXPRESS01;Initial Catalog=kiemthu;Integrated Security=True";
             conn = new SqlConnection(con_str);
        }

        public bool ThucThi(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
       

        public DataSet laydulieu(string sql, string tb_name)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, tb_name);

            }
            catch
            {

            }
            return ds;
        }
    }
}
