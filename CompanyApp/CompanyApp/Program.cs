using CompanyApp.Controllers;
using ServiceLayer.Helpers;

DepartmentController departmentController = new();

while (true)
{
    GetMenues();

SelectOption: string option = Console.ReadLine();

    int selectedOption;

    bool isParseOption = int.TryParse(option, out selectedOption);

    if (isParseOption)
    {
        switch (selectedOption)
        {
            case 1:
                departmentController.Create();
                break;
            case 2:
                departmentController.GetById();
                break;
            case 3:
                departmentController.Delete();
                break;
            case 4:
                departmentController.Search();
                break;
            default:
                Console.WriteLine("Select again true option:");
                goto SelectOption;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Select again true option:");
        goto SelectOption;
    }

}


static void GetMenues()
{
    ConsoleColor.Blue.WriteConsole("Select one option:");
    ConsoleColor.Blue.WriteConsole("Department options: 1 - Create, 2 - Get by id, 3 - Delete, 4 - Search");
}
