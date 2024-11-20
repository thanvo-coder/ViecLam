
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WebUI.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public IList<T> Items { get; set; }
        public int PageSizeOption { get; set; }
        public string ValueName { get; set; }
        public int Category { get; set; }
        public string StarDateAndEndDate { get; set; }
        public string Language { get; set; }
      
        public PagedResult()
        {
            Items = new List<T>();


        }

    }
}