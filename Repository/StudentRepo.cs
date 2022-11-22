using Microsoft.EntityFrameworkCore;
using Model;
using System.Text;

namespace Repository
{
	public class StudentRepo : Istudent
	{

		private readonly StudentDbContext db;

		public StudentRepo(StudentDbContext db)
		{
			this.db = db;
		}

		public async Task<Students> Addstudents(Students s)
		{

			var add = await db.std.AddAsync(s);
			await db.SaveChangesAsync();
			
			return add.Entity;

		}

		public async void DeleteStudents(int id)
		{
			var Delete = await db.std.Where(m=>m.Id ==id).FirstOrDefaultAsync();
			if (Delete != null)
			{
				db.std.Remove(Delete);
				await db.SaveChangesAsync();
			}
			
		}

		public async Task<IEnumerable<Students>> GetStudents()
		{
			return await db.std.ToListAsync();
		}

		public async Task<Students> GetStudentsById(int id)
		{
			return await db.std.Where(m=>m.Id == id).FirstOrDefaultAsync();
			
		}

		public async Task<Students> updateStudent(Students s)
        {
            var update = await db.std.FirstOrDefaultAsync(m => m.Id == s.Id);
            if (update != null)
            {
                update.Name = s.Name;
				update.Age = s.Age;
				update.Department = s.Department;
				update.RollNo = s.RollNo;
				return update;
            }

            return null;


        }
	}
}