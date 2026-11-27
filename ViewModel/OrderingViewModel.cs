using System.Collections.ObjectModel;
using System.Windows.Input;
using PurduePasta.Model;
using PastaMenuItem = PurduePasta.Model.MenuItem;

namespace PurduePasta.ViewModel;

public sealed class OrderingViewModel : BindableBase
{
    private readonly List<PastaMenuItem> allItems =
    [
        new() { Name = "Boiler Bowl", Description = "Crispy chicken, rice, greens & PASTA sauce", Category = "Bowls", Emoji = "🍚", Price = 11.50m, IsPopular = true },
        new() { Name = "Wabash Wrap", Description = "Turkey, pepper jack, lettuce & tomato", Category = "Wraps", Emoji = "🌯", Price = 9.25m, IsPopular = true },
        new() { Name = "Purdue Pretzel", Description = "Warm salted pretzel with cheese dip", Category = "Snacks", Emoji = "🥨", Price = 5.50m },
        new() { Name = "Triple XXX Shake", Description = "Vanilla bean, chocolate drizzle, whipped cream", Category = "Drinks", Emoji = "🥤", Price = 6.75m },
        new() { Name = "Cary Salad", Description = "Mixed greens, corn, avocado & lime vinaigrette", Category = "Bowls", Emoji = "🥗", Price = 10.00m },
        new() { Name = "Railroad Cookies", Description = "Two warm chocolate chip cookies", Category = "Snacks", Emoji = "🍪", Price = 4.00m }
    ];

    private string selectedCategory = "All";
    private string deliverySpot = "Hillenbrand Hall";

    public ObservableCollection<PastaMenuItem> VisibleItems { get; } = [];
    public ObservableCollection<CartItem> Cart { get; } = [];
    public IReadOnlyList<string> Categories { get; } = ["All", "Bowls", "Wraps", "Snacks", "Drinks"];
    public string SelectedCategory { get => selectedCategory; set { selectedCategory = value; FilterItems(); OnPropertyChanged(nameof(SelectedCategory)); } }
    public string DeliverySpot { get => deliverySpot; set { deliverySpot = value; OnPropertyChanged(nameof(DeliverySpot)); } }
    public decimal Subtotal => Cart.Sum(x => x.LineTotal);
    public int CartCount => Cart.Sum(x => x.Quantity);
    public string CartSummary => CartCount == 0 ? "Your cart is waiting" : $"{CartCount} item{(CartCount == 1 ? "" : "s")} · ${Subtotal:0.00}";
    public ICommand AddToCartCommand { get; }
    public ICommand IncreaseCommand { get; }
    public ICommand DecreaseCommand { get; }
    public ICommand OpenLocationsCommand { get; }

    public OrderingViewModel()
    {
        AddToCartCommand = new Command<PastaMenuItem>(AddToCart);
        IncreaseCommand = new Command<CartItem>(item => ChangeQuantity(item, 1));
        DecreaseCommand = new Command<CartItem>(item => ChangeQuantity(item, -1));
        OpenLocationsCommand = new Command(async () => await Shell.Current.GoToAsync("locations"));
        FilterItems();
    }

    private void FilterItems()
    {
        VisibleItems.Clear();
        foreach (var item in allItems.Where(x => selectedCategory == "All" || x.Category == selectedCategory)) VisibleItems.Add(item);
    }

    private void AddToCart(PastaMenuItem? item)
    {
        if (item is null) return;
        var existing = Cart.FirstOrDefault(x => x.Item.Name == item.Name);
        if (existing is null) Cart.Add(new CartItem(item)); else existing.Increase();
        NotifyCartChanged();
    }

    private void ChangeQuantity(CartItem? item, int change)
    {
        if (item is null) return;
        if (change > 0) item.Increase(); else item.Decrease();
        if (item.Quantity == 0) Cart.Remove(item);
        NotifyCartChanged();
    }

    private void NotifyCartChanged()
    {
        OnPropertyChanged(nameof(Subtotal));
        OnPropertyChanged(nameof(CartCount));
        OnPropertyChanged(nameof(CartSummary));
    }
}
