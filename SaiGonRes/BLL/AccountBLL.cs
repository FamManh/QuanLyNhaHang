using SaiGonRes.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiGonRes.BLL
{
    public class AccountBLL
    {
        static AccountBLL _Instance;

        public static AccountBLL Instance
        {
            get { if (_Instance == null) _Instance = new AccountBLL(); return _Instance; } 
            private set => _Instance = value;
        }
        public bool Login(string userName, string password)
        {
            string query = "USP_Login @userName , @password";
            DataTable  result = DataProvider.Instance.FExecuteQuery(query, new object[] {userName, password });

            return result.Rows.Count >0;
        }
    }
}
