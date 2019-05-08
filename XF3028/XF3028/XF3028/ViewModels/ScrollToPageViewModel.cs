using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF3028.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF3028.Repositories;

    public class ScrollToPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PersonWithButtonViewModel> MyData { get; set; } = new ObservableCollection<PersonWithButtonViewModel>();
        public PersonWithButtonViewModel MyDataSelected { get; set; }
        public DelegateCommand 捲到2ZacharyCommand { get; private set; }
        public DelegateCommand 捲到BobCommand { get; private set; }
        public Action<PersonWithButtonViewModel> 自動捲動到;
        private readonly INavigationService navigationService;

        public ScrollToPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            MyData = PersonRepository.SampleWithButtonViewModel();

            捲到2ZacharyCommand = new DelegateCommand(捲到2Zachary);
            捲到BobCommand = new DelegateCommand(捲到Bob);
        }
        private void 捲到Bob()
        {
            if (自動捲動到 != null)
            {
                var fooItem = MyData.FirstOrDefault(x => x.Name == "Bob");
                if (fooItem != null)
                {
                    自動捲動到(fooItem);
                }
            }
        }

        private void 捲到2Zachary()
        {
            if (自動捲動到 != null)
            {
                var fooItem = MyData.FirstOrDefault(x => x.Name == "2Zachary");
                if (fooItem != null)
                {
                    自動捲動到(fooItem);
                }
            }
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
