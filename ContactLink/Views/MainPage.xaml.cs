using System.Windows.Controls;

using pleasework.ViewModels;

namespace pleasework.Views;

public partial class MainPage : Page
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
