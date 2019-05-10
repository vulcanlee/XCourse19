using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XF4016.AttachedProperties
{
    /// <summary>
    /// 建立一個類別，裡面使用 BindableProperty.CreateAttached 建立一個 XAML 用的附加屬性
    /// 在 XAML 中的用法     <Entry CustomAttached:EntryTypeAttached.EntryType="Email" />
    /// </summary>
    public class AwesomeEntryTypeAttached
    {
        #region AwesomeEntryType 附加屬性 Attached Property
        public static readonly BindableProperty AwesomeEntryTypeProperty =
               BindableProperty.CreateAttached(
                   propertyName: "AwesomeEntryType",   // 屬性名稱 
                   returnType: typeof(string), // 回傳類型 
                   declaringType: typeof(AwesomeEntryTypeAttached), // 宣告類型 
                   defaultValue: null, // 預設值 
                   propertyChanged: OnAwesomeEntryTypeChanged  // 屬性值異動時，要執行的事件委派方法
               );

        public static void SetAwesomeEntryType(BindableObject bindable, string entryType)
        {
            bindable.SetValue(AwesomeEntryTypeProperty, entryType);
        }
        public static string GetAwesomeEntryType(BindableObject bindable)
        {
            return (string)bindable.GetValue(AwesomeEntryTypeProperty);
        }

        private static void OnAwesomeEntryTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // 若所附加的屬性不是 Entry，則不要有任何處理動作
            var fooEntry = bindable as Entry;
            if (fooEntry == null)
                return;

            // 取得屬性值變動前與變動後的值
            var foooldValue = (oldValue as string)?.ToLower();
            var foonewValue = (newValue as string)?.ToLower();

            if (foonewValue == null)
            {
                return;
            }

            #region 根據指定附加屬性的值，設定所綁訂到的控制項(Entry)，的 Placeholder 屬性成為預設指定的文字
            switch (foonewValue)
            {
                case "None":
                    break;
                case "email":
                    fooEntry.SetValue(Entry.PlaceholderProperty, "請輸入電子郵件");
                    fooEntry.Keyboard = Keyboard.Email;
                    fooEntry.FontSize = 20;
                    break;
                case "phone":
                    fooEntry.SetValue(Entry.PlaceholderProperty, "請輸入電話號碼");
                    fooEntry.Keyboard = Keyboard.Telephone;
                    fooEntry.FontSize = 16;
                    break;
                case "number":
                    fooEntry.SetValue(Entry.PlaceholderProperty, "請輸入數值");
                    fooEntry.Keyboard = Keyboard.Numeric;
                    fooEntry.FontSize = 24;
                    break;
                default:
                    break;
            }
            #endregion
        }
        #endregion

    }
}
