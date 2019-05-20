using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XF4034.Behaviors
{
    public class MaskedBehavior : Behavior<Entry>
    {
        //private string _mask = "";
        //public string Mask
        //{
        //    get => _mask;
        //    set
        //    {
        //        _mask = value;
        //    }
        //}
        public string Mask { get; set; }
        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;
            var text = entry.Text;

            if (!string.IsNullOrWhiteSpace(Mask))
            {
                // 1. 加入 MaxLength 值
                if (text.Length == Mask.Length)
                    entry.MaxLength = Mask.Length;
            }

            // 2. 評估用戶是否正在刪除測試
            if ((args.OldTextValue == null) || (args.OldTextValue.Length <= args.NewTextValue.Length))

                // 3. 評估遮罩位置
                for (int i = Mask.Length; i >= text.Length; i--)
                {
                    if (Mask[(text.Length - 1)] != 'X')
                    {
                        text = text.Insert((text.Length - 1), Mask[(text.Length - 1)].ToString());
                    }
                }
            entry.Text = text;
        }
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
    }
}
