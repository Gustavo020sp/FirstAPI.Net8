using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Infra;
using MyFirstAPI.Model;

namespace MyFirstAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//var builder = WebApplication.CreateBuilder(args);

			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddDbContext<ConnectionContext>(options =>
				options.UseMySql(builder.Configuration.GetConnectionString("MyFirstAPIContext"), new MySqlServerVersion(new Version()) ?? throw new InvalidOperationException("Connection string 'MyFirstAPIContext' not found.")));

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			//Injeção de dependência
			builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
			// Registrando ConnectionContext no container de DI
			builder.Services.AddTransient<ConnectionContext>();
			// Ou use AddScoped ou AddSingleton conforme apropriado


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
