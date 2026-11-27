namespace PurduePasta;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new View.OrderingPage())
        {
            BarBackgroundColor = Colors.Black,
            BarTextColor = Colors.White
        };
    }
}
