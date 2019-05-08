﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3028.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand ListView基本應用不可修改紀錄Command { get; private set; }
        public DelegateCommand ListView基本應用可修改紀錄Command { get; private set; }
        public DelegateCommand 可變紀錄列高Command { get; private set; }
        public DelegateCommand 固定紀錄列高Command { get; private set; }
        public DelegateCommand 客製化資料列與資料按鈕Command { get; private set; }
        public DelegateCommand 客製化資料列與資料按鈕會失效Command { get; private set; }
        public DelegateCommand 頁首頁尾自動捲動互動功能表Command { get; private set; }
        public DelegateCommand 自動捲動到指定紀錄Command { get; private set; }
        public DelegateCommand 下拉更新Command { get; private set; }
        public DelegateCommand 點選與取消選取Command { get; private set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ListView基本應用不可修改紀錄Command = new DelegateCommand(ListView基本應用不可修改紀錄);
            ListView基本應用可修改紀錄Command = new DelegateCommand(ListView基本應用可修改紀錄);
            可變紀錄列高Command = new DelegateCommand(可變紀錄列高);
            固定紀錄列高Command = new DelegateCommand(固定紀錄列高);
            客製化資料列與資料按鈕Command = new DelegateCommand(客製化資料列與資料按鈕);
            客製化資料列與資料按鈕會失效Command = new DelegateCommand(客製化資料列與資料按鈕會失效);
            頁首頁尾自動捲動互動功能表Command = new DelegateCommand(頁首頁尾自動捲動互動功能表);
            自動捲動到指定紀錄Command = new DelegateCommand(自動捲動到指定紀錄);
            下拉更新Command = new DelegateCommand(下拉更新);
            點選與取消選取Command = new DelegateCommand(點選與取消選取);
        }

        private async void 點選與取消選取()
        {
            await navigationService.NavigateAsync("ItemClickPage");
        }

        private async void 下拉更新()
        {
            await navigationService.NavigateAsync("PullToRefreshPage");
        }

        private async void 自動捲動到指定紀錄()
        {
            await navigationService.NavigateAsync("ScrollToPage");
        }

        private async void 頁首頁尾自動捲動互動功能表()
        {
            await navigationService.NavigateAsync("HeaderFooterPage");
        }

        private async void 客製化資料列與資料按鈕會失效()
        {
            await navigationService.NavigateAsync("CustomButtonPage");
        }

        private async void 客製化資料列與資料按鈕()
        {
            await navigationService.NavigateAsync("CustomButton1Page");
        }

        private async void 固定紀錄列高()
        {
            // 使用 Query String 的方式來傳送參數
            await navigationService.NavigateAsync("RowHeightPage");
        }

        private async void 可變紀錄列高()
        {
            // 使用 NavigationParameters 物件來傳送參數
            await navigationService.NavigateAsync("VariRowHeithtPage");
        }

        private async void ListView基本應用可修改紀錄()
        {
            await navigationService.NavigateAsync("Basic1Page");
        }

        private async void ListView基本應用不可修改紀錄()
        {
            await navigationService.NavigateAsync("BasicPage");
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
