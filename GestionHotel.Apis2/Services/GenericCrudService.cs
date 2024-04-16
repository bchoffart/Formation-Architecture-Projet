namespace GestionHotel.Apis2.Services;

public abstract class GenericCrudService<T> where T : class
{
    
    private readonly DatabaseContext _db = new DatabaseContext();

    public List<T> SelectAll()
    {
        return _db.Set<T>().ToList();
    }
    
    public void Insert(T data)
    {
        _db.Add(data);
        _db.SaveChanges();
    }
}