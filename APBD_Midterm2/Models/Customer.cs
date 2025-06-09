using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Midterm2.Models;

[Table("Customer")]
public class Customer
{
    //I didnt want to name this one CustomerId but if i must use CustemorId then i should use [Key]
    //and used it as an example in another class but not in them all, hope that okay
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    public string LastName { get; set; } = null!;
    
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }
    
    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}