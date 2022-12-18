using System.Collections.Generic;
using Prism.Events;

namespace PrismSample.Common.Utils;

//聚合消息类
public class Message:PubSubEvent<Dictionary<string,object>>
{
    
}