
using CareerPortal.Dtos.CompanyDtos;
using CareerPortal.Models;
using Riok.Mapperly.Abstractions;

namespace CareerPortal.Mapping;

[Mapper]
public static partial class CompanyMapper
{
    public static partial CompanyListItemDto toListItemDto(this CompanyListItemDto companyListItemDto);
    public static partial IQueryable<CompanyListItemDto> ProjectToListItemDto(this IQueryable<Company> query);
}