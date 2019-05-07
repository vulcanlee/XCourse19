using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF3018.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyButton : ContentView
    {
        public MyButton()
        {
            InitializeComponent();
        }
    }
}