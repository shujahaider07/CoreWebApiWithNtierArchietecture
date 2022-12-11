using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public interface Istudent
	{
        public Task<IEnumerable<Students>> GetStudents();
        public Task<Students> Addstudents(Students s);

        public Task<Students> GetStudentsById(int id);


        public Task<Students>DeleteStudents(int id);

        public Task<Students> updateStudent(Students s);
    }
}
