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
            request.Headers.Add("X-Naver-Client-Id", Constant.CLIENT_ID); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", Constant.CLIENT_SECRET);       // 클라이언트 시크릿

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

        public List<ApiBookDTO> FindBook(string title, string display)
        { // API에서의 데이터를 LIST에 넣는 과정
            string requestResult = OpenAPI(title, display);
           
            JObject parseJson = JObject.Parse(requestResult);

            List<ApiBookDTO> bookList = JsonConvert.DeserializeObject<List<ApiBookDTO>>(parseJson["items"].ToString());

            return bookList;
        }

        private void EditResultData(string title, string display)
        { // 검색한 것 중 추려서 출력해야하는데, 이때 쓸모없는 것들도 없애야함
            List<ApiBookDTO> bookList = FindBook(title, display);

            Console.WriteLine("==================================================================================================================================");

            foreach (ApiBookDTO book in bookList)
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
            List<ApiBookDTO> bookList = FindBook(title, display);
    
            foreach (ApiBookDTO book in bookList)
            {
                if (isbn == book.Isbn.Substring(11))
                {
                    return true;
                }
            }
            return false;
        }

        public BookDTO GetBookDTO(string title, string display, string isbn) 
        {
            BookDTO bookDTO = new BookDTO("", "", "", "", "" , "", "", "");
            List<ApiBookDTO> bookList = FindBook(title, display);
            foreach (ApiBookDTO book in bookList)
            {
                if (isbn == book.Isbn.Substring(11))
                {
                    book.Title = book.Title.Replace("<b>", "");
                    book.Title = book.Title.Replace("</b>", "");
                    book.Author = book.Author.Replace("<b>", "");
                    book.Author = book.Author.Replace("</b>", "");
                    bookDTO.Name = book.Title;
                    bookDTO.Price = book.Price;
                    bookDTO.Publisher = book.Publisher;
                    bookDTO.Author = book.Author;
                    bookDTO.Pubdate = book.Pubdate;
                    bookDTO.Isbn = book.Isbn.Substring(11);
                }
            }

            return bookDTO;
        }
    }
}
