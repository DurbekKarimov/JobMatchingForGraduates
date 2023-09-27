using JobMatchingForGraduates.Service.DTOs.Companies;
using JobMatchingForGraduates.Service.DTOs.Students;
using JobMatchingForGraduates.Service.Exceptions;
using JobMatchingForGraduates.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMatchingForGraduates.Presentation
{
    public class View
    {
        public async Task Start()
        {
            StudentService studentService = new StudentService();
            StudentForCreationDto studentForCreationDto = new StudentForCreationDto();

            CompanyService companyService = new CompanyService();
            CompanyForCreationDto companyForCreationDto = new CompanyForCreationDto();
            string s = @"
       _         _    _  __  __   _     _  __  __ _        _         _      _                                                           
      | |       | |     |  \/  |       | |       | |    (_)                                                          
      | |  ___  | |__   | \  / |  __ _ | |_  ___ | |__   _  _ __    __ _                                             
  _   | | / _ \ | '_ \  | |\/| | / _` || __|/ __|| '_ \ | || '_ \  / _` |                                            
 | |__| || (_) || |_) | | |  | || (_| || |_| (__ | | | || || | | || (_| |                                            
  \____/  \___/ |_.__/  |_|  |_| \__,_| \__|\___||_| |_||_||_| |_| \__, |                                            
                                                                    __/ |                                            
  ______              _____        _  _                        ____|___/              _                _             
 |  ____|            / ____|      | || |                      / ____|                | |              | |            
 | |__  ___   _ __  | |      ___  | || |  __ _   __ _   ___  | |  __  _ __  __ _   __| | _   _   __ _ | |_  ___  ___ 
 |  __|/ _ \ | '__| | |     / _ \ | || | / _` | / _` | / _ \ | | |_ || '__|/ _` | / _` || | | | / _` || __|/ _ \/ __|
 | |  | (_) || |    | |____| (_) || || || (_| || (_| ||  __/ | |__| || |  | (_| || (_| || |_| || (_| || |_|  __/\__ \
 |_|   \___/ |_|     \_____|\___/ |_||_| \__,_| \__, | \___|  \_____||_|   \__,_| \__,_| \__,_| \__,_| \__|\___||___/
                                                 __/ |                                                               
                                                |___/                                                               
";

            Console.WriteLine(s);

            Console.WriteLine("Agar o'quvchi bolib ish qidirmoqchi bolsangiz => 1");
            Console.WriteLine("Agar siz ishchi olmoqchi bolsangiz => 2");
            Console.WriteLine("Job center => 3");
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {

                bool a = true;
                while (a)
                {
                    Console.WriteLine("1 => Sign up");
                    Console.WriteLine("2 => Update information");
                    Console.WriteLine("3 => Detele information");
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
                    }
                }
            }
        }
    }
}