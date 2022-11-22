using Microsoft.EntityFrameworkCore;

namespace Model
{
	public class StudentDbContext : DbContext
	{

		public StudentDbContext(DbContextOptions<StudentDbContext> options) :base(options)
		{

		}

		public DbSet<Students> std { get; set; }

	}
}
