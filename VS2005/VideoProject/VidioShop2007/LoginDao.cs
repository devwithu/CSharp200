using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VidioShop2007
{
    public class LoginDao
    {
        public bool Login(string id, string passwd)
        {
            int count=0;

            using(SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {                
                using(SqlCommand selComm = new SqlCommand(QueryHelper.LOGINSQL, conn))
                {                    
                    selComm.Parameters.AddWithValue("@id", id.Trim());
                    selComm.Parameters.AddWithValue("@passwd", passwd.Trim());

                    if(conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = (int)selComm.ExecuteScalar();
                }
            }
            return count > 0 ? true : false;
        }        
    }
}
