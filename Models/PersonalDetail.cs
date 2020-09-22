using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TestingNetNetCore.Models
{
    public class PersonalDetail
    {
        public PersonalDetail(List<PersonalDetail> persons)
        {
            int personCount = persons.Count;
            PersonalDetailId = personCount + 1;
        }

        public int PersonalDetailId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }

    }

    public class DoctorProfile : PersonalDetail
    {

        public DoctorProfile(List<PersonalDetail> persons) : base(persons)
        {
        }
        public string Qualification { get; set; }
        public string HospitalClinic { get; set; }
        public string Speciality { get; set; }

    }
    public class TeacherProfile : PersonalDetail
    {
        public TeacherProfile(List<PersonalDetail> persons) : base(persons)
        {
        }
        public string Qualification { get; set; }
        public string College { get; set; }
        public string AssociatedSubjects { get; set; }
    }
    public class StudentProfile : PersonalDetail
    {
        public StudentProfile(List<PersonalDetail> persons) : base(persons)
        {
        }
        public string Faculty { get; set; }
        public string College_School { get; set; }
        public string Rollno { get; set; }

    }

    

}
