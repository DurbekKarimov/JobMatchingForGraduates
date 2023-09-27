using JobMatchingForGraduates.Service.DTOs.Students;

namespace JobMatchingForGraduates.Service.Interfaces;

public interface IStudentService
{
    public Task<StudentForResultDto> CreateAsync(StudentForCreationDto dto);

    public Task<StudentForResultDto> UpdateAsync(StudentForUpdateDto dto);

    public Task<bool> RemoveAsync(long id);

    public Task<StudentForResultDto> GetByIdAsync(long id);

    public Task<List<StudentForResultDto>> GetAllAsync();
}