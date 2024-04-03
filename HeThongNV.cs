using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHMyPham
{
    public partial class HeThongNV : Form
    {
        public HeThongNV()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            Hoa_Don f = new Hoa_Don();
            f.Show();
            
        }

        private void btnTTKH_Click(object sender, EventArgs e)
        {
            KhachHang k = new KhachHang();
            k.Show();
            
        }

        private void HeThongNV_Load(object sender, EventArgs e)
        {

        }
    }
}
