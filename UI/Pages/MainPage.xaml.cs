using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

using Domain;

using Data.Interfaces;
using Data.InMemory;

namespace UI;

public partial class MainPage : Page
{
    private readonly IRequestRepository _repository;
    private ObservableCollection<Request> Requests { get; set; }

    public MainPage()
    {
        _repository = new Repository();
        
        InitializeComponent();
        
        Requests = new ObservableCollection<Request>(_repository.GetAll());
        RequestsListView.ItemsSource = Requests;
        
        AddButton.Click += AddButton_Click;
        EditButton.Click += EditButton_Click;
        DeleteButton.Click += DeleteButton_Click;
    }
    
    private void RefreshList()
    {   
        Requests.Clear();
        foreach (var req in _repository.GetAll())
        {
            Requests.Add(req);
        }
    }
    
    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        var addPage = new AddRequestPage();
        addPage.RequestSaved += request =>
        {
            _repository.Add(request);
            RefreshList();
        };

        NavigationService?.Navigate(addPage);
    }
    
    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (RequestsListView.SelectedItem is not Request selected) return;
        
        var editPage = new EditRequestPage(selected);
        editPage.RequestSaved += request =>
        {
            _repository.Update(request);
            RefreshList();
        };

        NavigationService?.Navigate(editPage);
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (RequestsListView.SelectedItem is not Request selected) return;
        
        Console.WriteLine(123);
        
        _repository.Delete(selected.Id);
        RefreshList();
    }
}