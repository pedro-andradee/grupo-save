using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityApi.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseMySql("Server=localhost;port=3306;Database=IdentityDb;user=root;password=123456789;",
         ServerVersion.AutoDetect("Server=localhost;port=3306;Database=IdentityDb;user=root;password=123456789;"));

        return new AppDbContext(optionsBuilder.Options);
    }
}