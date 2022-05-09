package Controller;
import java.io.*;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.util.HashMap;
import java.util.Map;

public class KakaoAPI {
	public void kakak_API_search_web(String type, String query)
	{
	    /////////////GET 방식
	    String sss = "query=" + query; // 보낼 데이터를 xml 형식으로 만들어주고
	    String url = String.Empty;
	    switch (type)
	    {
	        case "image":
	            //이미지검색
	            url = "https://dapi.kakao.com/v2/search/image?" + sss;
	            break;
	        
	    }
	            
	    string rest_api_key = "eebe73a9a75343e52c3201927c69fce3"; // 내 어플리케이션 => 어플선택 => 기본정보의 앱 키 > REST Key 값 부여            

	    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url); // 해당 URL로 네트웍을 만든다
	    request.Headers.Add("Authorization", "KakaoAK " + rest_api_key); // 헤더에 옵션값을 추가한다.
	    request.ContentType = "application/x-www-form-urlencoded";// 콘텐츠타입을 명시한다
	    request.Method = "GET"; // get 으로 보낼지 post로 보낼지 명시한다.

	    string responseText = string.Empty;
	    using (WebResponse response = request.GetResponse()) // 보낸데이터를 기반으로 받는다
	    {
	        Stream stream = response.GetResponseStream(); // 받은 데이터를 스트림으로 쓴다
	        using (StreamReader sr = new StreamReader(stream)) // 스트림을 읽기 위해 리더를 오픈한다.
	        {
	            responseText = sr.ReadToEnd(); // 스트림의 내용을 읽어서 문자열로 반환해준다.
	        }

	        Console.WriteLine(responseText); // 내용을 로그로 출력한다.
	    }
	}
}
