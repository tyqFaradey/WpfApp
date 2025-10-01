using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Domain;

namespace UI;

public partial class EditRequestPage : Page
{   
    public event Action<Request>? RequestEdited;
    
    public EditRequestPage(Request requestToEdit)
    {
        InitializeComponent();
        
        SaveButton.Click += SaveButton_Click;
        CancelButton.Click += CancelButton_Click;

        IdTextBox.Text = requestToEdit.Id.ToString();
        DatePicker.SelectedDate = requestToEdit.Date;
        TypeTextBox.Text = requestToEdit.Type;
        ModelTextBox.Text = requestToEdit.Model;
        DescriptionTextBox.Text = requestToEdit.Description;
        ClientFullNameTextBox.Text = requestToEdit.ClientFullName;
        ClientPhoneNumberTextBox.Text = requestToEdit.ClientPhoneNumber;
        PerformerFullNameTextBox.Text = requestToEdit.PerformerFullName;
        StatusTextBox.Text = requestToEdit.Status;
    }
    
    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {   
        try
        {
            var request = new Request
            {
                Id = int.TryParse(IdTextBox.Text, out int id) ? id : 0,
                Date = DatePicker.SelectedDate ?? DateTime.Now,
                Type = TypeTextBox.Text,
                Model = ModelTextBox.Text,
                Description = DescriptionTextBox.Text,
                ClientFullName = ClientFullNameTextBox.Text,
                ClientPhoneNumber = ClientPhoneNumberTextBox.Text,
                PerformerFullName = PerformerFullNameTextBox.Text,
                Status = StatusTextBox.Text
            };

            RequestEdited?.Invoke(request);

            NavigationService?.GoBack();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при добавлении заявки");
        }
    }
    private void CancelButton_Click(object sender, RoutedEventArgs e)
    { 
        NavigationService?.GoBack();
    }
}