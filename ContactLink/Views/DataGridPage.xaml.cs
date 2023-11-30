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

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }

    private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
    {

    }

    private void Delete(object sender, System.Windows.RoutedEventArgs e)
    {
        DeleteButton.Content = "YAY!";
    }

    private void Add(object sender, System.Windows.RoutedEventArgs e)
    {
        AddButton.Content = "&#xE001;";
    }
}
