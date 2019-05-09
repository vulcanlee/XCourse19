using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace XF4033.AttachedProperties
{
    public class BindingContextHelper
    {
        #region GetBindingContextType 附加屬性 Attached Property 
        // 若該附加屬性為 True，則會在 Visual Studio 輸出視窗中，顯示該物件當時的 BindingContext 物件型別名稱
        public static readonly BindableProperty GetBindingContextTypeProperty =
               BindableProperty.CreateAttached(
                   propertyName: "GetBindingContextType",   // 屬性名稱 
                   returnType: typeof(bool), // 回傳類型 
                   declaringType: typeof(VisualElement), // 宣告類型 
                   defaultValue: false, // 預設值 
                   propertyChanged: OnGetBindingContextTypeChanged  // 屬性值異動時，要執行的事件委派方法                  
               );

        public static void SetGetBindingContextType(BindableObject bindable, bool entryType)
        {
            bindable.SetValue(GetBindingContextTypeProperty, entryType);
        }
        public static bool GetGetBindingContextType(BindableObject bindable)
        {
            return (bool)bindable.GetValue(GetBindingContextTypeProperty);
        }

        private static void OnGetBindingContextTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is VisualElement)
            {
                var fooValue = (bool)newValue;
                if (fooValue == true)
                {
                    var fooObject = bindable as VisualElement;
                    var fooBCType = fooObject.BindingContext.GetType().FullName;
                    var fooEleType = bindable.GetType().FullName;

                    Debug.WriteLine($"---------->> 【{fooEleType}】 的 BindingContext 是 ╴▄▆█{fooBCType}█▆▄╴");
                }
            }
        }
        #endregion

        #region PrintInheritance 附加屬性 Attached Property
        public static readonly BindableProperty PrintInheritanceProperty =
               BindableProperty.CreateAttached(
                   propertyName: "PrintInheritance",   // 屬性名稱 
                   returnType: typeof(bool), // 回傳類型 
                   declaringType: typeof(VisualElement), // 宣告類型 
                   defaultValue: false, // 預設值 
                   propertyChanged: OnPrintInheritanceChanged  // 屬性值異動時，要執行的事件委派方法
               );

        public static void SetPrintInheritance(BindableObject bindable, bool entryType)
        {
            bindable.SetValue(PrintInheritanceProperty, entryType);
        }
        public static bool GetPrintInheritance(BindableObject bindable)
        {
            return (bool)bindable.GetValue(PrintInheritanceProperty);
        }

        private static void OnPrintInheritanceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is Element)
            {
                Stack<Element> fooStackElement = new Stack<Element>();
                var fooNextObject = bindable;
                while (true)
                {
                    if (fooNextObject == null)
                    {
                        break;
                    }
                    var fooObject = fooNextObject as Element;
                    fooStackElement.Push(fooObject);
                    fooNextObject = fooObject.Parent;
                }

                int fooLevel = 0;
                foreach (var item in fooStackElement)
                {
                    string fooSpace = new string(' ', fooLevel++ * 4);
                    string fooEleType = item.GetType().Name;
                    string fooEleBCType = "";
                    if (item.BindingContext != null)
                    {
                        fooEleBCType = item.BindingContext.GetType().Name;
                    }
                    else
                    {
                        fooEleBCType = "null";
                    }
                    Debug.WriteLine($"---------->> {fooSpace}【{fooEleType}】 and BindingContext is {fooEleBCType}");
                }
            }
        }
        #endregion

    }
}
