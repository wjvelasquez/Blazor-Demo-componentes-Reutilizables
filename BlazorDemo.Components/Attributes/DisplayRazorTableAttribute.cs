using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Components.Attributes
{
    public class DisplayRazorTableAttribute : Attribute
    {
        public string TableClass { get; set; }
        public int MyProperty { get; set; }
        public string Header { get; set; }
        public string HeaderClass { get; set; }
        public string ValueFormat { get; set; }
        public string ValueClass { get; set; }          

    }
}
