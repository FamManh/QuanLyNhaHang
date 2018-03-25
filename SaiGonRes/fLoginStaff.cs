using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaiGonRes
{
    public partial class fLoginStaff : Form
    {
        public fLoginStaff()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txbPIN.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txbPIN.Text += "2";

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txbPIN.Text += "3";

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txbPIN.Text += "4";

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txbPIN.Text += "5";

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txbPIN.Text += "6";

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txbPIN.Text += "7";

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txbPIN.Text += "8";

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txbPIN.Text += "9";

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txbPIN.Text += "0";

        }

        private void txbPIN_TextChanged(object sender, EventArgs e)
        {
            if (txbPIN.Text.Length == 3)
            {
                if (txbPIN.Text == "555")
                {
                    fTableManager fTableManager = new fTableManager();
                    this.Hide();
                    fTableManager.ShowDialog();
                    txbPIN.Text = "";
                    this.Show();
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txbPIN.Text = txbPIN.Text.Substring(0, txbPIN.Text.Length - 1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
