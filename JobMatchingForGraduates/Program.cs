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
using System.Xml;
using JobMatchingForGraduates.Presentation;

namespace JobMatchingForGraduates
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            View view = new View();
            await view.Start();
            //Console.WriteLine("Agar o'quvchi bolib ish qidirmoqchi bolsangiz => 1");
            //Console.WriteLine("Agar siz ishchi olmoqchi bolsangiz => 2");
            //Console.WriteLine("Job center => 3");
            //int num = int.Parse(Console.ReadLine());
            //if (num == 1)
            //{
            //    StudentUI studentUI = new StudentUI();
            //    await studentUI.Print();
            //}
            //else if (num == 2)
            //{
            //    CompanyUI companyUI = new CompanyUI();
            //    await companyUI.Print();
            //}
            //else if (num == 3)
            //{
            //    JobUI jobUI = new JobUI();
            //    //await jobUI.Print();
            //}
            //else
            //    Console.WriteLine("Boshqa xizmatlar mavjud emas !");

        }
    }
}