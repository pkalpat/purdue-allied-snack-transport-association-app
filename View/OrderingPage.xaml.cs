using PurduePasta.Model;
using PurduePasta.ViewModel;

namespace PurduePasta.View;

public partial class OrderingPage : ContentPage
{
    private OrderingViewModel ViewModel => (OrderingViewModel)BindingContext;

    public OrderingPage()
    {
        InitializeComponent();
        BindingContext = new OrderingViewModel();
    }

    private async void OnLocationsClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new LocationsPage(ViewModel));
    }

    private void OnCategoryClicked(object? sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string category)
            ViewModel.SelectedCategory = category;
    }

    private async void OnCartClicked(object? sender, EventArgs e)
    {
        if (ViewModel.CartCount == 0)
        {
            await DisplayAlert("Your cart is empty", "Add a snack or meal to get started.", "Got it");
            return;
        }
        await DisplayAlert("Ready to roll", $"Your order for {ViewModel.DeliverySpot} totals ${ViewModel.Subtotal:0.00}.", "Place order");
    }
}
