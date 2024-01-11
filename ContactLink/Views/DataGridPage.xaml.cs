using System.Windows.Controls;
using System.Windows.Media;
using ContactLink.ViewModels;
using ContactLinkDBAccess;
using Windows.ApplicationModel.Contacts;
using System.Windows;

namespace ContactLink.Views;

public partial class DataGridPage : Page
{
    public DataGridPage(DataGridViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private bool MenuOpen = false;

    private void Delete(object sender, System.Windows.RoutedEventArgs e)
    {

        foreach (var selectedItem in DataGridDisplay.SelectedItems)
        {
            CLOG selectedContact = selectedItem as CLOG;
            if (selectedContact != null)
            {
                 var id = selectedContact.ID;
                CLOG.DeleteCLOG(id);
            }
        }

        (DataContext as DataGridViewModel).FetchAllStudents();
    }


    private void Add(object sender, System.Windows.RoutedEventArgs e)
    {

        CLOG.addRow();

    }

    private void DataGridDisplay_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {

        CLOG selectedContact = (CLOG)e.Row.DataContext;

        string firstName = selectedContact.firstName;
        string lastName = selectedContact.lastName;
        string email = selectedContact.email;
        int studentID = selectedContact.ID;
        string number = selectedContact.number;
        string profession = selectedContact.profession;
        string organization = selectedContact.organization;
        string mentor_experience = selectedContact.mentorExperience;
        string recieved_from = selectedContact.recievedFrom;
        DateTime LCD = selectedContact.lastContactedDate;

        // Now you can use the 'editedContact', 'editedColumn', and 'newCellValue'
        // to update your data or perform any other actions based on the cell edit.

        CLOG.UpdateServer(studentID, lastName, firstName, email, number, profession, "role", organization, mentor_experience, recieved_from, LCD);

    }


    private void DropdownMenuClicked(object sender, System.Windows.RoutedEventArgs e)
    {

        AddButton.Visibility = System.Windows.Visibility.Visible;
        DeleteButton.Visibility = System.Windows.Visibility.Visible;
        OpenFrame.Visibility = System.Windows.Visibility.Visible;
        ClosedFrame.Visibility = System.Windows.Visibility.Hidden;
        HorizontalDropdown2.Visibility = System.Windows.Visibility.Visible;
        HorizontalDropdown.Visibility = System.Windows.Visibility.Hidden;

    }

    private void HorizontalDropdownClicked2(object sender, RoutedEventArgs e)
    {

        AddButton.Visibility = System.Windows.Visibility.Hidden;
        DeleteButton.Visibility = System.Windows.Visibility.Hidden;
        OpenFrame.Visibility = System.Windows.Visibility.Hidden;
        ClosedFrame.Visibility = System.Windows.Visibility.Visible;
        HorizontalDropdown2.Visibility = System.Windows.Visibility.Hidden;
        HorizontalDropdown.Visibility = System.Windows.Visibility.Visible;

    }


    /*
    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedContact = (CLOG)DataGridDisplay.SelectedItem;

        if (DataGridDisplay.SelectedItem != null)
        {
            // Access the data item associated with the selected row
            var newSelectedContact = (CLOG)DataGridDisplay.SelectedItem;

            // Check if the selection has actually changed
            if (selectedContact == null || !selectedContact.Equals(newSelectedContact))
            {
                // The selection has changed, perform your update logic here

                // Now you can use the 'newSelectedContact' object to access the data properties
                string firstName = selectedContact.FirstName;
                string lastName = selectedContact.LastName;
                string email = selectedContact.email;
                int studentID = selectedContact.studentID;
                string number = selectedContact.number;
                string profession = selectedContact.profession;
                string organization = selectedContact.organization;
                string mentor_experience = selectedContact.mentor_experience;
                string recieved_from = selectedContact.recieved_from;
                string LCD = selectedContact.last_contacted_date;

                // Add your logic here to do something with the selected data
                CLOG.UpdateServer(studentID, lastName, firstName, email, number, profession, "role", organization, mentor_experience, recieved_from, LCD);
            }

            // Update the selectedContact for the next comparison
            selectedContact = newSelectedContact;
        }
    }

   */
}
