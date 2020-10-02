using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlazorDemo.Components
{
    partial class SelectExa<T> : ComponentBase
    {
        [Parameter]
        public EventCallback<ChangeEventArgs> OnChangeSelect { get; set; }
        [Parameter]
        public IEnumerable<T> Items { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }

        MarkupString SelectOption;

        protected override void OnParametersSet()
        {
            if (AdditionalAttributes == null)
            {
                AdditionalAttributes = new Dictionary<string, object>();
            }
            if (Items != null)
            {
                StringBuilder sb = new StringBuilder();
                var properties = typeof(T).GetProperties(
                    BindingFlags.Public | BindingFlags.Instance);
                foreach (var item in Items)
                {
                    if (properties.Length >= 2)
                    {
                        List<string> values = new List<string>();
                        foreach (var property in properties)
                        {
                            var value = property.GetValue(item);
                            values.Add(value.ToString());
                            if (values.Count == 2)
                            {
                                break;
                            }
                        }
                        sb.Append($"<option value='{values[0]}'>{values[1]}</option>");
                    }
                    else
                    {
                        break;
                    }
                }
                SelectOption = new MarkupString(sb.ToString());
            }
        }
    }

}
