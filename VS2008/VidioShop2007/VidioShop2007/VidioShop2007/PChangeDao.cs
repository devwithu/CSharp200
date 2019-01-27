using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VidioShop2007
{
    public class PChangeDao
    {   
        public bool CheckNowPassword(string passwd)
        {
            int count = 0;
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selcomm = new SqlCommand(QueryHelper.PCFNOWSQL, conn))
                {
                    selcomm.Parameters.AddWithValue("@passwd", passwd.Trim());

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = (int)selcomm.ExecuteScalar();
                }
            }
            return count > 0 ? true : false;
        }

        public bool UpdatePassWord(string nowpasswd, string changepwd)
        {
            int count = 0;
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand upcomm = new SqlCommand(QueryHelper.PCFUPDATEPASSSQL, conn))
                {
                    upcomm.Parameters.AddWithValue("@changepwd", changepwd.Trim());
                    upcomm.Parameters.AddWithValue("@nowpasswd", nowpasswd.Trim());

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = upcomm.ExecuteNonQuery();
                }
            }
            return count > 0 ? true : false;
        }
    }
}

