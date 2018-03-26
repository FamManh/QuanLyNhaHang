using SaiGonRes.BLL;
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
    public partial class fTableManager : Form
    {
        static String NameTable = "";
        public string GetNameTable()
        {
            return NameTable;
        }
        public fTableManager()
        {
            InitializeComponent();
            LoadNameStaff();
        }
        
        public void LoadNameStaff()
        {
            fLoginStaff f = new fLoginStaff();
            lbNameStaff.Text =  TableManagerBLL.Instance.GetNameStaff(f.GetPinCode());
        }
        public void LoadFormAddFood()
        {
            fAddFood fAddFood = new fAddFood();
            fAddFood.ShowDialog();
            if (fAddFood.FormClosedd())
            {
                this.Close();
            }
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            NameTable = btn1.ButtonText;
            LoadFormAddFood();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            NameTable = btn2.ButtonText;
            LoadFormAddFood();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            NameTable = btn3.ButtonText;
            LoadFormAddFood();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            NameTable = btn4.ButtonText;
            LoadFormAddFood();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            NameTable = btn5.ButtonText;
            LoadFormAddFood();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            NameTable = btn6.ButtonText;
            LoadFormAddFood();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            NameTable = btn7.ButtonText;
            LoadFormAddFood();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            NameTable = btn8.ButtonText;
            LoadFormAddFood();
        }
    }
}
