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
    public partial class fAddFood : Form
    {
        public static bool closed = false;
        public static bool FormClosedd()
        {
            return closed;
        }
        public fAddFood()
        {
            InitializeComponent();
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            closed = true;
            this.Close();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
