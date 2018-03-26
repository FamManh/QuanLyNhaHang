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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        #region Event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login(txbUserName.Text, txbPassword.Text))
            {
                lbWarning.Visible = false;
                fAdmin f = new fAdmin();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
                lbWarning.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        #region Methods
        bool Login(string userName, string password)
        {
            return AccountBLL.Instance.Login(userName, password);
        }
        #endregion
    }
}
