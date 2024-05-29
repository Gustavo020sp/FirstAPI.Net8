namespace MyFirstAPI.Model
{
	public class Employee
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }

		public Employee(int id, string? name, string? email, double baseSalary, DateTime birthDate)
		{
			Id = id;
			Name = name;
			Email = email;
			BaseSalary = baseSalary;
			BirthDate = birthDate;
		}
	}
}
