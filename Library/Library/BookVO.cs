using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class SaveBookVO
    {
        private string id;
        private string name;
        private string publisher;
        private string author;
        private string price;
        private string quantity;
        
        public SaveBookVO()
        {

        }
        
        public SaveBookVO(string id, string name, string publisher, string author, string price, string quantity)
        {
            this.id = id;
            this.name = name;
            this.publisher = publisher;
            this.author = author;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
