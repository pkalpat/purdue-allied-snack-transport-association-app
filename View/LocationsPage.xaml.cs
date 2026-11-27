using PurduePasta.ViewModel;

namespace PurduePasta.View;

public partial class LocationsPage : ContentPage
{
    private readonly OrderingViewModel? orderingViewModel;
    private LocationsViewModel ViewModel => (LocationsViewModel)BindingContext;

    public LocationsPage(OrderingViewModel? orderingViewModel = null)
    {
        InitializeComponent();
        this.orderingViewModel = orderingViewModel;
        BindingContext = new LocationsViewModel();
    }

    private async void OnDoneClicked(object? sender, EventArgs e)
    {
        if (ViewModel.SelectedLocation is not null && orderingViewModel is not null)
            orderingViewModel.DeliverySpot = ViewModel.SelectedLocation.Name;
        await Navigation.PopAsync();
    }
}
