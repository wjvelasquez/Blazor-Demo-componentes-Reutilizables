using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;


namespace BlazorDemo.Components
{
    partial class Select<T> : ComponentBase
    {
        /// <summary>
        /// Texto mostrado por defecto
        /// </summary>
        [Parameter]
        public string DefaultOptionText { get; set; }
        /// <summary>
        /// Lista a cargar
        /// </summary>
        [Parameter]
        public IEnumerable<T> Items { get; set; }
        /// <summary>
        /// Campo a mostar
        /// </summary>
        [Parameter]
        public string DisplayMemberName { get; set; }
        /// <summary>
        /// Valor en option value
        /// </summary>
        [Parameter]
        public string ValueMember { get; set; }
        /// <summary>
        /// Manejador de evento al selecionar
        /// </summary>
        [Parameter]
        public EventCallback<ChangeEventArgs> OnChange { get; set; }

        /// <summary>
        /// Atributos Adicionales
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditionalAttributes { get; set; }
        /// <summary>
        /// Muestra Mientras carga
        /// </summary>
        [Parameter]
        public RenderFragment NullItems { get; set; }
        object GetDisplayMemberName(int index)
        {
            object result;
            PropertyInfo property;
            property = string.IsNullOrEmpty(DisplayMemberName) ?
                typeof(T).GetProperties()[0] :
                typeof(T).GetProperty(DisplayMemberName);
            result = property?.GetValue(Items.ElementAt(index));
            return result;
        }
        object GetValueMember(int index)
        {
            object result;
            PropertyInfo property;
            property = string.IsNullOrEmpty(ValueMember) ?
                typeof(T).GetProperties()[0] :
                typeof(T).GetProperty(ValueMember);
            result = property?.GetValue(Items.ElementAt(index));
            return result;
        }
    }
}
