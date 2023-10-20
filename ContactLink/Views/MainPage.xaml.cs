using System.Windows.Controls;

using ContactLink.ViewModels;

namespace ContactLink.Views;

public partial class MainPage : Page
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
