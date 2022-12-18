using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismSample.Views;

namespace PrismSample.ViewModels;

public class MainWindowViewModel:BindableBase
{

    private readonly IRegionManager _regionManager;
    
    public DelegateCommand ViewACommand { get; private set; }
    
    public DelegateCommand HeadViewCommand { get; private set; }
    
    public DelegateCommand ContentViewCommand { get; private set; }
    
    
    public MainWindowViewModel(IRegionManager regionManager)
    {
        
        ////////////////
        _regionManager = regionManager;
        //向ContentRegion区域注册一个view   这个是对应在xaml直接注册   方法一
        _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ContentView));
        /////////////////////
        
        
        
        ViewACommand = new DelegateCommand((() =>
        {
            _regionManager.RequestNavigate("ContentRegion","PageA");
        }));
        
        ContentViewCommand = new DelegateCommand((() =>
        {
            _regionManager.RequestNavigate("ContentRegion"," ContentView");
        }));
        
        HeadViewCommand = new DelegateCommand((() =>
        {
            _regionManager.RequestNavigate("ContentRegion","HeadView");
        }));
    }

  
}