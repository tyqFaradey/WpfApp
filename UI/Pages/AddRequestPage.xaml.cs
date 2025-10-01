using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Domain;

namespace UI;

public partial class AddRequestPage : Page
{
    public event Action<Request>? RequestAdded;
    
    public AddRequestPage()
    {
        InitializeComponent();

        SaveButton.Click += SaveButton_Click;
        CancelButton.Click += CancelButton_Click;
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

            RequestAdded?.Invoke(request);

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