using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class ApiBookDTO
    {
        private string title;
        private string price;
        private string author;
        private string publisher;
        private string pubdate;
        private string isbn;

        public ApiBookDTO(string title, string price, string author, string publisher, string pubdate, string isbn)
        {
            this.title = title;
            this.publisher = publisher;
            this.author = author;
            this.price = price;
            this.pubdate = pubdate;
            this.isbn = isbn;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Pubdate
        {
            get { return pubdate; }
            set { pubdate = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
    }
}
