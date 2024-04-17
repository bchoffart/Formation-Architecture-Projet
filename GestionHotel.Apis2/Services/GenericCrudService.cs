using GestionHotel.Apis2.Models;

namespace GestionHotel.Apis2.Services;

// TO-DO : Create partial classes for interfaces
public abstract class GenericCrudService<T> where T : BaseModel
{
    
    private readonly DatabaseContext _db = new DatabaseContext();
    
    public List<T?> SelectAll()
    {
        return _db.Set<T>().ToList();
    }
    
    public List<T?> Select(Predicate<T?> predicate)
    {
        return this.SelectAll().FindAll(predicate);
    }
    
    public T? SelectById(string id)
    {
        return this.SelectAll().Find(r => r.Id == id);
    }
    
    public void Insert(T data)
    {
        _db.Add(data);
        _db.SaveChanges();
    }

    public void Update(T data)
    {
        _db.Update(data);
        _db.SaveChanges();
    }
    
    public void UpdateById(string Id, T data)
    {
        var retrievedRow = this.Select(t => t.Id == Id);
        if (retrievedRow.Count != 1) return;
        _db.Update(data);
        _db.SaveChanges();
    }
    
    public void Delete(T data)
    {
        _db.Remove(data);
        _db.SaveChanges();
    }

    public void SaveDatabase()
    {
        _db.SaveChanges();
    }
}