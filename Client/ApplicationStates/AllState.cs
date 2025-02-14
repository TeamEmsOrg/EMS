namespace Client.ApplicationStates;

public class AllState
{
    public Action? Action { get; set; }
    public bool ShowGeneralDepartment { get; set; }
    public bool ShowDepartment { get; set; }
    public bool ShowBranch { get; set; }
    public bool ShowCity { get; set; }
    public bool ShowCountry { get; set; }
    public bool ShowTown { get; set; }
    public bool ShowEmployee { get; set; }
    public bool ShowUser { get; set; }

    public void GeneralDepartmentClicked()
    {
        ResetGeneralDepartment();
        ShowGeneralDepartment = true;
        Action?.Invoke();
    }

    public void DepartmentClicked()
    {
        ResetGeneralDepartment();
        ShowDepartment = true;
        Action?.Invoke();
    }

    public void BranchClicked()
    {
        ResetGeneralDepartment();
        ShowBranch = true;
        Action?.Invoke();
    }

    public void CountryClicked()
    {
        ResetGeneralDepartment();
        ShowCountry = true;
        Action?.Invoke();
    }

    public void CityClicked()
    {
        ResetGeneralDepartment();
        ShowCity = true;
        Action?.Invoke();
    }

    public void TownClicked()
    {
        ResetGeneralDepartment();
        ShowTown = true;
        Action?.Invoke();
    }

    public void EmployeeClicked()
    {
        ResetGeneralDepartment();
        ShowEmployee = true;
        Action?.Invoke();
    }

    public void UserClicked()
    {
        ResetGeneralDepartment();
        ShowUser = true;
        Action?.Invoke();
    }

    private void ResetGeneralDepartment()
    {
        ShowGeneralDepartment = false;
        ShowBranch = false;
        ShowCity = false;
        ShowCountry = false;
        ShowDepartment = false;
        ShowTown = false;
        ShowUser = false;
        ShowEmployee = false;
    }
}