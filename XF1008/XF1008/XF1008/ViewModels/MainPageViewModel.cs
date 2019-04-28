using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF1008.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        #region YourAccount Property
        private string _YourAccount;
        public string YourAccount
        {
            get { return _YourAccount; }
            set { SetProperty(ref _YourAccount, value); }
        }
        #endregion

        #region YourAnswer Property
        private string _YourAnswer;
        public string YourAnswer
        {
            get { return _YourAnswer; }
            set { SetProperty(ref _YourAnswer, value); }
        }
        #endregion
        public DelegateCommand 登入Command { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            登入Command = new DelegateCommand(() =>
            {
                YourAnswer = YourAccount;
            });
        }
    }
}
