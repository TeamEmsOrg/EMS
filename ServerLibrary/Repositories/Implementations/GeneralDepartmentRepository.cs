using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations;

public class GeneralDepartmentRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<GeneralDepartment>
{
    public async Task<List<GeneralDepartment>> GetAll()
    {
        return await appDbContext.GeneralDepartments.ToListAsync();
    }

    public async Task<GeneralDepartment> GetById(int id)
    {
        var department = await appDbContext.GeneralDepartments.FindAsync(id);
        if (department is null) return null;
        return department;
    }

    public async Task<GeneralResponse> Insert(GeneralDepartment item)
    {
        if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Item already added");
         appDbContext.GeneralDepartments.Add(item);
         await Commit();
         return new GeneralResponse(true, "Item added successfully");
    }

    public async Task<GeneralResponse> Update(GeneralDepartment item)
    {
        var dep = await appDbContext.GeneralDepartments.FindAsync(item.Id);
        if (dep is null) return NotFound();
         dep.Name = item.Name;
        await Commit();
        return Success();
    }
 public async Task<GeneralResponse> DeleteById(int id)
    {
        var department = await appDbContext.GeneralDepartments.FindAsync(id);
        if (department is null) 
        {
            return new GeneralResponse(false, "Sorry department not found!");
        }
        appDbContext.GeneralDepartments.Remove(department);
        await appDbContext.SaveChangesAsync();
        return new GeneralResponse(true, "Process Completed!");
    }
    

    private static GeneralResponse NotFound() => new GeneralResponse(false, "Sorry department not found!");
    private static GeneralResponse Success() => new GeneralResponse(true, "Process Completed!");
    private async Task Commit() => await appDbContext.SaveChangesAsync();

    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        return item is null;
    }
}