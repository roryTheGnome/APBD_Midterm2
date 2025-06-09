using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Midterm2.Models;

[Table("MachineProgram")]
public class MachineProgram
{
    [ForeignKey(nameof(WashingMachine))]
    public int MachineId { get; set; }
    
    public WashingMachine WM { get; set; } = null!;
    
    
    
    [ForeignKey(nameof(Program))]
    public int ProgramDefId { get; set; }
    public Program Program { get; set; } = null!;
    
    [Range(0, 25)]
    public double Price { get; set; }
}