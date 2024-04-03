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
    public partial class GioiThieu : Form
    {
        public GioiThieu()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeThong f = new HeThong();
            f.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            < iframe src = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3723.936613849071!2d105.79137588687928!3d21.035222093406126!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135abf7ea9236db%3A0xb8cc0a42158a398!2zS8OtbmggTeG6r3QgVmnhu4d0IEFu!5e0!3m2!1svi!2s!4v1685201334719!5m2!1svi!2s" width = "600" height = "450" style = "border:0;" allowfullscreen = "" loading = "lazy" referrerpolicy = "no-referrer-when-downgrade" ></ iframe >
        }
    }
}
