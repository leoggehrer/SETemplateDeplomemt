//@Ignore
#if DEVELOP_ON && GENERATEDCODE_ON
using SETemplate.Logic.Entities.Develop;
using SETemplate.Logic.Entities.Develop.BaseData;

namespace SETemplate.ConApp
{
    public class ImportItem<T> where T : class
    {
        public required string Id { get; set; }
        public required T Item { get; set; }
    }
    /// <summary>
    /// Provides methods to load data from CSV files.
    /// </summary>
    public static class DataLoader
    {
        #region methods

        /// <summary>
        /// Loads companies from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of import items.</returns>
        public static List<Company> LoadCompaniesFromCsv(string path)
        {
            var result = new List<Company>();

            result.AddRange(File.ReadAllLines(path)
                       .Skip(1)
                       .Select(l => l.Split(';'))
                       .Select(d => new Company 
                       { 
                           Name = d[0], 
                           Address = d[1]
                       }));
            return result;
        }

        /// <summary>
        /// Loads customers from a CSV file.
        /// </summary>
        /// <param name="companies">The list of companies.</param>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of customers.</returns>
        public static List<Customer> LoadCustomersFromCsv(List<Company> companies, string path)
        {
            var result = new List<Customer>();

            result.AddRange(File.ReadAllLines(path)
                       .Skip(1)
                       .Select(l => l.Split(';'))
                       .Select(d => new Customer 
                       { 
                           Company = companies[int.Parse(d[0]) - 1],
                           Name = d[1],
                           Email = d[2],
                       }));
            return result;
        }

        /// <summary>
        /// Loads employees from a CSV file.
        /// </summary>
        /// <param name="companies">The list of companies.</param>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of employees.</returns>
        public static List<Employee> LoadEmployeesFromCsv(List<Company> companies, string path)
        {
            var result = new List<Employee>();

            result.AddRange(File.ReadAllLines(path)
                       .Skip(1)
                       .Select(l => l.Split(';'))
                       .Select(d => new Employee
                       {
                           Company = companies[int.Parse(d[0]) - 1],
                           FirstName = d[1],
                           LastName = d[2],
                           Email = d[3],
                       }));
            return result;
        }
        #endregion methods
    }
}
#endif