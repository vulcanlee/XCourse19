using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF2013.Events
{
    public class YourAnswerEvent : PubSubEvent<YourAnswerPayload>
    {

    }

    public class YourAnswerPayload
    {
        public string Answer { get; set; }
    }
}
