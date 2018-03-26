using Bunifu.Framework.UI;
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
    public partial class fAddFood : Form
    {

        public static bool closed = false;
        public fAddFood()
        {
            InitializeComponent();
            LoadInfoBill();
            closed = false;
        }
        
        #region Events
        private void btnBlock_Click(object sender, EventArgs e)
        {
            closed = true;
            this.Close();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        
        #region Methods
        public void LoadInfoBill()
        {

            fLoginStaff f = new fLoginStaff();
            lbNameStaff.Text = TableManagerBLL.Instance.GetNameStaff(f.GetPinCode());
            fTableManager fTable = new fTableManager();
            lbTableName.Text = "Bàn: " + fTable.GetNameTable();

        }
        public static bool FormClosedd()
        {
            return closed;
        }
        public void LoadCategory()
        {
            AddFoodBLL.Instance.LoadButtonBack(flpnlFood);
            AddFoodBLL.Instance.LoadUnitCategory(flpnlFood);
            AddFoodBLL.Instance.LoadFoodCategory(flpnlFood);
            AddFoodBLL.Instance.LoadFood(flpnlFood);
        }

        
        #endregion

        private void fAddFood_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }
    }
}
