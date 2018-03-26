using SaiGonRes.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiGonRes.BLL
{
    public class LoginStaffBLL
    {
        LoginStaffBLL() { }
        static LoginStaffBLL _Instance;

        public static LoginStaffBLL Instance { get { if (_Instance == null) _Instance = new LoginStaffBLL();  return _Instance; } set => _Instance = value; }

        public bool IsStaff (string PinCode)
        {
            string query = "USP_LoginStaff @PinCode";
            DataTable result = DataProvider.Instance.FExecuteQuery(query, new object[] { PinCode });

            return result.Rows.Count > 0;
        }

    }
}
