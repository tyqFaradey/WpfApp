using Domain;

namespace Data.Interfaces;

public interface IRequestRepository
{
    int Add(Request request);
    bool Update(Request request);
    bool Delete(int id);
    
    Request? Get(int id);
    List<Request> GetAll();
}