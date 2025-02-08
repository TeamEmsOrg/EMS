namespace BaseLibrary.Entities;

public class Department : BaseEntity
{
    //Many Department belongs to one General Department: many to one relationship
    public GeneralDepartment? GeneralDepartment { get; set; }
    public int GeneralDepartmentId { get; set; }
    
        
    //many to one
    public List<Branch>? Branches { get; set; }

}