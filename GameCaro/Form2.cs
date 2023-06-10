using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GameCaro
{
    public partial class Form2 : Form
    {
        public delegate void Truyenform1(string text);
        public Truyenform1 truyenData;
        public delegate void delPassData1(TextBox text);

        public delegate void delPassData2(TextBox text);
        public Form2()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }
        public static string Name1;
        public static string Name2;
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (txbPlayerName1.Text.Length > 0)
            {
                if (truyenData != null)
                    truyenData(txbPlayerName1.Text);
            }
            Name1 = txbPlayerName1.Text;
            Name2 = txbPlayerName2.Text;
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.ShowDialog();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
