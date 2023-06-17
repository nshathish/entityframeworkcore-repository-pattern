using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Design;

public class AppContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite(
            "Data Source=D:\\MyWorkspaces\\VisualStudio\\EntityFramework\\AnotherUoWLab\\DB\\my_app.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}