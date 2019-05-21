using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF5006.ViewModels
{
    using System.ComponentModel;
    using System.Diagnostics;
    using DataModel;
    using Microsoft.EntityFrameworkCore;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Message { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            using (var db = new DatabaseContext())
            {
                try
                {
                    db.Database.Migrate();

                    db.Add(new Blog() { Rating = 5, Url = "https://mylabtw.blogspot.com/" });
                    db.SaveChanges();
                    Message = $"Blog 資料表內的紀錄數量 {db.Blogs.Count()}";
                }
                catch (Exception ex)
                {

                    Debug.Write(ex.Message);
                }
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
