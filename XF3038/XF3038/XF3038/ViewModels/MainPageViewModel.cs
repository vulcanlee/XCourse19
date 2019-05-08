using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3038.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool Loading { get; set; }
        public ObservableCollection<MyModel> MyDatas { get; set; } = new ObservableCollection<MyModel>();
        public MyModel SelectedMyData { get; set; }
        private readonly INavigationService _navigationService;
        public MyRepository _myRepository { get; set; }
        public DelegateCommand<MyModel> ItemAppearingCommand { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            _myRepository = MyRepository.GetInstance();

            ItemAppearingCommand = new DelegateCommand<MyModel>((x) =>
            {
                var fooLast = MyDatas.Last();
                if (x.ID == fooLast.ID)
                {
                    Reload(fooLast.ID + 1);
                }
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            await Reload(0);
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }
        /// <summary>
        /// 這裡是非同步函式，要回傳 Task，不要使用 void
        /// </summary>
        /// <param name="last"></param>
        public async Task Reload(int last)
        {
            Loading = true;
            var foo = _myRepository.GetNext(last);
            await Task.Delay(2000);
            foreach (var item in foo)
            {
                MyDatas.Add(item);
            }
            Loading = false;
        }
    }
    public class MyModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Current { get; set; }
    }
    public class MyRepository
    {
        public const int CycleLength = 20;
        public List<MyModel> Items = new List<MyModel>();
        private static MyRepository instance;
        private MyRepository()
        {
            this.GetNext(0);
        }

        public static MyRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new MyRepository();
            }
            return instance;
        }

        public List<MyModel> GetNext(int lastID)
        {
            List<MyModel> foo = new List<MyModel>();
            for (int i = lastID; i < lastID + MyRepository.CycleLength; i++)
            {
                var fooItem = new MyModel()
                {
                    ID = i,
                    Name = $"Name {i}",
                    Current = DateTime.UtcNow.AddDays(i),
                };
                Items.Add(fooItem);
                foo.Add(fooItem);
            }
            return foo;
        }
    }
}
