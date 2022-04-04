using Practice.Data;

namespace Practice.Helper
{
    public static class Find
    {
        public static string GetEmployeeName(ApplicationDbContext dbContext, string managerid)
        {
            return dbContext.Emplyees.FirstOrDefault(s => s.Id == managerid)?.FirstName;
        }
        public static string GetJobTitle(ApplicationDbContext dbContext, int? jobId)
        {
            return dbContext.Jobs.FirstOrDefault(j=>j.Id == jobId)?.JobTitle;
        }
        public static string GetDepartamentName(ApplicationDbContext dbContext, int? departamentid)
        {
            return dbContext.Departments.FirstOrDefault(s => s.Id == departamentid)?.Name;
        }
        public static string GetRegionName(ApplicationDbContext dbContext, int? region)
        {
            return dbContext.Regions.FirstOrDefault(s => s.Id == region)?.Name;
        }
        public static string GetCountryName(ApplicationDbContext dbContext, int? country)
        {
            return dbContext.Countries.FirstOrDefault(s => s.Id == country)?.Name;
        }
    }
}
