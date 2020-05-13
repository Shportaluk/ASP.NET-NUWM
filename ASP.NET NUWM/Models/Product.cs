using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_NUWM.Models
{
    public class Product
    {
        public string title;
        public int price;

        public Product()
        {

        }
        public Product(string title, int price)
        {
            this.title = title;
            this.price = price;
        }
    }
}