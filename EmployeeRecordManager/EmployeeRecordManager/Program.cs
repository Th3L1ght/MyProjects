namespace EmployeeRecordManager
{
    public struct Employee
    {
        public string FullName;
        public string Position;
        public DateTime HireDate;

        public Employee(string fullName, string position, DateTime hireDate)
        {
            this.FullName = fullName;
            this.Position = position;
            this.HireDate = hireDate;
        }
    }

    public class Company
    {
        public List<Employee> Employees = new List<Employee>();

        public Company(List<Employee> employees)
        {
            Employees.AddRange(employees);
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void AddEmployee(string fullName, string position, DateTime hireDate)
        {
            Employee employee = new Employee(fullName, position, hireDate);
            AddEmployee(employee);
        }

        public void FindOldEmployees(int year)
        {
            foreach(Employee person in this.Employees)
            {
                if(person.HireDate < DateTime.Now.AddYears(-year))
                {
                    Console.WriteLine($"Full Name: {person.FullName}");
                    Console.WriteLine($"Position: {person.Position}");
                    Console.WriteLine($"Hire Date: {person.HireDate}\n");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee person1 = new Employee { FullName = "Василенко В'ячеслав Сергійович", Position = ".NET Trainee Developer", HireDate = new DateTime(2020, 11, 15) };
            Employee person2 = new Employee { FullName = "Іванов Іван Іванович", Position = ".NET Trainee Developer", HireDate = new DateTime(2016, 2, 10) };
            Employee person3 = new Employee { FullName = "Петренко Петро Петрович", Position = ".NET Trainee Developer", HireDate = new DateTime(2024, 7, 27) };
            
            List<Employee> employees = new List<Employee> { person1, person2, person3 };
            
            Company company = new Company(employees);
            
            company.FindOldEmployees(1);
        }
    }
}
