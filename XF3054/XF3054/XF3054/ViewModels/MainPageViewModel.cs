using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3054.ViewModels
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF3054.Models;
    using XF3054.Services;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            test();
        }

        private async Task test()
        {
            InvoiceService invoiceService = new InvoiceService();
            LoginService loginService = new LoginService();

            // 測試使用者登入
            await loginService.LoginAsync("user50", "password50");

            // 測試發票查詢
            List<InvoiceResponseDTO> invoiceResponseDTOs = await invoiceService.RetriveInvoiceAsync(loginService.item);

            // 測試發票新增
            InvoiceRequestDTO invoiceRequestDTO = new InvoiceRequestDTO()
            {
                InvoiceNo = "Vulcan123",
                Date = DateTime.Now,
                Memo = "測試用",
                user = new UserDTO() { Id = loginService.item.Id }
            };
            InvoiceResponseDTO invoiceResponseDTO = await invoiceService.CreateInvoiceAsync(loginService.item, invoiceRequestDTO);

            // 測試發票查詢
            invoiceResponseDTOs = await invoiceService.RetriveInvoiceAsync(loginService.item);

            // 測試發票修改
            invoiceRequestDTO = new InvoiceRequestDTO()
            {
                Id = invoiceResponseDTO.Id,
                InvoiceNo = invoiceResponseDTO.InvoiceNo,
                Date = invoiceResponseDTO.Date,
                Memo = "已經有修改了",
                user = invoiceResponseDTO.user,
            };
            invoiceResponseDTO = await invoiceService.UpdateInvoiceAsync(loginService.item, invoiceRequestDTO);

            // 測試發票查詢
            invoiceResponseDTOs = await invoiceService.RetriveInvoiceAsync(loginService.item);

            // 測試發票刪除
            foreach (var item in invoiceResponseDTOs)
            {
                await invoiceService.DeleteInvoiceAsync(loginService.item, item.Id);
            }

            // 測試發票查詢
            invoiceResponseDTOs = await invoiceService.RetriveInvoiceAsync(loginService.item);

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
