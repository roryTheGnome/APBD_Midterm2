using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Midterm2.Models;

[Table("Washing_Machine")]
public class WashingMachine
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string SerialNumber { get; set; } = null!;
    public double MaxWeight { get; set; }
    
    public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    
    public ICollection<MachineProgram> MachinePrograms { get; set; } = new List<MachineProgram>();
}