using Domain;
using Data.Interfaces;

namespace Data.InMemory;

public class Repository : Data.Interfaces.IRequestRepository
{
    private List<Request> _RequestsList;
    private int _nextId = 1;

    public Repository()
    {
        _RequestsList = [];
    } 

    public int Add(Request? request)
    {
        if (request == null) return -1;

        request.Id = _nextId++;
        _RequestsList.Add(request);
        
        return request.Id;
    }

    public bool Update(Request? request)
    {
        if (request == null) return false;
        var existing = _RequestsList.FirstOrDefault(r => r.Id == request.Id);
        if (existing == null) return false;
        
        existing.Date = request.Date;
        existing.Type = request.Type;
        existing.Model = request.Model;
        existing.Description = request.Description;
        existing.ClientFullName = request.ClientFullName;
        existing.ClientPhoneNumber = request.ClientPhoneNumber;
        existing.PerformerFullName = request.PerformerFullName;
        existing.Status = request.Status;

        return true;
    }

    public bool Delete(int id)
    {
        var existing = _RequestsList.FirstOrDefault(r => r.Id == id);
        if (existing == null) return false;
        
        return _RequestsList.Remove(existing);
    }

    public Request? Get(int id)
    {
        return _RequestsList.FirstOrDefault(r => r.Id == id);
    }

    public List<Request> GetAll()
    {
        return _RequestsList.ToList();
    }
}