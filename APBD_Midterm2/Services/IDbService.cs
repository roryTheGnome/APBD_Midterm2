using APBD_Midterm2.DTOs;

namespace APBD_Midterm2.Services;

public interface IDbService
{
    Task<PurchaseResponseDto> GetCustomerPurchases(int customerId);
    Task AddWashingMachineAsync(NewMachineRequest request);
}