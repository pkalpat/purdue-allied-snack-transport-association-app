using System.Collections.ObjectModel;
using System.Windows.Input;
using PurduePasta.Model;

namespace PurduePasta.ViewModel;

public sealed class LocationsViewModel : BindableBase
{
    private readonly List<DeliveryLocation> allLocations =
    [
        new() { Name = "Hillenbrand Hall", Neighborhood = "West Lafayette", Address = "320 W State St", Emoji = "🏠", Eta = "15–20 min", IsFeatured = true },
        new() { Name = "Wiley Dining Court", Neighborhood = "Purdue West", Address = "Wiley Hall, 335 W State St", Emoji = "🍽️", Eta = "12–18 min", IsFeatured = true },
        new() { Name = "Chauncey Square", Neighborhood = "Downtown", Address = "119 N River Rd", Emoji = "🌆", Eta = "18–25 min", IsFeatured = false },
        new() { Name = "Purdue Memorial Union", Neighborhood = "Campus", Address = "101 N Grant St", Emoji = "🎓", Eta = "10–15 min", IsFeatured = true },
        new() { Name = "The Hub", Neighborhood = "Northwest campus", Address = "201 N University St", Emoji = "🏢", Eta = "20–28 min", IsFeatured = false }
    ];

    private string searchText = string.Empty;
    private DeliveryLocation? selectedLocation;

    public ObservableCollection<DeliveryLocation> VisibleLocations { get; } = [];
    public string SearchText { get => searchText; set { searchText = value; FilterLocations(); OnPropertyChanged(nameof(SearchText)); } }
    public DeliveryLocation? SelectedLocation { get => selectedLocation; private set { selectedLocation = value; OnPropertyChanged(nameof(SelectedLocation)); OnPropertyChanged(nameof(SelectionSummary)); } }
    public string SelectionSummary => SelectedLocation is null ? "Choose a delivery spot" : $"Deliver to {SelectedLocation.Name}";
    public ICommand SelectLocationCommand { get; }

    public LocationsViewModel()
    {
        SelectLocationCommand = new Command<DeliveryLocation>(location => SelectedLocation = location);
        FilterLocations();
    }

    private void FilterLocations()
    {
        VisibleLocations.Clear();
        var query = SearchText.Trim();
        foreach (var location in allLocations.Where(x => string.IsNullOrWhiteSpace(query) || x.Name.Contains(query, StringComparison.OrdinalIgnoreCase) || x.Neighborhood.Contains(query, StringComparison.OrdinalIgnoreCase)))
            VisibleLocations.Add(location);
    }
}
