namespace BaseLibrary.Entities;

public class GeneralDepartment : BaseEntity
{
    // One to many relationships
    public List<Department>? Departments { get; set; }
}