using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingNetNetCore.Models
{
    public class PersonMemory
    {
        private static List<PersonalDetail> detailList = new List<PersonalDetail>();
        public static List<PersonalDetail> GetPersons()
        {
            if (detailList.Count == 0)
            {
                //add items to list
                //hari as a doctor
                //inherit from profiledetail
                PersonalDetail hari = new PersonalDetail();
                hari.PersonalDetailId = 1;
                hari.FirstName = "Hari Krishna";
                hari.Address = "Gothatar, Kathmandu";
                hari.Age = 56;
                hari.Occupation = "Doctor";
                detailList.Add(hari);


                //sanil as a farmer
                PersonalDetail sanil = new PersonalDetail();
                sanil.PersonalDetailId = 2;
                sanil.FirstName = "Sanil Desemaru";
                sanil.Address = "Dudhpati, Bhaktapur";
                sanil.Age = 24;
                sanil.Occupation = "Farmer";
                detailList.Add(sanil);


                //adit as a farmer
                PersonalDetail adit = new PersonalDetail();
                adit.PersonalDetailId = 3;
                adit.FirstName = "Adit Dahal";
                adit.Address = "Dudhpati, Bhaktapur";
                adit.Age = 24;
                adit.Occupation = "Farmer";
                detailList.Add(adit);


                //bhanu as a student
                PersonalDetail bhanu = new PersonalDetail();
                bhanu.PersonalDetailId = 4;
                bhanu.FirstName = "Bhanu Shrestha";
                bhanu.Address = "Dudhpati, Bhaktapur";
                bhanu.Age = 24;
                bhanu.Occupation = "Student";
                detailList.Add(bhanu);


                // saurav as a student
                PersonalDetail saurav = new PersonalDetail();
                saurav.PersonalDetailId = 5;
                saurav.FirstName = "Saurav Dhami";
                saurav.Address = "Gothatar, Kathmandu";
                saurav.Age = 56;
                saurav.Occupation = "Student";
                detailList.Add(saurav);



                //nikita as a student
                PersonalDetail nikita = new PersonalDetail();
                nikita.PersonalDetailId = 6;
                nikita.FirstName = "Nikita Shrestha";
                nikita.Address = "Gothatar, Kathmandu";
                nikita.Age = 56;
                nikita.Occupation = "Student";
                detailList.Add(nikita);
            }
            return detailList;
        }
    }
}
