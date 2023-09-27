using JobMatchingForGraduates.Data.IRepositories;
using JobMatchingForGraduates.Data.Repositories;
using JobMatchingForGraduates.Domain.Entities;
using JobMatchingForGraduates.Service.DTOs.Students;
using JobMatchingForGraduates.Service.Exceptions;
using JobMatchingForGraduates.Service.Interfaces;

namespace JobMatchingForGraduates.Service.Services;

public class StudentService : IStudentService
{
    private readonly IRepository<Student> studentRepository = new Repository<Student>();

    public async Task<StudentForResultDto> CreateAsync(StudentForCreationDto dto)
    {
        var student = (await this.studentRepository.SelectAllAsync()).FirstOrDefault(u => u.Email.ToLower() == dto.Email.ToLower());
        if (student is not null)
            throw new JobMatchingException(400, "User is already exist");

        var com = new Student()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Direction = dto.Direction,
        };

        var result = await studentRepository.InsertAsync(student);

        var mappedUser = new StudentForResultDto()
        {
            Id = result.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber= dto.PhoneNumber,
            Direction = dto.Direction,
        };

        return mappedUser;
    }

    public async Task<List<StudentForResultDto>> GetAllAsync()
    {
        var students = await this.studentRepository.SelectAllAsync();
        var result = new List<StudentForResultDto>();

        foreach (var student in students)
        {
            var mappedStudent = new StudentForResultDto()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
                Direction = student.Direction,
            };
            result.Add(mappedStudent);
        }
        return result;
    }

    public async Task<StudentForResultDto> GetByIdAsync(long id)
    {
        var student = await this.studentRepository.SelectByIdAsync(id);
        if (student is null)
            throw new JobMatchingException(404, "User is nor found");
        var mappedStudent = new StudentForResultDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            PhoneNumber = student.PhoneNumber,
            Direction = student.Direction,
        };
        return mappedStudent;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var student = await this.studentRepository.SelectByIdAsync(id);
        if (student is null)
            throw new JobMatchingException(404, "User is not found");
        return await this.studentRepository.DeleteAsync(id);
    }

    public async Task<StudentForResultDto> UpdateAsync(StudentForUpdateDto dto)
    {
        var student = await this.studentRepository.SelectByIdAsync(dto.Id);
        if (student is null)
            throw new JobMatchingException(404, "User is not found");

        var mappedStudent = new Student()
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            PhoneNumber = student.PhoneNumber,
            Direction = student.Direction,
        };

        await this.studentRepository.UpdateAsync(mappedStudent);

        var result = new StudentForResultDto()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            Direction = dto.Direction,
        };

        return result; 
    }
}

    


