
using CareerPortal.Dtos.CompanyDtos;
using CareerPortal.Dtos.PagedDtos;
using CareerPortal.ExceptionHandlers.Exceptions;
using CareerPortal.Models;
using CareerPortal.Repository.Interfaces;
using CareerPortal.Repository.Interfaces.ICompany;
using CareerPortal.Services.Interface;
using FluentValidation;

namespace CareerPortal.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;
    private readonly ICompanyQueries _queries;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateCompanyRequest> _createValidator;
    private readonly IValidator<UpdateCompanyRequest> _updateValidator;   
    private readonly IValidator<GetCompaniesRequest> _getPagedValidator;

    public CompanyService(
        ICompanyRepository repository,
        ICompanyQueries queries,
        IUnitOfWork unitOfWork,
        IValidator<CreateCompanyRequest> createValidator,
        IValidator<UpdateCompanyRequest> updateValidator,
        IValidator<GetCompaniesRequest> getPagedValidator)
    {
        _repository = repository;
        _queries = queries;
        _unitOfWork = unitOfWork;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
        _getPagedValidator = getPagedValidator; 
    }


    public Task<CompanyDto?> GetByIdAsync(Guid id, CancellationToken ct)
        => _queries.GetByIdAsync(id, ct);

    public async Task<PagedResult<CompanyListItemDto>> GetPagedAsync(GetCompaniesRequest request, CancellationToken ct)
    {
        await _getPagedValidator.ValidateAndThrowAsync(request, ct);

        return await _queries.GetPagedAsync(request.Search, request.Page, request.PageSize, ct);
    }

    public async Task<CompanyDto> CreateAsync(CreateCompanyRequest request, CancellationToken ct)
    {
        await _createValidator.ValidateAndThrowAsync(request, ct);

        var name = request.Name.Trim();
        if(await _repository.ExistsByNameAsync(name, ct))
            throw new ConflictException($"'{name}' isimli bir şirket zaten var.");

        var company = new Company{Id = Guid.NewGuid()};
        company.UpdateDetails(name, request.Location, request.Description);

        _repository.Add(company);
        await _unitOfWork.SaveChangesAsync(ct);

        return (await _queries.GetByIdAsync(company.Id, ct))!;
    }

    public async Task<CompanyDto?> UpdateAsync(Guid id, UpdateCompanyRequest request, CancellationToken ct)
    {
        await _updateValidator.ValidateAndThrowAsync(request, ct);

        var company = await _repository.GetByIdAsync(id ,ct);
        if (company is null)
            return null;

        var newName = request.Name.Trim();
        var nameChanged = string.Equals(company.Name, newName, StringComparison.OrdinalIgnoreCase);

        if(nameChanged && await _repository.ExistsByNameAsync(newName, ct))
            throw new ConflictException($"'{newName}' isimli bir şirket zaten var.");

        company.UpdateDetails(newName, request.Location, request.Description);
        await _unitOfWork.SaveChangesAsync(ct); 

        return await _queries.GetByIdAsync(id, ct);
    }

}