using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace useliqn_Join
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = Employee.GetEmployees();
            List<Department> departments = Department.getDepartments();
            
            double maxSalary = employees.Max(e => e.salary);
            double minSalary = employees.Min(e => e.salary);
            double averageSalary = employees.Average(e => e.salary);

            Console.WriteLine($"Max Salary: {maxSalary}");
            Console.WriteLine($"Min Salary: {minSalary}");
            Console.WriteLine($"Average Salary: {averageSalary}");
            
            var employeeDepartments = from employee in employees
                join department in departments on employee.DepartmentID equals department.ID
                select new
                {
                    EmployeeName = employee.name,
                    DepartmentName = department.name,
                    Salary = employee.salary,
                    Age = employee.age
                };
            
            foreach (var item in employeeDepartments)
            {
                Console.WriteLine($"Employee: {item.EmployeeName}, Department: {item.DepartmentName}, Salary: {item.Salary}, Age: {item.Age}");
            }

        }
        
        
        
        public class Department
        {
            public String name { get; set; }
            public int ID { get; set; }

            public static List<Department> getDepartments()
            {
                return new List<Department>()
                {
                    new Department() { ID = 1, name = "IT" },
                    new Department() { ID = 2, name = "HR" },
                    new Department() { ID = 3, name = "Marketing" }
                };
            }

        }

        public class Employee
        {
            public String name { get; set; }
            public int ID { get; set; }
            public int DepartmentID { get; set; }
            public int age { get; set; }
            public double salary { get; set; }
            public DateTime birthday { get; set; }

            public static List<Employee> GetEmployees()
            {
                return new List<Employee>()
                {
                    new Employee() { ID = 1, name = "A", DepartmentID = 1, age = 18, salary = 500000, birthday = new DateTime(2004, 12, 31) },
                    new Employee() { ID = 2, name = "B", DepartmentID = 2, age = 19, salary = 1500000, birthday = new DateTime(2004, 05, 16) },
                    new Employee() { ID = 3, name = "C", DepartmentID = 3, age = 20, salary = 2500000, birthday = new DateTime(2005, 01, 14) },
                    new Employee() { ID = 4, name = "D", DepartmentID = 4, age = 21, salary = 3500000, birthday = new DateTime(2005, 3, 8) },
                    new Employee() { ID = 5, name = "E", DepartmentID = 5, age = 22, salary = 4500000, birthday = new DateTime(2005, 10, 20) }
                };
            }

        }
    }
}