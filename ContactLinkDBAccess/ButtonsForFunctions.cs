/* using System;
using System.Collections.Generic;
using System.Text;

namespace ContactLinkDBAccess
{
    using System;
    using System.Windows.Forms;

    namespace YourNamespace
    {
        public partial class YourForm : Form
        {
            public YourForm()
            {
                InitializeComponent();
            }

            private void UpdateButton_Click(object sender, EventArgs e)
            {
                // Assuming you have textboxes for first name, last name, address, and city
                string firstName = FirstNameTextBox.Text;
                string lastName = LastNameTextBox.Text;
                string address = AddressTextBox.Text;
                string city = CityTextBox.Text;

                // Call the UpdateStudent function
                CLOG.UpdateStudent(firstName, lastName, address, city);
            }

            // Other form initialization and design code...

            private void InitializeComponent()
            {
                // Other initialization code...

                // Add a button to your form
                Button updateButton = new Button();
                updateButton.Text = "Update Student";
                updateButton.Click += new EventHandler(UpdateButton_Click);

                // Add other controls as needed...

                // Add controls to the form
                Controls.Add(updateButton);

                // Other layout and design code...
            }
        }
    }

}
*/