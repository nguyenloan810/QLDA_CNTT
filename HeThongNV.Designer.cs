
namespace QLCHMyPham
{
    partial class HeThongNV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTTKH = new System.Windows.Forms.Button();
            this.btnHD = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTTKH
            // 
            this.btnTTKH.AutoSize = true;
            this.btnTTKH.BackColor = System.Drawing.Color.Transparent;
            this.btnTTKH.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnTTKH.FlatAppearance.BorderSize = 0;
            this.btnTTKH.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTTKH.ForeColor = System.Drawing.Color.SeaShell;
            this.btnTTKH.Location = new System.Drawing.Point(17, 97);
            this.btnTTKH.Name = "btnTTKH";
            this.btnTTKH.Size = new System.Drawing.Size(280, 57);
            this.btnTTKH.TabIndex = 8;
            this.btnTTKH.Text = "Thông tin Khách Hàng";
            this.btnTTKH.UseVisualStyleBackColor = false;
            this.btnTTKH.Click += new System.EventHandler(this.btnTTKH_Click);
            // 
            // btnHD
            // 
            this.btnHD.AutoSize = true;
            this.btnHD.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnHD.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnHD.FlatAppearance.BorderSize = 0;
            this.btnHD.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHD.ForeColor = System.Drawing.Color.SeaShell;
            this.btnHD.Location = new System.Drawing.Point(17, 160);
            this.btnHD.Name = "btnHD";
            this.btnHD.Size = new System.Drawing.Size(280, 57);
            this.btnHD.TabIndex = 9;
            this.btnHD.Text = "Hóa Đơn";
            this.btnHD.UseVisualStyleBackColor = false;
            this.btnHD.Click += new System.EventHandler(this.btnHD_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.AutoSize = true;
            this.btnDangXuat.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDangXuat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.Font = new System.Drawing.Font("Garamond", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.SeaShell;
            this.btnDangXuat.Location = new System.Drawing.Point(17, 223);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(280, 57);
            this.btnDangXuat.TabIndex = 10;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MintCream;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(82, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Chào mừng đến với hệ thống quản lý bán hàng dành cho nhân viên";
            // 
            // HeThongNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(833, 552);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnTTKH);
            this.Controls.Add(this.btnHD);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HeThongNV";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeThongNV";
            this.Load += new System.EventHandler(this.HeThongNV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTTKH;
        private System.Windows.Forms.Button btnHD;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Label label1;
    }
}