using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VidioShop2007
{
    public class MFFDao
    {   
        public DataSet GetAllCustomer()
        {
            DataSet ds = new DataSet();
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                SqlDataAdapter sda = new SqlDataAdapter(QueryHelper.MFFGETALLSQL, conn);
                sda.Fill(ds, "GetAllCustomer");
            }

            return ds;
        }

        public DataSet GetCusIdCustomer(string memno)
        {
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand comm = new SqlCommand(QueryHelper.MFFGETCUSIDSQL, conn))
                {
                    comm.Parameters.AddWithValue("@memno", memno.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = comm;
                    sda.Fill(ds, "GetAllCustomer");
                }
            }
            return ds;
        }

        public bool InsertCustomer(string jumin, string cusname, string addr, string phone)
        {
            //bool isl = isExist(cusid);

            //if (isl)
            //{
            //    throw new FoundException(cusid + "가 이미 있습니다.");
            //}

            int count = 0;
           
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand inComm = new SqlCommand(QueryHelper.MFFINSERTSQL, conn))
                {  
                    inComm.Parameters.AddWithValue("@jumin", jumin.Trim());
                    inComm.Parameters.AddWithValue("@cusname", cusname.Trim());
                    inComm.Parameters.AddWithValue("@addr", addr.Trim());
                    inComm.Parameters.AddWithValue("@phone", phone.Trim());

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = inComm.ExecuteNonQuery();
                }
            }

            return count > 0 ? true : false;
        }

        public bool UpdateCustomer(string cusid, string jumin, string cusname, string addr, string phone, string point)
        {
            //bool isl = isExist(cusid);

            //if (!isl)
            //{
            //    throw new FoundException(cusid + "고객은 등록되어있지 않습니다");
            //}
                        
            int count = 0;

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand upComm = new SqlCommand(QueryHelper.MFFUPDATESQL, conn))
                {
                    upComm.Parameters.AddWithValue("@cusid", cusid.Trim());
                    upComm.Parameters.AddWithValue("@jumin", jumin.Trim());
                    upComm.Parameters.AddWithValue("@cusname", cusname.Trim());
                    upComm.Parameters.AddWithValue("@addr", addr.Trim());
                    upComm.Parameters.AddWithValue("@phone", phone.Trim());
                    upComm.Parameters.AddWithValue("@point", point.Trim());

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = upComm.ExecuteNonQuery();
                }
            }

            return count > 0 ? true : false;
        }

        public bool DeleteCustomer(string mem_no)
        {
            bool isl = isExistLendVideo(mem_no);

            if (isl)
            {
                throw new FoundException(mem_no + "고객이 대여한 비디오가 있습니다");
            }

            int count = 0;

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand delComm = new SqlCommand(QueryHelper.MFFDELETESQL, conn))
                {
                    delComm.Parameters.AddWithValue("@cusid", mem_no.Trim());

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = delComm.ExecuteNonQuery();
                }
            }

            return count > 0 ? true : false;
        }

        public DataSet FindCustomer(string memid, string memname)
        {
            //bool isl = isExistNOName(memid, memname);

            //if (!isl)
            //{
            //    throw new NotFoundException("찾는고객이 없습니다");
            //}

            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand comm = new SqlCommand(QueryHelper.MFFFINDSQL, conn))
                {
                    comm.Parameters.AddWithValue("@memid", memid.Trim());
                    comm.Parameters.AddWithValue("@memname", memname.Trim());

                    SqlDataAdapter sda = new SqlDataAdapter();

                    sda.SelectCommand = comm;
                    sda.Fill(ds, "GetAllCustomer");
                }
            }
            return ds;
        }

        //****************************예외처리 부분*********************************
        public bool isExistLendVideo(string mem_no)
        {
            int count = 0;

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selComm = new SqlCommand(QueryHelper.MFFLENDVIDEOSQL, conn))
                {
                    selComm.Parameters.AddWithValue("@mem_no", mem_no.Trim());

                    if (conn.State == ConnectionState.Closed)
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
