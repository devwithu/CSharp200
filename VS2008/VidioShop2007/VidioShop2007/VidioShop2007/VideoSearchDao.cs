using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace VidioShop2007
{
    public class VideoSearchDao
    {
        public DataSet GetAllVideo() //비디오 정보 보여주기
        {
            DataSet ds = new DataSet();
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                SqlDataAdapter sda = new SqlDataAdapter(QueryHelper.VSDGETALLSQL, conn);
                sda.Fill(ds, "GetAllVideo");
            }
            return ds;
        }//


        public DataSet GetVideo(string video_no)
        {

            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                SqlCommand selcomm = new SqlCommand(QueryHelper.VSDGETVIDEOSQL, conn);
                selcomm.Parameters.AddWithValue("@video_no", video_no.Trim());
               

                SqlDataAdapter sda = new SqlDataAdapter();

                sda.SelectCommand = selcomm;

                sda.Fill(ds, "GetVideo");
            }
            return ds;
        }//

        public DataSet GetVideoS(string video_no, string video_name)//비디오 번호에 따른 검색
        {
            DataSet ds = new DataSet();
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                SqlCommand selcomm = new SqlCommand(QueryHelper.VSDGETVIDEOSQL2, conn);
                selcomm.Parameters.AddWithValue("@video_no", video_no.Trim());
                selcomm.Parameters.AddWithValue("@video_name", video_name.Trim());

                SqlDataAdapter sda = new SqlDataAdapter();

                sda.SelectCommand = selcomm;

                sda.Fill(ds, "GetVideoS");
            }
            return ds;
        }//
        
        public bool UpdateVideo(string video_no, string video_name, string video_act, string video_direct, string video_age,string video_class,string video_cost)//비디오 정보 수정하기
        {   
            int count = 0;
            
            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selcomm = new SqlCommand(QueryHelper.VSDUPDATESQL, conn))
                {
                    selcomm.Parameters.AddWithValue("@video_name", video_name.Trim());
                    selcomm.Parameters.AddWithValue("@video_act", video_act.Trim());
                    selcomm.Parameters.AddWithValue("@video_direct", video_direct.Trim());
                    selcomm.Parameters.AddWithValue("@video_age", video_age.Trim());
                    selcomm.Parameters.AddWithValue("@video_class", video_class.Trim());
                    selcomm.Parameters.AddWithValue("@video_cost", video_cost.Trim());
                    selcomm.Parameters.AddWithValue("@video_no", video_no.Trim());

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    count = selcomm.ExecuteNonQuery();
                }
            }
            return count > 0 ? true : false;
        }//

        public bool InsertViedo(string video_name, string video_act, string video_direct, string video_age, string video_class, string video_cost)            
        {//비디오 정보 입력하기
            int count = 0;

            using (SqlConnection conn = new SqlConnection(QueryHelper.CONNSTR))
            {
                using (SqlCommand selcomm = new SqlCommand(QueryHelper.VSDINSERTSQL, conn))
                {
                    selcomm.Parameters.AddWithValue("@video_name", video_name.Trim());
                    selcomm.Parameters.AddWithValue("@video_act", video_act.Trim());
                    selcomm.Parameters.AddWithValue("@video_direct", video_direct.Trim());
                    selcomm.Parameters.AddWithValue("@video_age", video_age.Trim());
                    selcomm.Parameters.AddWithValue("@video_class", video_class.Trim());
                    selcomm.Parameters.AddWithValue("@video_cost", video_cost.Trim());
                   
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    count = selcomm.ExecuteNonQuery();
                }
            }

            return count > 0 ? true : false;
        }
    }
}
