using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF2009.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class EditPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GoBackPageCommand { get; set; }

        private readonly INavigationService navigationService;

        public EditPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GoBackPageCommand = new DelegateCommand(() =>
            {
                var fooPage = App.Current.MainPage;
                var fooNavigationStack = fooPage.Navigation.NavigationStack;
                var fooModalStack = fooPage.Navigation.ModalStack;
                var fooRemovePageNode = fooNavigationStack[fooNavigationStack.Count - 1];
                fooPage.Navigation.RemovePage(fooRemovePageNode);

                navigationService.GoBackAsync();
            });

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
