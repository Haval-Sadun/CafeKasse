using CafeKasse.MAUI.ViewModels;

namespace CafeKasse.MAUI.Pages.Controls;

public partial class OrderControl : ContentView
{

    private readonly OrderItemViewModel _orderItemViewModel;
    public OrderControl(OrderItemViewModel orderItemViewModel)
    {
        InitializeComponent();
        _orderItemViewModel = orderItemViewModel;
        BindingContext = _orderItemViewModel;
    }
}