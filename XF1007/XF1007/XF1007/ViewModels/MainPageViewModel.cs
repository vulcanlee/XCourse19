using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XF1007.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _YourAccount;

        public string YourAccount
        {
            get { return _YourAccount; }
            set { _YourAccount = value; OnPropertyChanged(); }
        }
        private string _YourAnswer;

        public string YourAnswer
        {
            get { return _YourAnswer; }
            set { _YourAnswer = value; OnPropertyChanged(); }
        }
        public ICommand 登入Command { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            登入Command = new Command(() =>
            {
                YourAnswer = YourAccount;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            //var fooPropertyChanged = PropertyChanged;
            //if (fooPropertyChanged != null)
            //{
            //    PropertyChanged(this,
            //                  new PropertyChangedEventArgs(propertyName));
            //}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
