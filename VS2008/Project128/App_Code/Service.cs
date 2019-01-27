using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://www.infopub.co.kr/Calculator/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //디자인된 구성 요소를 사용하는 경우 다음 줄의 주석 처리를 제거합니다. 
        //InitializeComponent(); 
    }

    [WebMethod]
    public double Calculator(double x, double y, string opp)
    {
        double z = 0.0;//사칙연산결과를 저장할 임수 변수
        //사칙연산이 어떤 것인가 판별
        switch (opp)
        {
            case "+": z = x + y; break;
            case "-": z = x - y; break;
            case "x": z = x * y; break;
            case "/": z = x / y; break;
        }
        return z;//사칙연산에 알맞은 값을 리턴한다.
    }//
    
}
