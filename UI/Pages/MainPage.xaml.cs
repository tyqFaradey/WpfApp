using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

using Domain;

namespace UI;

public partial class MainPage : Page
{
    private ObservableCollection<Request> Requests = [];

    public MainPage()
    {
        InitializeComponent();
        RequestsListView.ItemsSource = Requests;
        
        AddButton.Click += AddButton_Click;
        EditButton.Click += EditButton_Click;
        DeleteButton.Click += DeleteButton_Click;
    }
    
    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        var addPage = new AddRequestPage();
        addPage.RequestAdded += AddRequest;
        NavigationService?.Navigate(addPage);
    }
    
    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (RequestsListView.SelectedItem is not Request selected) return;
        
        var editPage = new EditRequestPage(selected);
        editPage.RequestEdited += EditRequest;
        NavigationService?.Navigate(editPage);
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        DeleteRequest();
    }
    
    private void AddRequest(Request request) 
    {
        Requests.Add(request);
    }
    private void EditRequest(Request request)
    {
        if (RequestsListView.SelectedItem is not Request selected) return;
        
        selected.Id = request.Id;
        selected.Date = request.Date;
        selected.Type = request.Type;
        selected.Model =  request.Model;
        selected.Description = request.Description;
        selected.ClientFullName = request.ClientFullName;
        selected.ClientPhoneNumber = request.ClientPhoneNumber;
        selected.PerformerFullName = request.PerformerFullName;
        selected.Status = request.Status;
            
        RequestsListView.Items.Refresh();
    }
    private void DeleteRequest()
    {
        if (RequestsListView.SelectedItem is not Request selected) return;
        
        Requests.Remove(selected);
    }
}