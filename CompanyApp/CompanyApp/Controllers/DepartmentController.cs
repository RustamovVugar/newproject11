using DomainLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Controllers
{
    public class DepartmentController
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController()
        {
            _departmentService = new DepartmentService();
        }

        public void Create()
        {

            try
            {
                ConsoleColor.DarkMagenta.WriteConsole("Add department name:");

                string name = Console.ReadLine();

                ConsoleColor.DarkMagenta.WriteConsole("Add department count:");

            Capacity: string capacityStr = Console.ReadLine();

                int capacity;

                bool isParseCapacity = int.TryParse(capacityStr, out capacity);

                if (isParseCapacity)
                {
                    Department department = new()
                    {
                        Name = name,
                        Capacity = capacity,
                    };

                    var result = _departmentService.Create(department);

                    ConsoleColor.Green.WriteConsole($"Id: {result.Id}, Name: {result.Name}, Seat count: {result.Capacity}");

                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct seat count:");
                    goto Capacity;
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }

        }

        public void GetById()
        {
            try
            {
                ConsoleColor.DarkMagenta.WriteConsole("Add department id:");

            Id: string idStr = Console.ReadLine();

                int id;

                bool isParseId = int.TryParse(idStr, out id);

                if (isParseId)
                {
                    var result = _departmentService.GetById(id);
                    if (result is null)
                    {
                        ConsoleColor.Red.WriteConsole("Department notfound, please try again:");
                        goto Id;
                    }

                    ConsoleColor.Green.WriteConsole($"Id: {result.Id}, Name: {result.Name}, Capaciti: {result.Capacity}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id:");
                    goto Id;
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }

        public void Delete()
        {
            ConsoleColor.DarkMagenta.WriteConsole("Add department id:");

        Id: string idStr = Console.ReadLine();

            try
            {
                int id;

                bool isParseId = int.TryParse(idStr, out id);

                if (isParseId)
                {
                    _departmentService.Delete(id);

                    ConsoleColor.Green.WriteConsole($"Successfully deleted");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id:");
                    goto Id;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Id;
            }
        }

        public void Search()
        {
            ConsoleColor.DarkMagenta.WriteConsole("Add department name");

            string searchText = Console.ReadLine();

            var result = _departmentService.Search(searchText);

            foreach (var item in result)
            {
                ConsoleColor.Green.WriteConsole($"Id: {item.Id}, Name: {item.Name}, Seat count: {item.Capacity}");
            }
        }
    }
}
