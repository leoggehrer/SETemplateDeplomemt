//@Ignore
#if DEVELOP_ON && GENERATEDCODE_ON
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace SETemplate.ConApp
{
    partial class Program
    {
        struct MenuItem
        {
            public int Index { get; set; }
            public Action<Logic.Contracts.IContext> Action { get; set; }
        }
        private static readonly List<MenuItem> _menuItems = [];
        /// <summary>
        /// Creates the menu with available actions.
        /// </summary>
        /// <param name="index">The starting index for the menu items.</param>
        static partial void CreateMenu(ref int index)
        {
            static void action(Logic.Contracts.IContext ctx, Action<Logic.Contracts.IContext> subAction)
            {
                subAction(ctx);
                Console.WriteLine();
                Console.Write("Continue with Enter...");
                Console.ReadLine();
            }

            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => action(ctx, PrintCompanyEmployees) });
            Console.WriteLine($"{nameof(PrintCompanyies),-25}....{index++}");
            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => action(ctx, PrintCompanyies) });
            Console.WriteLine($"{nameof(PrintCompanyies),-25}....{index++}");
            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => action(ctx, QueryCompanies) });
            Console.WriteLine($"{nameof(QueryCompanies),-25}....{index++}");
            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => AddCompany(ctx) });
            Console.WriteLine($"{nameof(AddCompany),-25}....{index++}");
            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => DeleteCompany(ctx) });
            Console.WriteLine($"{nameof(DeleteCompany),-25}....{index++}");

            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => action(ctx, PrintCustomers) });
            Console.WriteLine($"{nameof(PrintCustomers),-25}....{index++}");
            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => action(ctx, QueryCustomers) });
            Console.WriteLine($"{nameof(QueryCustomers),-25}....{index++}");
            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => AddCustomer(ctx) });
            Console.WriteLine($"{nameof(AddCustomer),-25}....{index++}");
            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => DeleteCustomer(ctx) });
            Console.WriteLine($"{nameof(DeleteCustomer),-25}....{index++}");

            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => action(ctx, PrintEmployees) });
            Console.WriteLine($"{nameof(PrintEmployees),-25}....{index++}");
            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => action(ctx, QueryEmployees) });
            Console.WriteLine($"{nameof(QueryEmployees),-25}....{index++}");
            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => AddEmployee(ctx) });
            Console.WriteLine($"{nameof(AddEmployee),-25}....{index++}");
            _menuItems.Add(new MenuItem { Index = index, Action = (ctx) => DeleteEmployee(ctx) });
            Console.WriteLine($"{nameof(DeleteEmployee),-25}....{index++}");
        }

        /// <summary>
        /// Executes the selected menu item action.
        /// </summary>
        /// <param name="choice">The menu item choice.</param>
        /// <param name="context">The database context.</param>
        static partial void ExecuteMenuItem(int choice, Logic.Contracts.IContext context)
        {
            if (choice > 1 && choice <= _menuItems.Count)
            {
                _menuItems[choice - 2].Action(context);
            }
        }
        /// <summary>
        /// Prints all companies in the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void PrintCompanyies(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Companies:");
            Console.WriteLine("----------");

            foreach (var company in context.CompanySet.AsNoTrackingSet().Include(e => e.Customers))
            {
                Console.WriteLine($"{company}");
                foreach (var customer in company.Customers ?? [])
                {
                    Console.WriteLine($"\t{customer}");
                }
            }
        }

        /// <summary>
        /// Prints all companies in the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void PrintCompanyEmployees(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Company -> Employees:");
            Console.WriteLine("---------------------");

            foreach (var CompanyEmployee in context.CompanyEmployeeSet.AsNoTrackingSet())
            {
                Console.WriteLine($"{CompanyEmployee}");
            }
        }

        /// <summary>
        /// Queries companies based on a user-provided condition.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void QueryCompanies(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Query-Companies:");
            Console.WriteLine("----------------");

            Console.Write("Query: ");
            var query = Console.ReadLine()!;

            try
            {
                foreach (var company in context.CompanySet.AsNoTrackingSet().Where(query).Include(e => e.Customers))
                {
                    Console.WriteLine($"{company}");
                    foreach (var customer in company.Customers ?? [])
                    {
                        Console.WriteLine($"{customer}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new company to the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void AddCompany(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Add company:");
            Console.WriteLine("------------");

            var company = new Logic.Entities.Develop.Company();

            Console.Write("Name [256]:          ");
            company.Name = Console.ReadLine()!;
            Console.Write("Adresse [1024]:      ");
            company.Address = Console.ReadLine()!;
            Console.Write("Beschreibung [1024]: ");
            company.Description = Console.ReadLine()!;

            context.CompanySet.Add(company);
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes a company from the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void DeleteCompany(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Delete company:");
            Console.WriteLine("---------------");

            Console.WriteLine();
            Console.Write("Name: ");
            var name = Console.ReadLine()!;
            var entity = context.CompanySet.AsQuerySet().FirstOrDefault(e => e.Name == name);

            if (entity != null)
            {
                try
                {
                    context.CompanySet.Remove(entity);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Continue with enter...");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Prints all employees in the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void PrintCustomers(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Customers:");
            Console.WriteLine("----------");

            foreach (var item in context.CustomerSet.AsNoTrackingSet())
            {
                Console.WriteLine($"{item}");
            }
        }

        /// <summary>
        /// Queries employees based on a user-provided condition.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void QueryCustomers(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Query-Customers:");
            Console.WriteLine("----------------");

            Console.Write("Query: ");
            var query = Console.ReadLine()!;

            try
            {
                foreach (var customer in context.CustomerSet.AsNoTrackingSet().Where(query).Include(e => e.Company))
                {
                    Console.WriteLine($"{customer} - {customer.Company?.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new employee to the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void AddCustomer(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Add customer:");
            Console.WriteLine("------------");

            var customer = new Logic.Entities.Develop.Customer();

            Console.Write("Name [256]:   ");
            customer.Name = Console.ReadLine()!;
            Console.Write("Email [1024]: ");
            customer.Email = Console.ReadLine()!;
            Console.Write("Company name: ");
            var count = 0;
            var companyName = Console.ReadLine()!;
            var company = context.CompanySet.AsQuerySet().FirstOrDefault(x => x.Name == companyName);

            while (company == null && count < 3)
            {
                count++;

                Console.Write("Company name: ");
                companyName = Console.ReadLine()!;
                company = context.CompanySet.AsQuerySet().FirstOrDefault(x => x.Name == companyName);
            }
            try
            {
                if (company != null)
                {
                    customer.CompanyId = company.Id;
                    context.CustomerSet.Add(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Continue with enter...");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Deletes an employee from the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void DeleteCustomer(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Delete customer:");
            Console.WriteLine("----------------");

            Console.WriteLine();
            Console.Write("Email: ");
            var email = Console.ReadLine()!;
            var entity = context.CustomerSet.AsQuerySet().FirstOrDefault(e => e.Email == email);

            if (entity != null)
            {
                try
                {
                    context.CustomerSet.Remove(entity);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Continue with enter...");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// Prints all employees in the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void PrintEmployees(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Employees:");
            Console.WriteLine("----------");

            foreach (var item in context.EmployeeSet.AsNoTrackingSet())
            {
                Console.WriteLine($"{item}");
            }
        }

        /// <summary>
        /// Queries employees based on a user-provided condition.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void QueryEmployees(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Query-Employees:");
            Console.WriteLine("----------------");

            Console.Write("Query: ");
            var query = Console.ReadLine()!;

            try
            {
                foreach (var item in context.EmployeeSet.AsNoTrackingSet().Where(query).Include(e => e.Company))
                {
                    Console.WriteLine($"{item} - {item.Company?.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new employee to the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void AddEmployee(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Add Employee:");
            Console.WriteLine("-------------");

            var Employee = new Logic.Entities.Develop.BaseData.Employee();

            Console.Write("Firstname [256]:   ");
            Employee.FirstName = Console.ReadLine()!;
            Console.Write("Lastname [256]:   ");
            Employee.LastName = Console.ReadLine()!;
            Console.Write("Email [1024]: ");
            Employee.Email = Console.ReadLine()!;
            Console.Write("Company name: ");
            var count = 0;
            var companyName = Console.ReadLine()!;
            var company = context.CompanySet.AsQuerySet().FirstOrDefault(x => x.Name == companyName);

            while (company == null && count < 3)
            {
                count++;

                Console.Write("Company name: ");
                companyName = Console.ReadLine()!;
                company = context.CompanySet.AsQuerySet().FirstOrDefault(x => x.Name == companyName);
            }
            try
            {
                if (company != null)
                {
                    Employee.CompanyId = company.Id;
                    context.EmployeeSet.Add(Employee);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Write("Continue with enter...");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Deletes an employee from the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void DeleteEmployee(Logic.Contracts.IContext context)
        {
            Console.WriteLine();
            Console.WriteLine("Delete Employee:");
            Console.WriteLine("----------------");

            Console.WriteLine();
            Console.Write("Email: ");
            var email = Console.ReadLine()!;
            var entity = context.EmployeeSet.AsQuerySet().FirstOrDefault(e => e.Email == email);

            if (entity != null)
            {
                try
                {
                    context.EmployeeSet.Remove(entity);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Continue with enter...");
                    Console.ReadLine();
                }
            }
        }

        static partial void ImportData()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
            using var context = CreateContext();

            var companies = DataLoader.LoadCompaniesFromCsv(Path.Combine(path, "Data", "companies.csv"));

            context.CompanySet.AddRange(companies);
            context.SaveChanges();

            var customers = DataLoader.LoadCustomersFromCsv(companies, Path.Combine(path, "Data", "customers.csv"));
            
            context.CustomerSet.AddRange(customers);
            context.SaveChanges();

            var employees = DataLoader.LoadEmployeesFromCsv(companies, Path.Combine(path, "Data", "employees.csv"));
            context.EmployeeSet.AddRange(employees);

            context.SaveChanges();
        }
    }
}
#endif