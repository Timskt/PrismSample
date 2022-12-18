using System.Collections.Generic;
using System.Windows;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismSample.Common.Utils;

namespace PrismSample.ViewModels;

public class ContentViewViewModel:BindableBase
{

    private readonly IEventAggregator _eventAggregator;
    
    private string title = "ContentView OpenCommand";
    
    public string Title
    {
        get { return title;}
        set { title = value;RaisePropertyChanged(); }
    }
    
    //注册命令
    public DelegateCommand OpenCommand { get; private set; }

    public DelegateCommand CloseCommand { get; private set; }
    
    //组合命令
    public CompositeCommand OpenClose { get; private set; }
    
    public DelegateCommand SendMessageCommand { get; private set; }
    
    
    public ContentViewViewModel(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
        
        //设置命令的具体执行内容
        SendMessageCommand = new DelegateCommand((() =>
        {
            //发布消息
            eventAggregator.GetEvent<Message>().Publish((new Dictionary<string, object>()
            {
                //在这里构建需要发送的消息内容
            }));
        }));
        
        OpenCommand = new DelegateCommand((() =>
        {
            Title = "OpenCommand running";
            
            //订阅消息
            eventAggregator.GetEvent<Message>().Subscribe((data =>
            {
                MessageBox.Show("接收到消息");
            }),ThreadOption.PublisherThread,false, msg =>
            {
                //在这里写事件过滤器的具体代码  true则会进到处理函数，false则被舍弃
                return true;
            });
        }));
        CloseCommand = new DelegateCommand((() =>
        {
            Title = "CloseCommand running";
        }));
        //注册命令
        OpenClose.RegisterCommand(OpenCommand);
        OpenClose.RegisterCommand(CloseCommand);
    }
    
}
