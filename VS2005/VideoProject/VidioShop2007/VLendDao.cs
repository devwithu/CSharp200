using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VidioShop2007
{
    public class VLendDao
    {
        //비디오 검색
        public DataSet GetFindVideo(string video_no) 
        {
            bool isl = NOisExistVideo(video_no);
            if (!isl)
            {
                throw new NotFoundException(video_no + "번의 비디오는 등록되어있지 않습니다");
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

        //고객이름으로 검색
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

        //대여할 고객이 회원인지 검사
        public bool GetFindLendMember(string mem_no)
        {
            int count = 0;
            bool isl = NOisExist(mem_no);

            if (!isl)
            {
                throw new NotFoundException(mem_no + "회원이 없습니다");
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

        //등록된 고객이 대여한 비디오가 있는지 검사
        public DataSet GetFindLendMember2(string mem_no)
        {
            bool isl = NOisExist(mem_no);
            if (!isl)
            {
                throw new NotFoundException(mem_no + "회원이 없습니다");
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

        //현금결제와 포인트사용
        //대여부분입력
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

        //현금결제와 포인트사용 안함
        //대여부분입력
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

        //카드로 결제시
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

        //반납시 빌려가 목록에 있는지 검사
        public DataSet ReturnLendVideoSearch(string mem_no)
        {
            bool isl = NOisExistLendVideo(mem_no);

            if (!isl)
            {
                throw new NotFoundException(mem_no + "님은 대여한 비디오가 없습니다");
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

        //비디오 반납
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

        //등록고객없을 시 고객 등록
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

        //선택한 데이터 그리드 고객의 결제 방법및 결제수단 선택
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

        //=======================================예외처리==========================================
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
