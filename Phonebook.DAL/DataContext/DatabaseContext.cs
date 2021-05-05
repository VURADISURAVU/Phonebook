using Microsoft.EntityFrameworkCore;
using Phonebook.DAL.Entities;

namespace Phonebook.DAL.DataContext
{
	public class DatabaseContext : DbContext
	{
		public class OptionsBuild
		{
			public OptionsBuild()
			{
				settings = new AppConfiguration();
				opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
				opsBuilder.UseSqlServer(settings.sqlConnectionString);
				dbOptions = opsBuilder.Options;
			}
			public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; }
			public DbContextOptions<DatabaseContext> dbOptions { get; set; }
			private AppConfiguration settings { get; set; }
		}

		public static OptionsBuild ops = new OptionsBuild();
		
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}

		public DbSet<PhoneBookEntry> PhoneBookEntries { get; set; }
		public DbSet<User> Users { get; set; }
	}
}