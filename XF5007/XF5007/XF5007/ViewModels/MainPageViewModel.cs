using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF5007.ViewModels
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF5007.Services;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand StartCommand { get; set; }
        public DelegateCommand ReadCommand { get; set; }
        public DelegateCommand ResetCommand { get; set; }
        public int Counter { get; set; }
        public string AppLifeStatusRecord { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ReadCommand = new DelegateCommand(async () =>
            {
                AppLifeStatusRecord = await new AppLifeStatusService().ReadAsync();
            });
            ResetCommand = new DelegateCommand(async () =>
            {
                await new AppLifeStatusService().WriteAsync("", true);
                AppLifeStatusRecord = "";
            });
            StartCommand = new DelegateCommand(async () =>
            {
                for (int i = 0; i < 60; i++)
                {
                    await Task.Delay(2000);
                    Counter++;
                    Console.WriteLine($"   === {i} ===");
                    await new AppLifeStatusService().WriteAsync($"     Xamarin.Forms= {i} = > Timer - {DateTime.Now.Minute}:{DateTime.Now.Second}");
                }
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
