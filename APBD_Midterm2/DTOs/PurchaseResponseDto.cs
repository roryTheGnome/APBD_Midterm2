namespace APBD_Midterm2.DTOs;

public class PurchaseResponseDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public List<PurchaseDto> Purchases { get; set; } = new();
}