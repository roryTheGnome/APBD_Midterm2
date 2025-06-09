using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Midterm2.Models;

[Table("Program")]
public class Program
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    public int Duration { get; set; }
    
    public ICollection<PurchaseProgram> PurchasePrograms { get; set; } = new List<PurchaseProgram>();
    public ICollection<MachineProgram> MachinePrograms { get; set; } = new List<MachineProgram>();
}