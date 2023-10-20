using System.Windows.Controls;

using ContactLink.ViewModels;

namespace ContactLink.Views;

public partial class DataGridPage : Page
{
    public DataGridPage(DataGridViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
