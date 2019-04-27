using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF3003.Models;

namespace XF3003.DataTemplateSelectors
{
    public class MyItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LabelDataTemplate { get; set; }
        public DataTemplate BoxViewDataTemplate { get; set; }
        public DataTemplate EntryDataTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            ItemBlock foo = (ItemBlock)item;
            if (foo.ShowViewType == ItemBlockTypeEnum.Label)
            {
                return LabelDataTemplate;
            }
            else if (foo.ShowViewType == ItemBlockTypeEnum.BoxView)
            {
                return BoxViewDataTemplate;
            }
            else
            {
                return EntryDataTemplate;
            }
        }
    }
}
