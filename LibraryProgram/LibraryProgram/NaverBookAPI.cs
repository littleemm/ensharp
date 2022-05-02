using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace LibraryProgram
{
    class NaverBookAPI
    {
        private static string CLIENT_ID = "Gy_693vcZVxD7SqwKVzr";
        private static string CLIENT_SECRET = "SdGR7yh_9b";

        private ApiBookVO apiBookVO;

        public NaverBookAPI()
        {
            apiBookVO = new ApiBookVO("", "", "", "", "", "");
        }

        public void SearchNaverAPI()
        {
            OpenAPI();
            FindBook();
            EditResultData();
        }

        private string OpenAPI()
        {
            string requestResult = "";
            string query = "노인과 바다"; // 검색할 문자열
            string url = "https://openapi.naver.com/v1/search/book?query=" + query; // 결과가 JSON 포맷
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", CLIENT_ID); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", CLIENT_SECRET);       // 클라이언트 시크릿

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();
            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                requestResult = reader.ReadToEnd();
            }
            // else
            //     Console.WriteLine("Error 발생=" + status);
            //return "ERROR";
            return requestResult;
        }

        public List<ApiBookVO> FindBook()
        {
            string requestResult = OpenAPI();
           

            var parseJson = JObject.Parse(requestResult);

            //var QueryResultCount = Convert.ToInt32(parseJson["display"]);
            //var TotalResultCount = Convert.ToInt32(parseJson["total"]);

            List<ApiBookVO> bookList = JsonConvert.DeserializeObject<List<ApiBookVO>>(parseJson["items"].ToString());

            return bookList;
        }

        private void EditResultData()
        {
            List<ApiBookVO> bookList = FindBook();

            Console.WriteLine("===========================================================");
            foreach (ApiBookVO book in bookList)
            {
                book.Title = book.Title.Replace("<b>", "");
                book.Title = book.Title.Replace("</b>", "");
                Console.WriteLine("   TITLE   : " + book.Title);
                Console.WriteLine("  AUTHOR   : " + book.Author);
                Console.WriteLine(" PUBLISHER : " + book.Publisher);
                Console.WriteLine("   PRICE   : " + book.Price + "\\");
                Console.WriteLine("  PUBDATE  : " + book.Pubdate);
                Console.WriteLine("   ISBN    : " + book.Isbn);
                Console.WriteLine("===========================================================");
            }
        }
    }
}
