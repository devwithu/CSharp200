using System;
using System.Collections.Generic;
using System.Text;

namespace VidioShop2007
{
    public class QueryHelper
    {
        public readonly static string CONNSTR = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\videoshop.mdf;Integrated Security=True;User Instance=True";

        public readonly static string LOGINSQL = "select count(id) from admin where id=@id and passwd=@passwd";
        
        //========MemberFindForm SQL문===========================================================================
        //=======================================================================================================
        public readonly static string MFFLENDVIDEOSQL = "SELECT COUNT(MEM_NO) FROM LEND WHERE MEM_NO = @mem_no";

        public readonly static string MFFGETALLSQL = "SELECT MEM_NO, MEM_JUMIN, MEM_NAME, MEM_ADDRESS, MEM_PHONE, MEM_POINT FROM MEMBER ORDER BY MEM_NO";

        public readonly static string MFFGETCUSIDSQL = "SELECT MEM_NO, MEM_JUMIN, MEM_NAME, MEM_ADDRESS, MEM_PHONE, MEM_POINT FROM MEMBER WHERE MEM_NO = @memno";

        public readonly static string MFFINSERTSQL = "INSERT INTO MEMBER VALUES(@jumin, @cusname, @addr, @phone, 0)";

        public readonly static string MFFUPDATESQL = "UPDATE MEMBER SET mem_jumin = @jumin, mem_name = @cusname, mem_address = @addr, mem_phone = @phone, mem_point = @point where mem_no = @cusid";

        public readonly static string MFFDELETESQL = "DELETE FROM MEMBER WHERE mem_no = @cusid";

        public readonly static string MFFFINDSQL = "SELECT MEM_NO, MEM_JUMIN, MEM_NAME, MEM_ADDRESS, MEM_PHONE, MEM_POINT FROM MEMBER WHERE mem_no=@memid OR mem_name=@memname";
        
        //========PassChangeForm SQL문===========================================================================
        //=======================================================================================================
        public readonly static string PCFNOWSQL = "SELECT COUNT(PASSWD) FROM ADMIN WHERE PASSWD=@passwd";

        public readonly static string PCFUPDATEPASSSQL = "UPDATE ADMIN SET PASSWD=@changepwd WHERE PASSWD=@nowpasswd";

        //========VideoSerachForm SQL문===========================================================================
        //=======================================================================================================
        public readonly static string VSDGETALLSQL = "SELECT VIDEO_NO,VIDEO_NAME,VIDEO_ACT,VIDEO_DIRECT,VIDEO_AGE,VIDEO_CLASS,VIDEO_COST FROM VIDEO";
        
        public readonly static string VSDGETVIDEOSQL = "SELECT VIDEO_NO,VIDEO_NAME,VIDEO_ACT,VIDEO_DIRECT,VIDEO_AGE,VIDEO_CLASS,VIDEO_COST FROM VIDEO WHERE VIDEO_NO=@video_no";
        
        public readonly static string VSDGETVIDEOSQL2 = "SELECT VIDEO_NO,VIDEO_NAME,VIDEO_ACT,VIDEO_DIRECT,VIDEO_AGE,VIDEO_CLASS,VIDEO_COST FROM VIDEO WHERE VIDEO_NO=@video_no OR VIDEO_NAME=@video_name";
        
        public readonly static string VSDUPDATESQL = "UPDATE VIDEO SET VIDEO_NAME=@video_name,VIDEO_ACT=@video_act,VIDEO_DIRECT=@video_direct,VIDEO_AGE=@video_age,VIDEO_CLASS=@video_class,VIDEO_COST=@video_cost WHERE VIDEO_NO=@video_no";
        
        public readonly static string VSDINSERTSQL = "INSERT INTO VIDEO VALUES(@video_name, @video_act,@video_direct, @video_age,@video_class, @video_cost)";

        //========VideoLendForm SQL문===========================================================================
        //=======================================================================================================
        public readonly static string VLFGETFINDSQL = "SELECT VIDEO_NO, VIDEO_NAME, VIDEO_ACT, VIDEO_DIRECT, VIDEO_AGE, VIDEO_CLASS, VIDEO_COST FROM VIDEO WHERE VIDEO_NO=@video_no";

        public readonly static string VLFGETFINDMEMBERSQL = "SELECT COUNT(MEM_NO) FROM MEMBER WHERE MEM_NO=@mem_no";

        public readonly static string VLFFINDLENDMEMBERSQL = "SELECT COUNT(MEM_NO) FROM LEND WHERE MEM_NO=@mem_no";

        public readonly static string VLFFINDLENDMEMBERSQL2 = "select l.video_no, video_name, DATENAME(yyyy,lend_date) +'-'+ DATENAME(mm,lend_date) +'-'+ DATENAME(dd,lend_date) as lend_date, DATENAME(yyyy,return_date) +'-'+ DATENAME(mm,return_date) +'-'+ DATENAME(dd,return_date) as return_date, mem_point from lend l JOIN video v ON l.video_no = v.video_no JOIN member m ON l.mem_no = m.mem_no where l.mem_no = @mem_no";

        public readonly static string VLFPOINTUSEINSERTLENDSQL = "INSERT INTO LEND VALUES(@video_no, @mem_no, @lend_date, @return_date, @pay_amount)";

        public readonly static string VLFPOINTUSEINSERTLENDSQL2 = "UPDATE MEMBER SET MEM_POINT=@point WHERE MEM_NO=@mem_no";

        public readonly static string VLFPOINTUSEINSERTLENDSQL3 = "INSERT INTO PAY VALUES(@lend_date)";

        public readonly static string VLFPOINTUSEINSERTLENDSQL4 = "INSERT INTO PAY_DETAIL VALUES(@pay_way, @pay_amount)";

        public readonly static string NoPointInsertLend = "INSERT INTO LEND VALUES(@video_no, @mem_no, @lend_date, @return_date, @pay_amount)";

        public readonly static string NoPointInsertLend2 = "SELECT MEM_POINT FROM MEMBER WHERE MEM_NO=@mem_no";

        public readonly static string NoPointInsertLend3 = "UPDATE MEMBER SET MEM_POINT=@point WHERE MEM_NO=@mem_no";

        public readonly static string NoPointInsertLend4 = "INSERT INTO PAY VALUES(@lend_date)";

        public readonly static string NoPointInsertLend5 = "INSERT INTO PAY_DETAIL VALUES(@pay_way, @pay_amount)";

        public readonly static string UseCardInsertLend = "INSERT INTO LEND VALUES(@video_no, @mem_no, @lend_date, @return_date, @pay_amount)";

        public readonly static string UseCardInsertLend2 = "INSERT INTO PAY VALUES(@lend_date)";

        public readonly static string UseCardInsertLend3 = "INSERT INTO PAY_DETAIL VALUES(@pay_way, @pay_amount)";

        public readonly static string ReturnLendVideoSearch = "SELECT V.VIDEO_NO, V.VIDEO_NAME, V.VIDEO_ACT, V.VIDEO_DIRECT, V.VIDEO_AGE, V.VIDEO_CLASS, V.VIDEO_COST, L.LEND_DATE, L.RETURN_DATE FROM VIDEO V JOIN LEND L ON V.VIDEO_NO = L.VIDEO_NO JOIN MEMBER M ON L.MEM_NO = M.MEM_NO WHERE M.MEM_NO = @mem_no";

        public readonly static string ReturnVideo = "DELETE LEND WHERE VIDEO_NO=@video_no AND MEM_NO=@mem_no";

        public readonly static string GetAllLendVideo = "SELECT lend_no as '대여번호', video_no as '비디오번호', mem_no as '고객번호', DATENAME(yyyy,lend_date) +'-'+ DATENAME(mm,lend_date) +'-'+ DATENAME(dd,lend_date) as '대여일자', DATENAME(yyyy,return_date) +'-'+ DATENAME(mm,return_date) +'-'+ DATENAME(dd,return_date) as '반납일자', pay_amount as '대여금액' FROM lend ORDER BY MEM_NO";

        public readonly static string InsertCustomer = "INSERT INTO MEMBER VALUES(@jumin, @cusname, @addr, @phone, 0)";

        public readonly static string getPaywayPayAmount = "SELECT PAY_WAY, PAY_AMOUNT FROM PAY_DETAIL WHERE LEND_NO=@lend_no";

        public readonly static string NOisExist = "SELECT COUNT(MEM_NO) FROM MEMBER WHERE MEM_NO = @mem_no";

        public readonly static string NOisExistVideo = "SELECT COUNT(VIDEO_NO) FROM VIDEO WHERE VIDEO_NO = @video_no";

        public readonly static string NOisExistLendVideo = "SELECT COUNT(mem_no) FROM LEND WHERE MEM_NO = @mem_no";
    }
}
