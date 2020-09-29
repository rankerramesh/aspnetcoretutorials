using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestingNetNetCore.Models
{
    public class PersonalDetail
    {
        public PersonalDetail()
        {
            
        }

        public int PersonalDetailId { get; set; }
        [Required(ErrorMessage ="Name is required !!")]

        [DisplayName("Full Name *")]
        public string FirstName { get; set; }
        public string Address { get; set; }

        [Range(18,30,ErrorMessage = "Value is not in range")]
        [Required]
        [DisplayName("Age *")]
        public int Age { get; set; }

        [DisplayName("Profession")]
        [MinLength(5),MaxLength(10)]
        public string Occupation { get; set; }

    }

    public class DoctorProfile : PersonalDetail
    {

        public DoctorProfile(List<PersonalDetail> persons) : base()
        {
        }
        public string Qualification { get; set; }
        public string HospitalClinic { get; set; }
        public string Speciality { get; set; }

    }
    public class TeacherProfile : PersonalDetail
    {
        public TeacherProfile(List<PersonalDetail> persons) : base()
        {
        }
        public string Qualification { get; set; }
        public string College { get; set; }
        public string AssociatedSubjects { get; set; }
    }
    public class StudentProfile : PersonalDetail
    {
        public StudentProfile(List<PersonalDetail> persons) : base()
        {
        }
        public string Faculty { get; set; }
        public string College_School { get; set; }
        public string Rollno { get; set; }

    }

    

}
