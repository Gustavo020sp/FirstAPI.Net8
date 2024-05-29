using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Model;


namespace MyFirstAPI.Infra
{
	public class ConnectionContext : DbContext
	{
		public ConnectionContext(DbContextOptions<ConnectionContext> options)
		   : base(options)
		{
		}
		public DbSet<Employee> Employees { get; set; }
	}
}
