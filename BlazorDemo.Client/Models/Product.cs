using BlazorDemo.Components.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BlazorDemo.Client.Models
{
    
    public class Product
    {   
        [DisplayRazorTable(Header = "Id", HeaderClass = "text-center",
            ValueClass ="text-center")]
        public int ProductId { get; set; }

        [DisplayRazorTable(Header = "Nombre", HeaderClass = "text-center")]
        public string ProductName { get; set; }

        [DisplayRazorTable(Header ="Precio", HeaderClass = "text-right",
            ValueFormat = "{0:C2}", ValueClass = "text-right")]
        public decimal UnitPrice { get; set; }

        [DisplayRazorTable(Header = "Existencia", HeaderClass = "text-center",
            ValueClass = "text-right")]
        public int UnitsInStock { get; set; }

        [DisplayRazorTable(Header = "Categoria", HeaderClass = "text-center",
            ValueClass = "text-center")]
        public int CategoryID { get; set; }
    }
}
