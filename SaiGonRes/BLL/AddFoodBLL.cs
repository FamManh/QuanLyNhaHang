using Bunifu.Framework.UI;
using SaiGonRes.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaiGonRes.BLL
{
    public class AddFoodBLL
    {
        BunifuThinButton2 btnBack = new BunifuThinButton2();
        static string CurrentUnit = "UnitCategory";
        BunifuThinButton2[] ButtonUnitCategory;
        BunifuThinButton2[] ButtonFoodCategory;
        BunifuThinButton2[] ButtonFood;
        AddFoodBLL() { }
        static AddFoodBLL _Instance;

        public static AddFoodBLL Instance { get { if (_Instance == null) _Instance = new AddFoodBLL(); return _Instance; } private set => _Instance = value; }

        

        public void LoadButtonBack (FlowLayoutPanel flpnl)
        {

            btnBack.ButtonText = "...";
            btnBack.ActiveCornerRadius = 20;
            btnBack.ActiveFillColor = System.Drawing.Color.Silver;
            btnBack.ActiveForecolor = System.Drawing.Color.Black;
            btnBack.ActiveLineColor = System.Drawing.Color.Silver;
            btnBack.IdleFillColor = System.Drawing.Color.Silver;
            btnBack.IdleForecolor = System.Drawing.Color.Black;
            btnBack.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnBack.IdleLineColor = System.Drawing.Color.Silver;
            btnBack.BackColor = System.Drawing.SystemColors.Control;
            btnBack.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            btnBack.Size = new System.Drawing.Size(202, 91);
            btnBack.Visible = false;
            flpnl.Controls.Add(btnBack);
            btnBack.Click += BtnBack_Click;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (CurrentUnit == "UnitCategory")
            {
                
            } else if (CurrentUnit == "FoodCategory")
            {
                CurrentUnit = "UnitCategory";
                btnBack.Visible = false;

                for (int i = 0; i < ButtonUnitCategory.Length; i++)
                {
                    ButtonUnitCategory[i].Visible = true;
                    
                }
                for (int i = 0; i < ButtonFoodCategory.Length; i++)
                {
                    ButtonFoodCategory[i].Visible = false;
                    
                }
                for (int i = 0; i < ButtonFood.Length; i++)
                {
                    ButtonFood[i].Visible = false;
                }
            } else if (CurrentUnit == "Food")
            {
                CurrentUnit = "FoodCategory";

                for (int i = 0; i < ButtonUnitCategory.Length; i++)
                {
                    ButtonUnitCategory[i].Visible = false;

                }
                for (int i = 0; i < ButtonFoodCategory.Length; i++)
                {
                    ButtonFoodCategory[i].Visible = true;

                }
                for (int i = 0; i < ButtonFood.Length; i++)
                {
                    ButtonFood[i].Visible = false;
                }
            }
        }

        public void LoadUnitCategory(FlowLayoutPanel flpnl)
        {
            
            DataTable dt = new DataTable();
            string str = "";
            string query = "SELECT Name FROM dbo.UnitCategory";
            dt = DataProvider.Instance.FExecuteQuery(query);
            int CountUnit = dt.Rows.Count;
            ButtonUnitCategory = new BunifuThinButton2[CountUnit];

            for (int i = 0; i < CountUnit; i++)
            {
                str = dt.Rows[i]["Name"].ToString();
                BunifuThinButton2 btn = new BunifuThinButton2();
                btn.Tag = "UnitCategory";
                DrawButton(btn, str);
                btn.Click += Btn_Click;
                flpnl.Controls.Add(btn);
                ButtonUnitCategory[i] = btn;
            }

        }
        
        private void Btn_Click(object sender, EventArgs e)
        {

            btnBack.Visible = true;
            CurrentUnit = "FoodCategory";
            
            
            BunifuThinButton2 btn = sender as BunifuThinButton2;
            
            for (int i = 0; i < ButtonUnitCategory.Length; i++)
            {
                ButtonUnitCategory[i].Visible = false;
            }

            for (int i = 0; i < ButtonFoodCategory.Length; i++)
            {
                for (int j = 0; j < GetListFoodCategory(btn.ButtonText).Length; j++)
                {
                    if (ButtonFoodCategory[i].ButtonText == GetListFoodCategory(btn.ButtonText)[j])
                    {
                        ButtonFoodCategory[i].Visible = true;
                    }
                }
               
            }

        }

        public string [] GetListFoodCategory (string str)
        {
            string queryGetIdUnitCategory = "Select ID from UnitCategory where Name = N'" + str + "'";
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.FExecuteQuery(queryGetIdUnitCategory);
            string IdUnitCategory = dt.Rows[0]["ID"].ToString();
            string queryGetFoodCategory = "Select Name from FoodCategory where IDUnit = '" + IdUnitCategory + "'";
            DataTable dtList = new DataTable();
            dtList = DataProvider.Instance.FExecuteQuery(queryGetFoodCategory);
            string[] List = new string[dtList.Rows.Count];
            for (int i = 0; i < dtList.Rows.Count; i++)
            {
                List[i] = dtList.Rows[i]["Name"].ToString();
            }
            return List;
        }

        public string[] GetListFood(string str)
        {
            string queryGetIdFoodCategory = "Select ID from FoodCategory where Name = N'" + str + "'";
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.FExecuteQuery(queryGetIdFoodCategory);
            string IdFoodCategory = dt.Rows[0]["ID"].ToString();
            string queryGetFoodCategory = "Select Name from Food where IDFoodCategory = '" + IdFoodCategory + "'";
            DataTable dtList = new DataTable();
            dtList = DataProvider.Instance.FExecuteQuery(queryGetFoodCategory);
            string[] List = new string[dtList.Rows.Count];
            for (int i = 0; i < dtList.Rows.Count; i++)
            {
                List[i] = dtList.Rows[i]["Name"].ToString();
            }
            return List;
        }
        public void  LoadFoodCategory(FlowLayoutPanel flpnl)
        {
            DataTable dt = new DataTable();
            //string idUnit = LoadIdCategory(NameCategory);
            string str = "";
            string query = "SELECT Name FROM dbo.FoodCategory";
            dt = DataProvider.Instance.FExecuteQuery(query);
            int CountCategory = dt.Rows.Count;
            ButtonFoodCategory = new BunifuThinButton2[CountCategory];


            for (int i = 0; i < CountCategory; i++)
            {
                str = dt.Rows[i]["Name"].ToString();
                BunifuThinButton2 btnCategory = new BunifuThinButton2();
                btnCategory.Visible = false;
                DrawButton(btnCategory, str);
                ButtonFoodCategory[i] = btnCategory;
                btnCategory.Click += BtnCategory_Click;
                flpnl.Controls.Add(btnCategory);
            }
        }

        private void BtnCategory_Click(object sender, EventArgs e)
        {
            btnBack.Visible = true;
            CurrentUnit = "Food";

            fAddFood f = new fAddFood();
            f.btnGoBack.Visible = true;
            BunifuThinButton2 btn = sender as BunifuThinButton2;

            
            for (int i = 0; i < ButtonFoodCategory.Length; i++)
            {
                ButtonFoodCategory[i].Visible = false;
            }
            for (int i = 0; i < ButtonFood.Length; i++)
            {
                for (int j = 0; j < GetListFood(btn.ButtonText).Length; j++)
                {
                    if (ButtonFood[i].ButtonText == GetListFood(btn.ButtonText)[j])
                    {
                        ButtonFood[i].Visible = true;
                    }
                }
            }
        }

        public void LoadFood(FlowLayoutPanel flpnl)
        {
            DataTable dt = new DataTable();
            string str = "";
            string query = "SELECT Name FROM dbo.Food";
            dt = DataProvider.Instance.FExecuteQuery(query);
            int CountFood = dt.Rows.Count;
            ButtonFood = new BunifuThinButton2[CountFood];


            for (int i = 0; i < CountFood; i++)
            {
                str = dt.Rows[i]["Name"].ToString();
                BunifuThinButton2 btnFood = new BunifuThinButton2();
                btnFood.Visible = false;
                DrawButtonFood(btnFood, str);
                ButtonFood[i] = btnFood;
                btnFood.Click += BtnFood_Click;
                flpnl.Controls.Add(btnFood);
            }
        }

        private void BtnFood_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public string LoadIdCategory(string UnitCategory)
        {
            DataTable dt = new DataTable();
            string str = "";
            string query = "SELECT Id FROM dbo.UnitCategory where Name = N'"+ UnitCategory + "'";
            dt = DataProvider.Instance.FExecuteQuery(query);
            str = dt.Rows[0]["Id"].ToString();
            return str;
        }
        void DrawButton (BunifuThinButton2 btn, string text)
        {
            btn.ButtonText = text;
            btn.ActiveCornerRadius = 20;
            btn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            btn.ActiveForecolor = System.Drawing.Color.White;
            btn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            btn.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            btn.IdleForecolor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            btn.BackColor = System.Drawing.SystemColors.Control;
            btn.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            btn.Size = new System.Drawing.Size(202, 91);
            
        }
        void DrawButtonFood(BunifuThinButton2 btn, string text)
        {
            btn.ButtonText = text;
            btn.ActiveCornerRadius = 20;
            btn.ActiveFillColor = System.Drawing.Color.Silver;
            btn.ActiveForecolor = System.Drawing.Color.Black;
            btn.ActiveLineColor = System.Drawing.Color.Silver;
            btn.IdleFillColor = System.Drawing.Color.Silver;
            btn.IdleForecolor = System.Drawing.Color.Black;
            btn.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.IdleLineColor = System.Drawing.Color.Silver;
            btn.BackColor = System.Drawing.SystemColors.Control;
            btn.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            btn.Size = new System.Drawing.Size(202, 91);

            
        }
    }

}
#region Button
//this.bunifuThinButton21.ActiveBorderThickness = 1;
//    this.bunifuThinButton21.ActiveCornerRadius = 20;
//    this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
//    this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.White;
//    this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
//    this.bunifuThinButton21.BackColor = System.Drawing.SystemColors.Control;
//    this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
//    this.bunifuThinButton21.ButtonText = "Quầy Bar";
//    this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
//    this.bunifuThinButton21.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//    this.bunifuThinButton21.ForeColor = System.Drawing.Color.SeaGreen;
//    this.bunifuThinButton21.IdleBorderThickness = 1;
//    this.bunifuThinButton21.IdleCornerRadius = 20;
//    this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
//    this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.White;
//    this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
//    this.bunifuThinButton21.Location = new System.Drawing.Point(5, 0);
//    this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
//    this.bunifuThinButton21.Name = "bunifuThinButton21";
//    this.bunifuThinButton21.Size = new System.Drawing.Size(202, 91);
//    this.bunifuThinButton21.TabIndex = 0;
//    this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
#endregion