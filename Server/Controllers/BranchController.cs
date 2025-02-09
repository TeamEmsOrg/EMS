using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers;

public class BranchController(IGenericRepositoryInterface<Branch> genericRepositoryInterface)
    : GenericController<Branch>(genericRepositoryInterface)
{
}