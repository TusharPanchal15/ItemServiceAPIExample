using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ItemRequest
    {
        public string ItemName { get; set; }

        public string TemplateID { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}