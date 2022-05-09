package Controller;
import javax.swing.*;
import java.net.URL;
import java.net.URLEncoder;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.nio.charset.Charset;
import java.io.FileReader;
import org.json.simple.JSONObject;
import org.json.simple.JSONArray;
import org.json.simple.JSONParser;

public class KakaoAPI {
	
	private static String IMAGE_URL="http://dapi.kakao.com/v2/local/search/image?query={0}&size={1}"; 
	private static String USER_INFO="6d21e6a6177862f350927b8f4e691138"; 
	
	public String OpenAPI(String image, String display) {
		String result = "";
		URL url;
		
		try{ 
			String query = URLEncoder.encode(image, "UTF-8"); 
			String size = URLEncoder.encode(display, "UTF-8");
			url = new URL(String.format(IMAGE_URL, query, size)); 
			
			HttpURLConnection connection = (HttpURLConnection)url.openConnection(); 
			
			connection.setRequestMethod("GET"); connection.setRequestProperty("Authorization", USER_INFO); 
			connection.setRequestProperty("content-type", "application/json"); 
			connection.setDoOutput(true); 
			connection.setUseCaches(false); 
			connection.setDefaultUseCaches(false); 
			
			Charset charset = Charset.forName("UTF-8"); 
			BufferedReader in = new BufferedReader(new InputStreamReader(connection.getInputStream(), charset)); 
			
			String inputLine; 
			StringBuffer response = new StringBuffer(); 
			
			while ((inputLine = in.readLine()) != null) { 
				response.append(inputLine); 
			} 
			
			result = response.toString();
			} 
		
		catch (Exception e) {  
			e.printStackTrace(); } 
		
		return result;
		
	}
	
	private JList<ImageIcon> CreateImageMap(String image, String display) {
		String result = OpenAPI(image, display);
		
		Reader reader = new FileReader();
		JSONArray JsonArray = (JSONArray)object;
		
		
		JList<ImageIcon> imageList = new JList<ImageIcon>();
		imageList.setListData();

	
	}
}
