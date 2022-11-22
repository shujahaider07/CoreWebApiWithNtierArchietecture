using System.ComponentModel.DataAnnotations;

namespace Model
{
	public class Students
 	{
        [Key]
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Age { get; set; }
        public string RollNo { get; set; }
        public string Department{ get; set; }


    }
}