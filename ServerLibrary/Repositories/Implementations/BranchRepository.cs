using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations;

public class BranchRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Branch>
{
    public async Task<List<Branch>> GetAll()
    {
        return await appDbContext.Branches.ToListAsync();
    }

    public async Task<Branch> GetById(int id)
    {
        return await appDbContext.Branches.FindAsync(id);
    }

    public async Task<GeneralResponse> Insert(Branch item)
    {
        if (!await CheckName(item.Name!)) return new GeneralResponse(false,"Item already exists!"); 
        appDbContext.Branches.Add(item);
        await Commit();
        return Success();
    }

    public async Task<GeneralResponse> Update(Branch item)
    {
        var branch = await appDbContext.Branches.FindAsync(item.Id);
        if (branch is null) return NotFound();
        branch.Name = item.Name;
        await Commit();
        return Success();
    }

    public async Task<GeneralResponse> DeleteById(int id)
    {
        var branch = await appDbContext.Branches.FindAsync(id);
        if (branch is null) return NotFound();
        appDbContext.Branches.Remove(branch);
        await Commit();
        return Success();
    }

    private static GeneralResponse NotFound() => new GeneralResponse(false, "Sorry department not found!");
    private static GeneralResponse Success() => new GeneralResponse(true, "Process Completed!");
    private async Task Commit() => await appDbContext.SaveChangesAsync();

    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Branches.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        return item is null;
    }
}