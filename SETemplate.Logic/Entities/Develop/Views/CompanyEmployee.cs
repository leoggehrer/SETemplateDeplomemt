//@Ignore

namespace SETemplate.Logic.Entities.Develop.Views
{
    public partial class CompanyEmployee : ViewObject
    {
        #region properties
        public Guid CompanyGuid { get; set; }
        public Guid EmployeeGuid { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        #endregion properties
    }
}
