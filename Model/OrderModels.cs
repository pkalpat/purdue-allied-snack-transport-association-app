namespace PurduePasta.Model;

public sealed class MenuItem
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string Emoji { get; init; } = "🍴";
    public decimal Price { get; init; }
    public bool IsPopular { get; init; }
}

public sealed class CartItem : BindableBase
{
    public MenuItem Item { get; }
    public int Quantity { get; private set; }
    public decimal LineTotal => Item.Price * Quantity;

    public CartItem(MenuItem item)
    {
        Item = item;
        Quantity = 1;
    }

    public void Increase()
    {
        Quantity++;
        OnPropertyChanged(nameof(Quantity));
        OnPropertyChanged(nameof(LineTotal));
    }

    public void Decrease()
    {
        if (Quantity == 0) return;
        Quantity--;
        OnPropertyChanged(nameof(Quantity));
        OnPropertyChanged(nameof(LineTotal));
    }
}

public abstract class BindableBase : System.ComponentModel.INotifyPropertyChanged
{
    public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new(name));
}
