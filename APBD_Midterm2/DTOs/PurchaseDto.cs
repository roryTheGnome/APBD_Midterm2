namespace APBD_Midterm2.DTOs;

public class PurchaseDto
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public double Price { get; set; }
    public WashingMachineDto WashingMachine { get; set; } = null!;
    public ProgramDto Program { get; set; } = null!;
}