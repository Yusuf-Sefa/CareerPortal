
using CareerPortal.Dtos.CompanyDtos;
using CareerPortal.Dtos.PagedDtos;
using CareerPortal.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CareerPortal.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _service;

    public CompaniesController(ICompanyService service) => _service =service;


    [HttpGet]
    public async Task<ActionResult<PagedResult<CompanyListItemDto>>> GetPaged([FromQuery] GetCompaniesRequest request, CancellationToken ct)
        => Ok(await _service.GetPagedAsync(request, ct));

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CompanyDto>> GetById(Guid id, CancellationToken ct)
    {
        var company = await _service.GetByIdAsync(id, ct);
        return company is null
            ? NotFound()
            : Ok(company);
    }

    [HttpPut]
    public async Task<ActionResult<CompanyDto>> Create(CreateCompanyRequest request, CancellationToken ct)
    {
        var company = await _service.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new {id = company.Id}, company);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CompanyDto>> Update(Guid id, UpdateCompanyRequest request, CancellationToken ct)
    {
        var company = await _service.UpdateAsync(id, request, ct);        
        return company is null
            ? NotFound()
            : Ok(company);
    }

}