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
        public fTableManager()
        {
            InitializeComponent();
        }

       

        private void btnVN1_Click(object sender, EventArgs e)
        {
            LoadFormAddFood();
        }
        public void LoadFormAddFood()
        {
            fAddFood fAddFood = new fAddFood();
            fAddFood.Show();
            if (fAddFood.FormClosedd())
            {
                this.Close();
            }
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
