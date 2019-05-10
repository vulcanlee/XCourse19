using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XF4018.Behaviors
{
    class EmptyHighlightBehavior : Behavior<Entry>
    {

        protected override void OnAttachedTo(Entry bindable)
        {
            RefreshBackgroundColor(bindable);
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            RefreshBackgroundColor(sender);
        }

        // 根據現在 Entry 檢視的 Text 屬性值，判斷是否要提示背景顏色，告知該欄位尚未輸入任何值
        static void RefreshBackgroundColor(object sender)
        {
            if (string.IsNullOrEmpty(((Entry)sender).Text))
            {
                ((Entry)sender).BackgroundColor = Color.Red;
            }
            else
            {
                if (((Entry)sender).Text.Length >= 6)
                {
                    ((Entry)sender).BackgroundColor = Color.Default;
                    ((Entry)sender).TextColor = Color.Default;
                }
                else
                {
                    ((Entry)sender).BackgroundColor = Color.Default;
                    ((Entry)sender).TextColor = Color.Red;
                }
            }
        }
    }
}
