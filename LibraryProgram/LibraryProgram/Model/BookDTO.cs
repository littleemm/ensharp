using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class BookDTO
    {
        private string id;
        private string name;
        private string publisher;
        private string author;
        private string price;
        private string pubdate;
        private string isbn;
        private string quantity;

        public BookDTO(string id, string name, string publisher, string author, string price, string pubdate, string isbn, string quantity)
        {
            this.id = id;
            this.name = name;
            this.publisher = publisher;
            this.author = author;
            this.price = price;
            this.pubdate = pubdate;
            this.isbn = isbn;
            this.quantity = quantity;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
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

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}
