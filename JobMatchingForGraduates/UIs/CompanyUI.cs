using JobMatchingForGraduates.Service.DTOs.Companies;
using JobMatchingForGraduates.Service.DTOs.Students;
using JobMatchingForGraduates.Service.Exceptions;
using JobMatchingForGraduates.Service.Interfaces;
using JobMatchingForGraduates.Service.Services;

namespace JobMatchingForGraduates.Presentation.UIs;

public class CompanyUI
{
    CompanyService companyService = new CompanyService();
    CompanyForCreationDto companyForCreationDto = new CompanyForCreationDto();

    public async Task Print()
    {
        bool a = true;
        while (a)
        {
            Console.WriteLine("1 => Create");
            Console.WriteLine("2 => Update");
            Console.WriteLine("3 => Detele");
            Console.WriteLine("4 => GetById");
            Console.WriteLine("5 => GetAll");
            Console.WriteLine("6 => ExitProgram");
            int num = int.Parse(Console.ReadLine());
            switch (num)
            {
                case 1:
                    try
                    {
                        CompanyForCreationDto dto = new CompanyForCreationDto();
                        ICompanyService companyService = new CompanyService();
                        Console.Write("Enter the  name: ");
                        dto.CompanyName = Console.ReadLine();
                        Console.Write("Enter the email : ");
                        dto.Email = Console.ReadLine();
                        Console.Write("Enter the phone number: ");
                        dto.PhoneNumber = Console.ReadLine();
                        Console.Write("Enter the password: ");
                        dto.Password = Console.ReadLine();
                        var result = await companyService.CreateAsync(dto);

                        Console.WriteLine($"{result.Id} | {result.CompanyName} | {result.PhoneNumber} | {result.Email}");
                    }
                    catch (JobMatchingException ex)
                    {
                        Console.WriteLine($"{ex.StatusCode}  {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;
                case 2:
                    try
                    {
                        CompanyForCreationDto dto = new CompanyForCreationDto();
                        Console.Write("Enter the id :");
                        long Id = long.Parse(Console.ReadLine());
                        Console.Write("Enter the  name: ");
                        dto.CompanyName = Console.ReadLine();
                        Console.Write("Enter the email : ");
                        dto.Email = Console.ReadLine();
                        Console.Write("Enter the phone number: ");
                        dto.PhoneNumber = Console.ReadLine();
                        Console.Write("Enter the password: ");
                        dto.Password = Console.ReadLine();
                       // CompanyForResultDto result = await companyService.UpdateAsync(dto);
                        Console.Clear();
                        //Console.WriteLine($"{result.Id} | {result.FirstName} |{result.LastName} | {result.Direction} | {result.PhoneNumber}");
                    }
                    catch (JobMatchingException exp)
                    {

                        Console.WriteLine($"{exp.StatusCode}   {exp.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 3:
                    try
                    {
                        Console.Write("Enter the id: ");
                        long id = long.Parse(Console.ReadLine());
                        var result = await companyService.RemoveAsync(id);
                    }
                    catch (JobMatchingException exp)
                    {
                        Console.WriteLine($"{exp.StatusCode}   {exp.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 4:
                    try
                    {
                        Console.Write("Enter the id : ");
                        long id4 = long.Parse(Console.ReadLine());
                        CompanyForResultDto student = await companyService.GetByIdAsync(id4);
                    }
                    catch (JobMatchingException exp)
                    {

                        Console.WriteLine($"{exp.StatusCode}   {exp.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 5:
                    try
                    {
                        List<CompanyForResultDto> companies = await companyService.GetAllAsync();
                        foreach (CompanyForResultDto company in companies)
                        {
                            Console.WriteLine($"{company.Id} | {company.Email} |{company.CompanyName} | {company.Password} | {company.PhoneNumber}");
                        }
                    }
                    catch (JobMatchingException exp)
                    {

                        Console.WriteLine($"{exp.StatusCode}   {exp.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 6:
                    a = false;
                    break;
            }

        }
    }
}
