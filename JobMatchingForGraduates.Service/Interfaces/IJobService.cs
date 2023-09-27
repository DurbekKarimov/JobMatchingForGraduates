using JobMatchingForGraduates.Service.DTOs.Jobs;

namespace JobMatchingForGraduates.Service.Interfaces;

public interface IJobService
{
    public Task<JobForResultDto> CreateAsync(JobForCreationDto dto);

    public Task<JobForResultDto> UpdateAsync(JobForUpdateDto dto);

    public Task<bool> RemoveAsync(long id);

    public Task<JobForResultDto> GetByIdAsync(long id);

    public Task<List<JobForResultDto>> GetAllAsync();
}
