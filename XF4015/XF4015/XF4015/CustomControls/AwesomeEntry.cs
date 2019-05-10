using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XF4015.CustomControls
{
    /// <summary>
    /// 繼承原有控制項，並在新的控制項中，加入一個新的可綁定屬性，使得新的控制項可以具有另外一種表現能力
    /// 在 XAML 中使用的範例 <CustomControl:AwesomeEntry EntryType="Email" />
    /// </summary>
    public class AwesomeEntry : Entry
    {
        #region EntryType 可綁定屬性 BindableProperty
        public static readonly BindableProperty EntryTypeProperty =
            BindableProperty.Create("EntryType", // 屬性名稱 
                typeof(string), // 回傳類型 
                typeof(AwesomeEntry), // 宣告類型 
                "None", // 預設值 
                propertyChanged: OnEntryTypeChanged  // 屬性值異動時，要執行的事件委派方法
            );

        public string EntryType
        {
            set
            {
                SetValue(EntryTypeProperty, value);
            }
            get
            {
                return (string)GetValue(EntryTypeProperty);
            }
        }

        private static void OnEntryTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // 取得現在控制項的物件
            var fooEntry = bindable as AwesomeEntry;

            // 取得該可綁定屬性，變更前的值
            var foooldValue = (oldValue as string).ToLower();
            // 取得該可綁定屬性，變更後的值
            var foonewValue = (newValue as string).ToLower();

            #region 根據可綁定屬性設定的值內容，進行相關客製化的處理動作
            switch (foonewValue)
            {
                case "None":
                    break;
                case "email":
                    fooEntry.SetValue(PlaceholderProperty, "請輸入電子郵件");
                    fooEntry.Keyboard = Keyboard.Email;
                    fooEntry.TextColor = Color.Red;
                    fooEntry.FontSize = 26;
                    break;
                case "phone":
                    fooEntry.SetValue(PlaceholderProperty, "請輸入電話號碼");
                    fooEntry.Keyboard = Keyboard.Telephone;
                    fooEntry.TextColor = Color.Green;
                    fooEntry.FontSize = 20;
                    break;
                case "number":
                    fooEntry.SetValue(PlaceholderProperty, "請輸入數值");
                    fooEntry.Keyboard = Keyboard.Numeric;
                    fooEntry.TextColor = Color.Blue;
                    fooEntry.FontSize = 16;
                    break;
                default:
                    break;
            }
            #endregion
        }

        #endregion

    }
}
