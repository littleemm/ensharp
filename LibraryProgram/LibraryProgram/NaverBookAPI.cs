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

        public NaverBookAPI()
        {
        }

        public void SearchNaverAPI(string title, string display)
        { // 검색하고 추리는 것이 담겨있는 함수 (-> 다른 클래스에서 참조될 함수)
            Console.SetWindowSize(130, 28);
            EditResultData(title, display);
        }

        private string OpenAPI(string title, string display)
        { // API에서 데이터 가져오기
            string requestResult = "";
            string url = "https://openapi.naver.com/v1/search/book?query=" + title + "&display=" + display; // 결과가 JSON 포맷
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

        public List<ApiBookVO> FindBook(string title, string display)
        { // API에서의 데이터를 LIST에 넣는 과정
            string requestResult = OpenAPI(title, display);
           
            var parseJson = JObject.Parse(requestResult);

            List<ApiBookVO> bookList = JsonConvert.DeserializeObject<List<ApiBookVO>>(parseJson["items"].ToString());

            return bookList;
        }

        private void EditResultData(string title, string display)
        { // 검색한 것 중 추려서 출력해야하는데, 이때 쓸모없는 것들도 없애야함
            List<ApiBookVO> bookList = FindBook(title, display);

            Console.WriteLine("==================================================================================================================================");

            foreach (ApiBookVO book in bookList)
            {
                book.Title = book.Title.Replace("<b>", "");
                book.Title = book.Title.Replace("</b>", "");
                book.Author = book.Author.Replace("<b>", "");
                book.Author = book.Author.Replace("</b>", "");
                Console.WriteLine("   TITLE   : " + book.Title);
                Console.WriteLine("  AUTHOR   : " + book.Author);
                Console.WriteLine(" PUBLISHER : " + book.Publisher);
                Console.WriteLine("   PRICE   : " + book.Price + "\\");
                Console.WriteLine("  PUBDATE  : " + book.Pubdate);
                Console.WriteLine("   ISBN    : " + book.Isbn.Substring(11));
                Console.WriteLine();
                Console.WriteLine("==================================================================================================================================");
            }
        }

        public bool IsIsbnData(string title, string display, string isbn)
        { // 데이터베이스(도서 목록)에 추가하기 위한 isbn 판별 함수
            List<ApiBookVO> bookList = FindBook(title, display);
    
            foreach (ApiBookVO book in bookList)
            {
                if (isbn == book.Isbn.Substring(11))
                {
                    return true;
                }
            }
            return false;
        }

        public BookVO SetBookVO(string title, string display, string isbn)
        {
            BookVO bookVO = new BookVO("", "", "", "", "" , "", "", "");
            List<ApiBookVO> bookList = FindBook(title, display);
            foreach (ApiBookVO book in bookList)
            {
                if (isbn == book.Isbn.Substring(11))
                {
                    book.Title = book.Title.Replace("<b>", "");
                    book.Title = book.Title.Replace("</b>", "");
                    book.Author = book.Author.Replace("<b>", "");
                    book.Author = book.Author.Replace("</b>", "");
                    bookVO.Name = book.Title;
                    bookVO.Price = book.Price;
                    bookVO.Publisher = book.Publisher;
                    bookVO.Author = book.Author;
                    bookVO.Pubdate = book.Pubdate;
                    bookVO.Isbn = book.Isbn.Substring(11);
                }
            }

            return bookVO;
        }
    }
}
