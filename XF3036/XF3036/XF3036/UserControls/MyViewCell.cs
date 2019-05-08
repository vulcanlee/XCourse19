using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XF3036.UserControls
{
    public class MyViewCell : ViewCell
    {
        public string BindingContextType { get; set; }
        protected override void OnBindingContextChanged()
        {
            BindingContextType = this.BindingContext.GetType().Name;
            base.OnBindingContextChanged();
        }
    }
}
