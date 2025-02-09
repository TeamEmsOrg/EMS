using BaseLibrary.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers;

public class CountryController(IGenericRepositoryInterface<Country> genericRepositoryInterface)
    : GenericController<Country>(genericRepositoryInterface)
{
}