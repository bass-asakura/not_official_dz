namespace test_class;

public class Employee
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }

    public Employee(string name, string id, string department, string position)
    {
        Id = id;
        Name = name;
        Department = department;
        Position = position;
    }
}

// Класс для работы с данными
public class Employees
{
    private List<Employee> _listEmployees;
    
    public Employees(List<Employee> listEmployees)
    {
        _listEmployees = listEmployees;
    }
    
    public Employee FindEmployeeById(string id)
    {
        foreach (Employee chel in _listEmployees)
        {
            if(chel.Id == id)
            {
                return chel;

            }
        }
        return null;
       
    }
    
    public Employee AddEmployee()
    {
        Console.WriteLine("Введите имя");
        string name = Console.ReadLine();

        Console.WriteLine("Введите ID");
        string ID_add = Console.ReadLine();

        Console.WriteLine("Введите департамент");
        string depar = Console.ReadLine();
        
        Console.WriteLine("Введите должность");
        string pos = Console.ReadLine();

        Employee test = new Employee(name, ID_add, depar, pos);
        
        return test;
    }
    
    public void UpdateEmployee()
    {
        Console.WriteLine("Введите ID сотрудника");
        string write_id = Console.ReadLine();
        Employee chel = FindEmployeeById(write_id);
        if (chel != null)
        {
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите департамент");
            string depar = Console.ReadLine();
            
            Console.WriteLine("Введите должность");
            string pos = Console.ReadLine();

            chel.Name = name;
            chel.Department = depar;
            chel.Position = pos;
            Console.WriteLine("Данные изменены");
        }
        else
        {
            Console.WriteLine("Нет такого ID");
        }
    }
    
    public void RemoveEmployee()
    {
        Console.WriteLine("Введите ID");
        string id_remove = Console.ReadLine();
        for (int i = 0; i < _listEmployees.Count; i++)
        {
            if (_listEmployees[i].Id == id_remove)
            {
                _listEmployees.Remove(_listEmployees[i]);
                Console.WriteLine("Рабочий удален");
            }
        }
    }
}



public class Program
{   
    public static void Main()
    {    
        Employee employee1 = new Employee("Сьюзан Майерс","47899","Бухгалтерия","Вице-президент");
        Employee employee2 = new Employee("bob", "666", "office", "plancton");
        Employee employee3 = new Employee("ananas","1337","Бухгалтерия","президент");

        List<Employee> employees = new List<Employee> {employee1, employee2, employee3};

        Console.WriteLine("1. Найти сотрудника по идентификационному номеру");
        Console.WriteLine("2. Добавить нового сотрудника");
        Console.WriteLine("3. Изменить имя, отдел и должность существующего сотрудника");
        Console.WriteLine("4. Удалить сотрудника");
        Console.WriteLine("0. Выйти из программы");


        Employees emploeesList = new Employees(employees);
        bool flag = true;
        while (flag)
        {
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введите ID");
                    string id = Console.ReadLine();

                    Employee chel = emploeesList.FindEmployeeById(id);
                    if (chel != null)
                    {
                        Console.WriteLine($"Имя - {chel.Name}, департамент - {chel.Department}, должность - {chel.Position}");
                    }
                    else
                    {
                        Console.WriteLine($"ПОльзователя c ID - {id} нет");
                    }
                    break;
                case "2":
                    Employee temp = emploeesList.AddEmployee();
                    employees.Add(temp);
                    break;
                case "3":
                    emploeesList.UpdateEmployee();
                    break;
                case "4":
                    emploeesList.RemoveEmployee();
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Неверное значение");
                    break;
            
            }
        }
    }
}