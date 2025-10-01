using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Domain;

namespace UI;

public partial class EditRequestPage : Page
{   
    public event Action<Request>? RequestSaved;
    
    public EditRequestPage(Request request)
    {
        InitializeComponent();
        
        IdTextBox.Text = request.Id.ToString();
        DatePicker.SelectedDate = request.Date;
        TypeTextBox.Text = request.Type;
        ModelTextBox.Text = request.Model;
        DescriptionTextBox.Text = request.Description;
        ClientFullNameTextBox.Text = request.ClientFullName;
        ClientPhoneNumberTextBox.Text = request.ClientPhoneNumber;
        PerformerFullNameTextBox.Text = request.PerformerFullName;
        StatusTextBox.Text = request.Status;
        
        SaveButton.Click += SaveButton_Click;
        CancelButton.Click += CancelButton_Click;
    }
    
    private void SaveButton_Click(object sender, RoutedEventArgs e)
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

        RequestSaved?.Invoke(request);
        NavigationService?.GoBack();
    }
    private void CancelButton_Click(object sender, RoutedEventArgs e)
    { 
        NavigationService?.GoBack();
    }
}