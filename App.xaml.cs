using System;
using System.Windows;
using System.Windows.Controls;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismSample.Adapter;
using PrismSample.Views;

namespace PrismSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        
        //注册页面、导航、服务等需要ioc的类对象
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
         //   containerRegistry.RegisterForNavigation<MainWindow>();
            containerRegistry.RegisterForNavigation<ContentView>();
            containerRegistry.RegisterForNavigation<HeadView>();
            //注册可以取别名
            containerRegistry.RegisterForNavigation<ViewA>("PageA");
        }

        //启动类
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            
            //注册自定义区域适配器
            regionAdapterMappings.RegisterMapping(typeof(StackPanel),Container.Resolve<StackPanelAdapter>());
        }

        //注册模块
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
    //        moduleCatalog.AddModule<Module.ModuleA>();
        }
    }
}