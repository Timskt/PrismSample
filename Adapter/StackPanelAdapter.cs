using System.Windows;
using System.Windows.Controls;
using Prism.Regions;

namespace PrismSample.Adapter;

/// <summary>
/// 需要重写哪个控件即指定相应泛型即可，如此处的StackPanle
/// </summary>
public class StackPanelAdapter:RegionAdapterBase<StackPanel>
{
    public StackPanelAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="region"></param>
    /// <param name="regionTarget"></param>
    /// <exception cref="NotImplementedException"></exception>
    protected override void Adapt(IRegion region, StackPanel regionTarget)
    {
        region.Views.CollectionChanged += (s, e) =>
        {
            //监听到新增ui事件,将新增的ui加入到该区域
            if (e.Action==System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (UIElement eNewItem in e.NewItems)
                {
                    regionTarget.Children.Add(eNewItem);
                }
            }
        };
    }

    /// <summary>
    /// 默认写法即可
    /// </summary>
    /// <returns></returns>
    protected override IRegion CreateRegion()
    {
        return new Region();
    }
}