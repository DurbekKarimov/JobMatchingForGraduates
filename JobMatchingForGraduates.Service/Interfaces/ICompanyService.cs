using JobMatchingForGraduates.Service.DTOs.Companies;

namespace JobMatchingForGraduates.Service.Interfaces;

public interface ICompanyService
{
    public Task<CompanyForResultDto> CreateAsync(CompanyForCreationDto dto);

    public Task<CompanyForResultDto> UpdateAsync(CompanyForUpdateDto dto);

    public Task<bool> RemoveAsync(long id);

    public Task<CompanyForResultDto> GetByIdAsync(long id);

    public Task<List<CompanyForResultDto>> GetAllAsync();
}
