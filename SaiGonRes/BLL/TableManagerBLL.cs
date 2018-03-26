using SaiGonRes.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiGonRes.BLL
{
    public class TableManagerBLL
    {
        TableManagerBLL() { }
        static TableManagerBLL _Instance;

        public static TableManagerBLL Instance { get { if (_Instance == null) _Instance = new TableManagerBLL(); return _Instance; } set => _Instance = value; }

        public string GetNameStaff(string PinCode)
        {
            DataTable dt = new DataTable();
            string query = "USP_GetNameStaff @PinCode";
            dt = DataProvider.Instance.FExecuteQuery(query, new object[] { PinCode });
            string nameStaff = dt.Rows[0]["Name"].ToString();
            return nameStaff;

        }
    }
}
