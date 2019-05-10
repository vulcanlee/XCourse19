using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF4020.Models;

namespace XF4020.TemplateSelectors
{
    public class ChatDataTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// 他人對話時候，所要使用的樣板
        /// </summary>
        public DataTemplate OtherTemplate { get; set; }

        // 這個物件值，將會在 XAML 中來定義

        /// <summary>
        /// 自己發出對話內容的時候，所要使用的樣板
        /// </summary>
        public DataTemplate OwnerTemplate { get; set; }

        /// <summary>
        /// 當要顯示該筆資料的時候，依據該資料上的內容，決定要使用哪個資料樣板格式
        /// </summary>
        /// <param name="item"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            // 根據當時物件的值，決定要使用哪個資料樣板
            return ((ChatContent)item).對話類型 == 對話類型.他人 ? OtherTemplate : OwnerTemplate;
        }
    }
}
