using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations;

public class DepartmentRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Department>
{
    public async Task<List<Department>> GetAll()
    {
        return await appDbContext.Departments.ToListAsync();
    }

    public async Task<Department> GetById(int id)
    {
        return await appDbContext.Departments.FindAsync(id);
    }

    public async Task<GeneralResponse> Insert(Department item)
    {
        if (!await CheckName(item.Name!)) return NotFound();
        appDbContext.Departments.Add(item);
        await Commit();
        return Success();
    }

    public async Task<GeneralResponse> Update(Department item)
    {
        var department = await appDbContext.Departments.FindAsync(item.Id);
        if (department is null) return NotFound();

        department.Name = item.Name;
        await Commit();
        return Success();
    }

    public async Task<GeneralResponse> DeleteById(int id)
    {
        var department = await appDbContext.Departments.FindAsync(id);
        if (department is null) return NotFound();
        appDbContext.Departments.Remove(department);
        await Commit();
        return Success();
    }

    private static GeneralResponse NotFound() => new GeneralResponse(false, "Sorry department not found!");
    private static GeneralResponse Success() => new GeneralResponse(true, "Process completed!");

    private async Task Commit() => await appDbContext.SaveChangesAsync();

    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Departments.FirstOrDefaultAsync(x => x.Name.ToLower().Equals(name.ToLower()));
        return item is null;
    }
}