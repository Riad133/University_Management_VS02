using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Veiw_Model
{
    class CourseView
    {

        
      
        public string Code { get; set; }
        public double Credit { get; set; }
       
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Department")]
        public string Department { get; set; }
        [DisplayName("Semester")]
        public int SemesterId { get; set; }
    }




}
