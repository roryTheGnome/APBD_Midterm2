using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Midterm2.Models;

[Table("Purchase")]
public class Purchase
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public int? Rating { get; set; }

   
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    
    [ForeignKey(nameof(WashingMachine))]
    public int WashingMachineId { get; set; }
    public WashingMachine WashingMachine { get; set; } = null!;

    
    public ICollection<PurchaseProgram> PurchasePrograms { get; set; } = new List<PurchaseProgram>();
}