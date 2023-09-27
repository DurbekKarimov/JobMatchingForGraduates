using JobMatchingForGraduates.Data.IRepositories;
using JobMatchingForGraduates.Data.Repositories;
using JobMatchingForGraduates.Domain.Entities;
using JobMatchingForGraduates.Service.DTOs.Companies;
using JobMatchingForGraduates.Service.Exceptions;
using JobMatchingForGraduates.Service.Interfaces;

namespace JobMatchingForGraduates.Service.Services;

public class CompanyService : ICompanyService
{
    private readonly IRepository<Company> companyRepository = new Repository<Company>();

    public async Task<CompanyForResultDto> CreateAsync(CompanyForCreationDto dto)
    {
        var company = (await this.companyRepository.SelectAllAsync()).FirstOrDefault(c => c.Email.ToLower() == dto.Email.ToLower());
        if (company is not null)
            throw new JobMatchingException(400, "Company is already exsist");
        var person = new Company()
        {
            CompanyName = dto.CompanyName,
            Email = dto.Email,
            Password = dto.Password,
            PhoneNumber = dto.PhoneNumber,
        };

        var result = await companyRepository.InsertAsync(company);

        var mappedCompany = new CompanyForResultDto()
        {
            Id = result.Id,
            CompanyName =  result.CompanyName,
            Email = result.Email,
            Password = result.Password,
            PhoneNumber = result.PhoneNumber,
        };

        return mappedCompany;
    }

    public async Task<List<CompanyForResultDto>> GetAllAsync()
    {
        var companies = await this.companyRepository.SelectAllAsync();
        var result = new List<CompanyForResultDto>();

        foreach (var company in companies)
        {
            var mappedCompany = new CompanyForResultDto()
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                Email = company.Email,
                Password = company.Password,
                PhoneNumber = company.PhoneNumber
            };
            result.Add(mappedCompany);
        }
        return result;
    }

    public async Task<CompanyForResultDto> GetByIdAsync(long id)
    {
        var company = await this.companyRepository.SelectByIdAsync(id);
        if (company is null)
            throw new JobMatchingException(404, "Company is nor found");
        var mappedCompany = new CompanyForResultDto
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            Email = company.Email,
            Password = company.Password,
            PhoneNumber = company.PhoneNumber
        };
        return mappedCompany;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var company = await this.companyRepository.SelectByIdAsync(id);

        if (company is null)
            throw new JobMatchingException(404, "Company is not found");

        return await this.companyRepository.DeleteAsync(id);
    }

    public async Task<CompanyForResultDto> UpdateAsync(CompanyForUpdateDto dto)
    {
        var company = await this.companyRepository.SelectByIdAsync(dto.Id);
        if (company is null)
            throw new JobMatchingException(404, "Company is not null");

        var mappedCompany = new Company()
        {
            Id = company.Id,
            CompanyName = company.CompanyName,
            Email = company.Email,
            Password = company.Password,
            PhoneNumber = company.PhoneNumber
        };
        await this.companyRepository.UpdateAsync(mappedCompany);

        var result = new CompanyForResultDto()
        {
            Id = dto.Id,
            CompanyName = dto.CompanyName,
            PhoneNumber = dto.PhoneNumber
        };
        return result;
    }
}
