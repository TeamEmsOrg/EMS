namespace BaseLibrary.Entities;

public class Branch : BaseEntity
{
    //many to one relationship: many branches will have one department 
    
    public Department? Department { get; set; }
    public int DepartmentId { get; set; }
    
    //one to many
    public List<Employee>? Employees { get; set; }
}