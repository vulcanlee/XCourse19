using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XF3031.Models
{
    public class MyTaskItem : INotifyPropertyChanged, ICloneable
    {

        public event PropertyChangedEventHandler PropertyChanged;
        //工作名稱
        public string MyTaskName { get; set; }
        //狀態
        public string MyTaskStatus { get; set; }
        //指派日期
        public DateTime MyTaskDate { get; set; }

        public MyTaskItem Clone()
        {
            var fooObject = ((ICloneable)this).Clone();
            return fooObject as MyTaskItem;
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
