using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_Midterm2.Models;

[Table("PurchaseProgram")]
public class PurchaseProgram
{
    [ForeignKey(nameof(Purchase))]
    public int PurchaseId { get; set; }
    
    public Purchase Purchase { get; set; } = null!;

    [ForeignKey(nameof(Program))]
    public int ProgramId { get; set; }
    public Program Program { get; set; } = null!;
}