using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VidioShop2007
{
    public class VLendDao
    {
        //���� �˻�
        public DataSet GetFindVideo(string video_no) 
        {
            bool isl = NOisExistVideo(video_no);
            if (!isl)
            {
                throw new NotFoundException(video_no + "���� ������ ��ϵǾ����� �ʽ��ϴ�");
            }

            DataSet ds = new DataSet();            
            
            using(SqlConnection conn=new SqlConnection(QueryHelper.CONNSTR))
            {
                using(SqlCommand selcomm=new SqlCommand(QueryHelper.VLFGETFINDSQL,conn))
                {
                    selcomm.Parameters.AddWithValue("@video_no", video_no.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = selcomm;
                    sda.Fill(ds,"GetFindVideo");
                }
            }

            return ds;
        }//

        //���̸����� �˻�
        public bool GetFindMember(string mem_no)
        {
            int count = 0;
            bool isl = NOisExist(mem_no);

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selcomm = new SqlCommand(QueryHelper.VLFGETFINDMEMBERSQL, conn))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    selcomm.Parameters.AddWithValue("@mem_no", mem_no.Trim());
                    count = (int)selcomm.ExecuteScalar();
                }
            }

            return count > 0 ? true : false;
        }

        //�뿩�� ���� ȸ������ �˻�
        public bool GetFindLendMember(string mem_no)
        {
            int count = 0;
            bool isl = NOisExist(mem_no);

            if (!isl)
            {
                throw new NotFoundException(mem_no + "ȸ���� �����ϴ�");
            }

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selcomm = new SqlCommand(QueryHelper.VLFFINDLENDMEMBERSQL, conn))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    selcomm.Parameters.AddWithValue("@mem_no", mem_no.Trim());
                    count = (int)selcomm.ExecuteScalar();
                }
            }

            return count > 0 ? true : false;
        }

        //��ϵ� ���� �뿩�� ������ �ִ��� �˻�
        public DataSet GetFindLendMember2(string mem_no)
        {
            bool isl = NOisExist(mem_no);
            if (!isl)
            {
                throw new NotFoundException(mem_no + "ȸ���� �����ϴ�");
            }

            DataSet ds = new DataSet();
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selcomm = new SqlCommand(QueryHelper.VLFFINDLENDMEMBERSQL2, conn))
                {
                    selcomm.Parameters.AddWithValue("@mem_no", mem_no.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = selcomm;
                    sda.Fill(ds, "GetFindVideo");
                }
            }

            return ds;
        }//

        //���ݰ����� ����Ʈ���
        //�뿩�κ��Է�
        public bool PointUseInsertLend(string video_no, string mem_no, DateTime lend_date, DateTime return_date, int pay_amount, int point, string pay_way)
        {
            int count = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
        
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand inComm = new SqlCommand(QueryHelper.VLFPOINTUSEINSERTLENDSQL, conn))
                {
                    inComm.Parameters.AddWithValue("@video_no", video_no.Trim());
                    inComm.Parameters.AddWithValue("@mem_no", mem_no.Trim());
                    inComm.Parameters.AddWithValue("@lend_date", lend_date);
                    inComm.Parameters.AddWithValue("@return_date", return_date);
                    inComm.Parameters.AddWithValue("@pay_amount", pay_amount);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = inComm.ExecuteNonQuery();
                }
                using (SqlCommand upComm = new SqlCommand(QueryHelper.VLFPOINTUSEINSERTLENDSQL2, conn))
                {
                    upComm.Parameters.AddWithValue("@point", point);
                    upComm.Parameters.AddWithValue("@mem_no", mem_no.Trim());                    

                    count2 = upComm.ExecuteNonQuery();
                }
                using (SqlCommand inComm2 = new SqlCommand(QueryHelper.VLFPOINTUSEINSERTLENDSQL3, conn))
                {
                    inComm2.Parameters.AddWithValue("@lend_date", lend_date);
                    count3 = inComm2.ExecuteNonQuery();
                }
                using (SqlCommand inComm3 = new SqlCommand(QueryHelper.VLFPOINTUSEINSERTLENDSQL4, conn))
                {
                    inComm3.Parameters.AddWithValue("@pay_way", pay_way);
                    inComm3.Parameters.AddWithValue("@pay_amount", pay_amount);
                    count4 = inComm3.ExecuteNonQuery();
                }
            }

            return count > 0 && count2 > 0 && count3 > 0 && count4 > 0 ? true : false;
        }

        //���ݰ����� ����Ʈ��� ����
        //�뿩�κ��Է�
        public bool NoPointInsertLend(string video_no, string mem_no, DateTime lend_date, DateTime return_date, int pay_amount, int point, string pay_way)
        {
            int count = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int totalPoint = 0;

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand inComm = new SqlCommand(QueryHelper.NoPointInsertLend, conn))
                {
                    inComm.Parameters.AddWithValue("@video_no", video_no.Trim());
                    inComm.Parameters.AddWithValue("@mem_no", mem_no.Trim());
                    inComm.Parameters.AddWithValue("@lend_date", lend_date);
                    inComm.Parameters.AddWithValue("@return_date", return_date);
                    inComm.Parameters.AddWithValue("@pay_amount", pay_amount);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = inComm.ExecuteNonQuery();
                }

                using (SqlCommand selComm = new SqlCommand(QueryHelper.NoPointInsertLend2, conn))
                {
                    selComm.Parameters.AddWithValue("@point", point);
                    selComm.Parameters.AddWithValue("@mem_no", mem_no.Trim());

                    SqlDataReader sr = selComm.ExecuteReader();
                    while (sr.Read())
                    {
                        totalPoint = int.Parse(sr["mem_point"].ToString());
                    }
                    sr.Close();
                }

                using (SqlCommand upComm = new SqlCommand(QueryHelper.NoPointInsertLend3, conn))
                {
                    int p = totalPoint + point;
                    upComm.Parameters.AddWithValue("@point", p);
                    upComm.Parameters.AddWithValue("@mem_no", mem_no.Trim());

                    count2 = upComm.ExecuteNonQuery();
                }
                using (SqlCommand inComm2 = new SqlCommand(QueryHelper.NoPointInsertLend4, conn))
                {
                    inComm2.Parameters.AddWithValue("@lend_date", lend_date);
                    count3 = inComm2.ExecuteNonQuery();
                }
                using (SqlCommand inComm3 = new SqlCommand(QueryHelper.NoPointInsertLend5, conn))
                {
                    inComm3.Parameters.AddWithValue("@pay_way", pay_way);
                    inComm3.Parameters.AddWithValue("@pay_amount", pay_amount);
                    count4 = inComm3.ExecuteNonQuery();
                }
            }

            return count > 0 && count2 > 0 && count3 > 0 && count4 > 0 ? true : false;
        }

        //ī��� ������
        public bool UseCardInsertLend(string video_no, string mem_no, DateTime lend_date, DateTime return_date, int pay_amount, string pay_way)
        {
            int count = 0;            
            int count3 = 0;
            int count4 = 0;
          
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand inComm = new SqlCommand(QueryHelper.UseCardInsertLend, conn))
                {
                    inComm.Parameters.AddWithValue("@video_no", video_no.Trim());
                    inComm.Parameters.AddWithValue("@mem_no", mem_no.Trim());
                    inComm.Parameters.AddWithValue("@lend_date", lend_date);
                    inComm.Parameters.AddWithValue("@return_date", return_date);
                    inComm.Parameters.AddWithValue("@pay_amount", pay_amount);

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = inComm.ExecuteNonQuery();
                }
                                
                using (SqlCommand inComm2 = new SqlCommand(QueryHelper.UseCardInsertLend2, conn))
                {
                    inComm2.Parameters.AddWithValue("@lend_date", lend_date);
                    count3 = inComm2.ExecuteNonQuery();
                }
                using (SqlCommand inComm3 = new SqlCommand(QueryHelper.UseCardInsertLend3, conn))
                {
                    inComm3.Parameters.AddWithValue("@pay_way", pay_way);
                    inComm3.Parameters.AddWithValue("@pay_amount", pay_amount);
                    count4 = inComm3.ExecuteNonQuery();
                }
            }

            return count > 0 && count3 > 0 && count4 > 0 ? true : false;
        }//

        //�ݳ��� ������ ��Ͽ� �ִ��� �˻�
        public DataSet ReturnLendVideoSearch(string mem_no)
        {
            bool isl = NOisExistLendVideo(mem_no);

            if (!isl)
            {
                throw new NotFoundException(mem_no + "���� �뿩�� ������ �����ϴ�");
            }

            DataSet ds = new DataSet();
           
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selcomm = new SqlCommand(QueryHelper.ReturnLendVideoSearch, conn))
                {
                    selcomm.Parameters.AddWithValue("@mem_no", mem_no.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = selcomm;
                    sda.Fill(ds, "GetFindVideo");
                }
            }

            return ds;
        }//

        //���� �ݳ�
        public bool ReturnVideo(string video_no, string mem_no)
        {
            int count = 0;
     
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand delComm = new SqlCommand(QueryHelper.ReturnVideo, conn))
                {
                    delComm.Parameters.AddWithValue("@mem_no", mem_no.Trim());
                    delComm.Parameters.AddWithValue("@video_no", video_no.Trim());

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = delComm.ExecuteNonQuery();
                }
            }
            return count > 0 ? true : false;
        }

        public DataSet GetAllLendVideo()
        {
            DataSet ds = new DataSet();
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {                    
                SqlDataAdapter sda = new SqlDataAdapter(QueryHelper.GetAllLendVideo, conn);                
                sda.Fill(ds, "GetAllLendVideo");
            }

            return ds;
        }

        //��ϰ����� �� �� ���
        public bool InsertCustomer(string jumin, string cusname, string addr, string phone)
        {            
            int count = 0;

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand inComm = new SqlCommand(QueryHelper.InsertCustomer, conn))
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

        //������ ������ �׸��� ���� ���� ����� �������� ����
        public DataSet getPaywayPayAmount(string lend_no)
        {
            DataSet ds = new DataSet();
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selcomm = new SqlCommand(QueryHelper.getPaywayPayAmount, conn))
                {
                    selcomm.Parameters.AddWithValue("@lend_no", lend_no.Trim());
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = selcomm;
                    sda.Fill(ds, "GetFindVideo");
                }
            }
            return ds;
        }

        //=======================================����ó��==========================================
        //=========================================================================================
        public bool NOisExist(string mem_no)
        {
            int count=0;
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selComm = new SqlCommand(QueryHelper.NOisExist, conn))
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

        public bool NOisExistVideo(string video_no)
        {
            int count = 0;
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selComm = new SqlCommand(QueryHelper.NOisExistVideo, conn))
                {
                    selComm.Parameters.AddWithValue("@video_no", video_no.Trim());

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = (int)selComm.ExecuteScalar();
                }
            }
            return count > 0 ? true : false;
        }

        public bool NOisExistLendVideo(string mem_no)
        {
            int count = 0;
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selComm = new SqlCommand(QueryHelper.NOisExistLendVideo, conn))
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
