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
        DeleteButton.Content = "YAY!";
        await Task.Delay(1500);
        DeleteButton.Content = "X";


        foreach (var selectedItem in DataGridDisplay.SelectedItems)
        {
            CLOG selectedContact = selectedItem as CLOG;
            if (selectedContact != null)
            {
                 var id = selectedContact.studentID;
                CLOG.DeleteCLOG(id);
            }
        }

        (DataContext as DataGridViewModel).FetchAllStudents();
    }


    private async void Add(object sender, System.Windows.RoutedEventArgs e)
    {
        AddButton.Content = "&#xE001;";
        CLOG.addRow();
        await Task.Delay(1500);
        AddButton.Content = "ni";

        

    }
}
