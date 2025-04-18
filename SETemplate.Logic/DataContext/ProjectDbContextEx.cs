//@Ignore
#if GENERATEDCODE_ON

namespace SETemplate.Logic.DataContext
{
    partial class ProjectDbContext
    {
        static partial void AfterOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Develop.Views.CompanyEmployee>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("CompanyEmployees", "dbo");
            });
        }
    }
}
#endif