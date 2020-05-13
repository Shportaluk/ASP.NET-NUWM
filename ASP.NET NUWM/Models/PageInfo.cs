using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_NUWM.Models
{
    public class PageInfo
    {
        public string id;
        public string category;
        public string title;
        public string descriprion;
        public string urlImg;

        public PageInfo()
        {

        }
        public PageInfo(string id, string category, string title, string descriprion, string urlImg)
        {
            this.id = id;
            this.category = category;
            this.title = title;
            this.descriprion = descriprion;
            this.urlImg = urlImg;
        }
    }
}