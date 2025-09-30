namespace Domain;

public class Request
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    
    public string ClientFullName { get; set; }
    public string ClientPhoneNumber { get; set; }
    
    public string PerformerFullName { get; set; } 
    public string Status { get; set; } 
}