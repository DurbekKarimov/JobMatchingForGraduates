using JobMatchingForGraduates.Service.DTOs.Students;
using JobMatchingForGraduates.Service.Exceptions;
using JobMatchingForGraduates.Service.Interfaces;
using JobMatchingForGraduates.Service.Services;

namespace JobMatchingForGraduates.Presentation.UIs;

public class StudentUI
{
    StudentService studentService = new StudentService();
    StudentForCreationDto studentForCreationDto = new StudentForCreationDto();

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
                        StudentForCreationDto dto = new StudentForCreationDto();
                        Console.Write("Enter the first name: ");
                        dto.FirstName = Console.ReadLine();
                        Console.Write("Enter the last name: ");
                        dto.LastName = Console.ReadLine();
                        Console.Write("Enter the email : ");
                        dto.Email = Console.ReadLine();
                        Console.Write("Enter the student direction: ");
                        dto.Direction = Console.ReadLine();
                        Console.Write("Enter the phone number: ");
                        dto.PhoneNumber = Console.ReadLine();
                        Console.Write("Enter the password: ");
                        dto.Password = Console.ReadLine();
                        var result = await studentService.CreateAsync(dto);

                        Console.WriteLine($"{result.Id} | {result.FirstName} |{result.LastName} | {result.Direction} | {result.PhoneNumber}");
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
                        StudentForCreationDto dto = new StudentForCreationDto();
                        Console.Write("Enter the id :");
                        long Id = long.Parse(Console.ReadLine());
                        Console.Write("Enter the first name: ");
                        dto.FirstName = Console.ReadLine();
                        Console.Write("Enter the last name: ");
                        dto.LastName = Console.ReadLine();
                        Console.Write("Enter the email : ");
                        dto.Email = Console.ReadLine();
                        Console.Write("Enter the student direction: ");
                        dto.Direction = Console.ReadLine();
                        Console.Write("Enter the phone number: ");
                        dto.PhoneNumber = Console.ReadLine();
                        Console.Write("Enter the password: ");
                        dto.Password = Console.ReadLine();
                        // StudentForResultDto result = await studentService.UpdateAsync(dto);
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
                        var result = await studentService.RemoveAsync(id);
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
                        StudentForResultDto student = await studentService.GetByIdAsync(id4);
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
                        List<StudentForResultDto> students = await studentService.GetAllAsync();
                        foreach (StudentForResultDto student in students)
                        {
                            Console.WriteLine($"{student.Id} | {student.FirstName} |{student.LastName} | {student.PhoneNumber} | {student.Direction}");
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
