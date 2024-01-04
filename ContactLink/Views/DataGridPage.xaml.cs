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
                 var id = selectedContact.studentID;
                CLOG.DeleteCLOG(id);
            }
        }

        (DataContext as DataGridViewModel).FetchAllStudents();
    }


    private void Add(object sender, System.Windows.RoutedEventArgs e)
    {

    }

    private void DataGridDisplay_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        DeleteButton.Content = "YAY!";
        await Task.Delay(1500);
        DeleteButton.Content = "X";

        CLOG selectedContact = (CLOG)e.Row.DataContext;

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

        // Now you can use the 'editedContact', 'editedColumn', and 'newCellValue'
        // to update your data or perform any other actions based on the cell edit.

        CLOG.UpdateServer(studentID, lastName, firstName, email, number, profession, "role", organization, mentor_experience, recieved_from, LCD);

    }

    private void SetRenderTransformOrigin(UIElement element, double x, double y)
    {
        if (element.RenderTransform is TransformGroup transformGroup)
        {
            // If there is a TransformGroup, add a new RotateTransform and set its CenterX and CenterY
            var rotateTransform = new RotateTransform();
            rotateTransform.CenterX = x;
            rotateTransform.CenterY = y;

            transformGroup.Children.Add(rotateTransform);
        }
        else
        {
            // If there is no TransformGroup, create a new one with a RotateTransform
            var transformGroup2 = new TransformGroup();
            var rotateTransform = new RotateTransform();
            rotateTransform.CenterX = x;
            rotateTransform.CenterY = y;

            transformGroup2.Children.Add(rotateTransform);
            element.RenderTransform = transformGroup2;
        }
    }

    private void DropdownMenuClicked(object sender, System.Windows.RoutedEventArgs e)
    {

        MenuOpen = !MenuOpen;

        if (MenuOpen)
        {
            System.Windows.Thickness buttonMargin = new System.Windows.Thickness(0, 0, 145, 29);

            HorizontalDropdown.Margin = buttonMargin;

            AddButton.Visibility = System.Windows.Visibility.Visible;
            DeleteButton.Visibility = System.Windows.Visibility.Visible;
            OpenFrame.Visibility = System.Windows.Visibility.Visible;
            ClosedFrame.Visibility = System.Windows.Visibility.Hidden;

            RotateTransform rotateTransform = new RotateTransform(180);

            HorizontalDropdown.RenderTransform = rotateTransform;
            SetRenderTransformOrigin(HorizontalDropdown, 0.5, 0.5);


        }
        else
        {
            System.Windows.Thickness buttonMargin = new System.Windows.Thickness(0, 0, 59, 29);

            HorizontalDropdown.Margin = buttonMargin;

            AddButton.Visibility = System.Windows.Visibility.Hidden;
            DeleteButton.Visibility = System.Windows.Visibility.Hidden;
            OpenFrame.Visibility = System.Windows.Visibility.Hidden;
            ClosedFrame.Visibility = System.Windows.Visibility.Visible;

            RotateTransform rotateTransform = new RotateTransform();
            rotateTransform.Angle += 180;

            HorizontalDropdown.RenderTransform = rotateTransform;

            SetRenderTransformOrigin(HorizontalDropdown, 0.5, 0.5);

        }

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
