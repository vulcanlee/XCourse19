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
    using XF3028.Models;
    using XF3028.Repositories;

    public class BasicPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MyItem> MyItemList { get; set; } = new ObservableCollection<MyItem>();
        public string PropertyName { get; set; }
        public MyItem MyItemListSelected { get; set; }
        public DelegateCommand 新增Command { get; private set; }
        public DelegateCommand 修改Command { get; private set; }
        public DelegateCommand 刪除Command { get; private set; }
        private readonly INavigationService navigationService;

        public BasicPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            MyItemList = MyItemRepository.Sample();

            新增Command = new DelegateCommand(新增);
            修改Command = new DelegateCommand(修改);
            刪除Command = new DelegateCommand(刪除);
        }

        private void 刪除()
        {
            var fooItem = MyItemList.FirstOrDefault(x => x.FirstName == MyItemListSelected.FirstName &&
            x.LastName == MyItemListSelected.LastName && x.Age == MyItemListSelected.Age);
            if (fooItem != null)
            {
                MyItemList.Remove(fooItem);
            }
        }

        private void 修改()
        {
            if (MyItemListSelected != null)
            {
                // 底下程式碼，無法讓 UI 同步更新已經修正的內容
                #region 直接修改綁定的物件 
                MyItemListSelected.FirstName = "艾嬡";
                MyItemListSelected.LastName = "林";
                MyItemListSelected.Age = 33;
                #endregion

                // 若每筆紀錄的每個欄位沒有實作 INotifyPropertyChanged 介面
                // 則當修改某一紀錄的欄位時候，就無法立即反應、顯示更新結果
                // 您需要變通，重新設定這筆紀錄，或者刪除這筆紀錄再加入
                // 請參考底下兩個方法(這樣的方法比較複雜)

                #region 先找到、修改、再回去設定 (沒有動畫)
                //var fooItem = MyItemList.FirstOrDefault(x => x.FirstName == myItemListSelected.FirstName &&
                //x.LastName == myItemListSelected.LastName && x.Age == myItemListSelected.Age);

                //if (fooItem != null)
                //{
                //    var fooIdx = myItemList.IndexOf(fooItem);

                //    fooItem.FirstName = "艾嬡";
                //    fooItem.LastName = "林";
                //    fooItem.Age = 33;
                //    myItemList[fooIdx]= fooItem;
                //}
                #endregion

                #region 先找到、移除、再加入 (會有動畫)
                //var fooItem = MyItemList.FirstOrDefault(x => x.FirstName == myItemListSelected.FirstName &&
                //x.LastName == myItemListSelected.LastName && x.Age == myItemListSelected.Age);

                //if (fooItem != null)
                //{
                //    var fooIdx = myItemList.IndexOf(fooItem);
                //    myItemList.Remove(fooItem);

                //    fooItem.FirstName = "艾嬡";
                //    fooItem.LastName = "林";
                //    fooItem.Age = 33;
                //    myItemList.Insert(fooIdx, fooItem);
                //}
                #endregion
            }
        }

        private void 新增()
        {
            MyItemList.Add(new MyItem
            {
                FirstName = "文君",
                LastName = "簡",
                Age = 19
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
