using System.Diagnostics.Tracing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Phonebook.DAL.DataContext
{
	public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
	{
		public DatabaseContext CreateDbContext(string[] args)
		{
			AppConfiguration appConfiguration = new AppConfiguration();
			var opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
			opsBuilder.UseSqlServer(appConfiguration.sqlConnectionString);
			return new DatabaseContext(opsBuilder.Options);
		}
	}
}