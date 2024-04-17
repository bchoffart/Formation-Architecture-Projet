using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHotel.Apis2.Models;

public abstract class BaseModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    
}