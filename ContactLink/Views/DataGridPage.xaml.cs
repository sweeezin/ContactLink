using System.Drawing.Text;
using System.Windows.Controls;

using ContactLink.ViewModels;
using ContactLinkDBAccess;
using Windows.ApplicationModel.Contacts;

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

    private async void Delete(object sender, System.Windows.RoutedEventArgs e)
    {
        int counter = 0;

        foreach (var selectedItem in DataGridDisplay.SelectedItems)
        {
            CLOG selectedContact = selectedItem as CLOG;
            if (selectedContact != null)
            {
                 var id = selectedContact.ID;
                CLOG.DeleteCLOG(id);
            }
            counter++;
        }
        (DataContext as DataGridViewModel).FetchAllStudents();
        if (counter > 1)
        {
            DeleteButton.Content = $"{counter} rows deleted";
        }
        else
        {
            DeleteButton.Content = "Row deleted";
        }
        await Task.Delay(1500);
        DeleteButton.Content = "X";

    }


    private async void Add(object sender, System.Windows.RoutedEventArgs e)
    {
        AddButton.Content = "&#xE001;";
        CLOG.addRow();
        (DataContext as DataGridViewModel).FetchAllStudents();
        await Task.Delay(1500);
        AddButton.Content = "ni";

        

    }
}
