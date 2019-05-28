using System;
using System.Collections.Generic;
using System.Text;

namespace XF3054.Models
{
    public class InvoiceRequestDTO
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public UserDTO user { get; set; }
        public DateTime Date { get; set; }
        public string Memo { get; set; }
    }
}
