using BlazorDemo.Components.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Client.Models
{
    [DisplayRazorTable(TableClass = "table table-bordered table-hover table-sm")]
    //[Style(Color = "green")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public string ShowFull => $"{CategoryName} -\t({Description})";
    }
}
