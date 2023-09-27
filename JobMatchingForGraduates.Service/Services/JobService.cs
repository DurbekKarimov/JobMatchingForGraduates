using JobMatchingForGraduates.Data.IRepositories;
using JobMatchingForGraduates.Data.Repositories;
using JobMatchingForGraduates.Domain.Entities;
using JobMatchingForGraduates.Service.DTOs.Jobs;
using JobMatchingForGraduates.Service.Exceptions;
using JobMatchingForGraduates.Service.Interfaces;

namespace JobMatchingForGraduates.Service.Services;

public class JobService : IJobService
{
    private readonly IRepository<Job> jobRepository = new Repository<Job>();

    public async Task<JobForResultDto> CreateAsync(JobForCreationDto dto)
    {
        var job = (await this.jobRepository.SelectAllAsync()).FirstOrDefault(u => u.JobName.ToLower() == dto.JobName.ToLower());
        if (job is not null)
            throw new JobMatchingException(400, "Job is already exist");

        var com = new Job()
        {
            JobName = dto.JobName,
            Price = dto.Price,
        };

        var result = await jobRepository.InsertAsync(job);

        var mappedUser = new JobForResultDto()
        {
            JobName = result.JobName,
            Price = result.Price,
        };

        return mappedUser;
    }

    public async Task<List<JobForResultDto>> GetAllAsync()
    {
        var jobs = await this.jobRepository.SelectAllAsync();
        var result = new List<JobForResultDto>();

        foreach (var job in jobs)
        {
            var mappedJob = new JobForResultDto()
            {
                Id = job.Id,
                Price= job.Price,
                JobName = job.JobName,
                
            };
            result.Add(mappedJob);
        }

        return result;
    }

    public async Task<JobForResultDto> GetByIdAsync(long id)
    {
        var job = await this.jobRepository.SelectByIdAsync(id);
        if (job is null)
            throw new JobMatchingException(404, "Job is not found");

        var mappedJob = new JobForResultDto()
        {
            Id = job.Id,
            Price = job.Price,
            JobName = job.JobName,

        };

        return mappedJob;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var compaign = await this.jobRepository.SelectByIdAsync(id);
        if (compaign is null)
            throw new JobMatchingException(404, "Job is not found");

        return await this.jobRepository.DeleteAsync(id);
    }

    public async Task<JobForResultDto> UpdateAsync(JobForUpdateDto dto)
    {
        var job = await this.jobRepository.SelectByIdAsync(dto.Id);
        if (job is null)
            throw new JobMatchingException(404, "Job is not found");

        var mappedJob = new Job()
        {
            Id = dto.Id,
            JobName = dto.JobName,
            Price = dto.Price,
        };

        await this.jobRepository.UpdateAsync(mappedJob);

        var result = new JobForResultDto()
        {
            Id = dto.Id,
            JobName = dto.JobName,
            Price= dto.Price,
        };

        return result;

    }
}
