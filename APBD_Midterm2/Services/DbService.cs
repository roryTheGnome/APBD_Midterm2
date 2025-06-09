using APBD_Midterm2.Data;
using APBD_Midterm2.DTOs;
using APBD_Midterm2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Midterm2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;
    public DbService(DatabaseContext context) => _context = context;

    public async Task<PurchaseResponseDto> GetCustomerPurchases(int customerId)
    {
        var customer = await _context.Customers
            .Include(c => c.Purchases).ThenInclude(p => p.WashingMachine)
            .Include(c => c.Purchases).ThenInclude(p => p.PurchasePrograms)
                    .ThenInclude(pp => pp.Program)
            .FirstOrDefaultAsync(c => c.Id == customerId);

        if (customer == null) throw new Exception("no such customer exists(at least in the system)");

        return new PurchaseResponseDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = customer.Purchases.Select(p => new PurchaseDto
            {
                Date = p.Date,
                Rating = p.Rating,
                Price = p.Price,
                WashingMachine = new WashingMachineDto
                {
                    Serial = p.WashingMachine.SerialNumber,
                    MaxWeight = p.WashingMachine.MaxWeight
                },
                Program = p.PurchasePrograms.Select(pp => pp.Program).Select(pd => new ProgramDto
                {
                    Name = pd.Name,
                    Duration = pd.Duration
                }).First()
            }).ToList()
        };
    }

    public async Task AddWashingMachineAsync(NewMachineRequest request)
    {
        //check this part one moer time before submit
        if (request.Machine.MaxWeight < 8)
            throw new Exception("light as a feather ,need more weight");

        if (await _context.Machines.AnyAsync(w => w.SerialNumber == request.Machine.SerialNumber))
            throw new Exception("Machine exists");

        var programNames = request.AvailablePrograms.Select(p => p.ProgramName);
        var programs = await _context.Programs.Where(p => programNames.Contains(p.Name)).ToListAsync();

        if (programs.Count != request.AvailablePrograms.Count)
            throw new Exception("program dont exist");

        if (request.AvailablePrograms.Any(p => p.Price > 25))
            throw new Exception("not an exeptiable price");

        var machine = new WashingMachine
        {
            SerialNumber = request.Machine.SerialNumber,
            MaxWeight = request.Machine.MaxWeight
        };

        _context.Machines.Add(machine);
        await _context.SaveChangesAsync();

        foreach (var ap in request.AvailablePrograms)
        {
            var program = programs.First(p => p.Name == ap.ProgramName);
            _context.MachinePrograms.Add(new MachineProgram
            {
                MachineId = machine.Id,
                ProgramDefId = program.Id,
                Price = ap.Price
            });
        }

        await _context.SaveChangesAsync();
    }
}