namespace APBD_Midterm2.DTOs;

public class NewMachineRequest
{
    public MachineInputDto Machine { get; set; } = null!;
    public List<ProgramPriceDto> AvailablePrograms { get; set; } = new();
}