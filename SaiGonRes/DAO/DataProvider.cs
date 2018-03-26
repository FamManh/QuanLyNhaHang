using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaiGonRes.DAO
{
    public class DataProvider
    {
        private static DataProvider _Instance;
        public static DataProvider Instance
        { get
            {
                if (_Instance == null)
                {
                    _Instance = new DataProvider();
                    
                }
                return _Instance;
            }
            private set => _Instance = value;
        }
        DataProvider() { }
        string conStr = @"Data Source=DESKTOP-RRVICEQ;Initial Catalog=QuanLyRes;Integrated Security=True";

        

        public DataTable FExecuteQuery(string query, object[] parameter = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                if (parameter != null)
                {
                    string[] lisPara = query.Split(' ');
                    int i = 0;
                    foreach (string  item in lisPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                //cmd.Parameters.AddWithValue("@userName", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            return dt;
        }
        /// <summary>
        /// Trả ra số dòng thành công
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int FExecuteNoneQuery(string query, object[] parameter = null)
        {
            int dt = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                if (parameter != null)
                {
                    string[] lisPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                dt = cmd.ExecuteNonQuery();

                con.Close();
            }
            return dt;
        }
        /// <summary>
        /// Trả ra số lượng. phù hợp cho selecr count*
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public object FExecuteScalar(string query, object[] parameter = null)
        {
            object dt = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                if (parameter != null)
                {
                    string[] lisPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in lisPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                dt = cmd.ExecuteScalar();

                con.Close();
            }
            return dt;
        }
    }
}
