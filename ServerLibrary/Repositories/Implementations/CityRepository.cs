using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations;

public class CityRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<City>
{
    public async Task<List<City>> GetAll()
    {
        return await appDbContext.Cities.ToListAsync();
    }

    public async Task<City> GetById(int id)
    {
        return await appDbContext.Cities.FindAsync(id);
    }
    
    public async Task<GeneralResponse> Insert(City item)
    {
        if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Item already exists!");
        appDbContext.Cities.Add(item);
        await Commit();
        return Success();
    }

    public async Task<GeneralResponse> Update(City item)
    {
        var country = await appDbContext.Cities.FindAsync(item.Id);
        if (country is null) return NotFound();
        country.Name = item.Name;
        await Commit();
        return Success();
    }

    public async Task<GeneralResponse> DeleteById(int id)
    {
        var city = await appDbContext.Cities.FindAsync(id);
        if (city is null) return NotFound();
        appDbContext.Cities.Remove(city);
        await Commit();
        return Success();
    }

    private static GeneralResponse NotFound() => new GeneralResponse(false, "Sorry country not found!");
    private static GeneralResponse Success() => new GeneralResponse(true, "Process Completed!");

    private async Task Commit() => await appDbContext.SaveChangesAsync();

    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Cities.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        return item is null;
    }
}