using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingNetNetCore.Models
{
    public class NistMemory

    {
        static List<PersonalDetail> people = new List<PersonalDetail>();
        public NistMemory()
        {

        }
        public static List<PersonalDetail> GetPeople()
        {
            //if (people.Count == 0)
            //{
            //    people.Add(new PersonalDetail()
            //    {
            //        FirstName = "dipendra",
            //        Address = "Banepa",
            //        Occupation = "Student",
            //        PersonalDetailId=1
            //    });
            //    people.Add(new PersonalDetail()
            //    {
            //        FirstName = "aarati",
            //        Address = "Dhulikhel",
            //        Occupation = "Teacher",
            //        PersonalDetailId = 2
            //    });
            //}

            return people;
        }
        
    }
}
