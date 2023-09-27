using JobMatchingForGraduates.Presentation.UIs;
using JobMatchingForGraduates.Data.IRepositories;
using JobMatchingForGraduates.Data.Repositories;
using JobMatchingForGraduates.Domain.Commons;
using JobMatchingForGraduates.Domain.Configurations;
using JobMatchingForGraduates.Domain.Entities;
using JobMatchingForGraduates.Service.DTOs;
using JobMatchingForGraduates.Service.Exceptions;
using JobMatchingForGraduates.Service.Interfaces;
using JobMatchingForGraduates.Service.Services;
namespace JobMatchingForGraduates
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
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
            CompanyUI companyUI = new CompanyUI();
            await companyUI.Print();
        }
    }
}