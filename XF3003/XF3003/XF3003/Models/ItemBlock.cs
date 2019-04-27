using System;
using System.Collections.Generic;
using System.Text;

namespace XF3003.Models
{
    public enum ItemBlockTypeEnum
    {
        Label,
        BoxView,
        Entry,
    }
    public class ItemBlock
    {
        public ItemBlockTypeEnum ShowViewType { get; set; }
        public string LabelText { get; set; }
        public int CountIndex { get; set; }
    }
}
