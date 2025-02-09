using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers;

public class DepartmentController(IGenericRepositoryInterface<Department> genericRepositoryInterface)
    : GenericController<Department>(genericRepositoryInterface)
{
}