using Microsoft.EntityFrameworkCore;
using Model;
using System;
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

		public async Task<Students>DeleteStudents(int id)
		{
            var result = await db.std
                .FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
			{
                db.std.Remove(result);
                await db.SaveChangesAsync();
            }

			return result;
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