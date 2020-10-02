using BlazorDemo.Components.Attributes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace BlazorDemo.Components
{
    partial class Table<T>
    {
        [Parameter]
        public IEnumerable<T> Items { get; set; }
        [Parameter]
        public RenderFragment Head { get; set; }
        [Parameter]
        public RenderFragment<T> Body { get; set; }

        [Parameter]
        public RenderFragment NullItems { get; set; }

        [Parameter]
        public RenderFragment EmptyItems { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }
        

        MarkupString _defaultHead;
        MarkupString _defaultBody;
        private readonly string _defaultCSSClass =
            "table table-bordered table-striped table-hover table-sm";

        protected override void OnParametersSet()
        {
            if (Items != null)
            {

                if (AdditionalAttributes == null)
                {
                    AdditionalAttributes = new Dictionary<string, object>();
                }

                if (!AdditionalAttributes.ContainsKey("class"))
                {
                    var attributesTable = typeof(T).GetCustomAttribute<DisplayRazorTableAttribute>();

                    if (attributesTable != null && attributesTable.TableClass != null)
                    {
                        AdditionalAttributes.Add("class", attributesTable.TableClass);
                    }
                    else
                    {
                        AdditionalAttributes.Add("class", _defaultCSSClass);
                    }
                }

                if (!AdditionalAttributes.ContainsKey("style"))
                {
                    var attributesTable = typeof(T).GetCustomAttribute<Style>();

                    var sb = new StringBuilder();

                    if (attributesTable != null && attributesTable.Color != null)
                        sb.Append("color:" + attributesTable.Color);


                    AdditionalAttributes.Add(
                            "style", sb.ToString());
                }

                var _properties = typeof(T).GetProperties(
                    BindingFlags.Public |
                    BindingFlags.Instance
                    );

                DisplayRazorTableAttribute[] attributes =
                    new DisplayRazorTableAttribute[_properties.Length];

                StringBuilder _sb;
                if (Head == null)
                {
                    _sb = new StringBuilder();
                    for (int i = 0; i < _properties.Length; i++)
                    {
                        attributes[i] =
                            _properties[i].GetCustomAttribute<DisplayRazorTableAttribute>();

                        var openTHTag =
                            attributes[i] != null && attributes[i].HeaderClass != null ?
                            $"<th class='{attributes[i].HeaderClass}'>" : "<th>";

                        var header =
                            attributes[i] != null && attributes[i].Header != null ?
                            attributes[i].Header : _properties[i].Name;

                        _sb.Append($"{openTHTag}{header}</th>");
                    }
                    _defaultHead = new MarkupString(_sb.ToString());
                }

                if (Body == null)
                {
                    _sb = new StringBuilder();
                    foreach (var item in Items)
                    {
                        _sb.Append("<tr>");
                        for (int i = 0; i < _properties.Length; i++)
                        {
                            var openTDTag =
                                attributes[i] != null && attributes[i].ValueClass != null ?
                                $"<td class='{attributes[i].ValueClass}'>" : "<td>";

                            var value =
                                attributes[i] != null && attributes[i].ValueFormat != null ?
                                string.Format(attributes[i].ValueFormat,
                                _properties[i].GetValue(item)) :
                                _properties[i].GetValue(item);

                            _sb.Append($"{openTDTag}{value}</td>");

                        }
                        _sb.Append($"</tr>");
                    }
                    _defaultBody = new MarkupString(_sb.ToString());
                }
            }
        }
    }
}
