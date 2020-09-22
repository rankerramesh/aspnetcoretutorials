using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TestingNetNetCore.Models;

namespace TestingNetNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _iConfig;
        private List<PersonalDetail> detailList = new List<PersonalDetail>();
        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            _iConfig = iConfig;



            //add items to list
            //hari as a doctor
            //inherit from profiledetail
            DoctorProfile hari = new DoctorProfile(detailList);
            hari.FirstName = "Hari Krishna";
            hari.Address = "Gothatar, Kathmandu";
            hari.Age = 56;
            hari.Occupation = "Doctor";
            //doctor profile specific property
            hari.HospitalClinic = "bir hospital, om hospital, bidh lab ";
            hari.Qualification = "MD";
            hari.Speciality = "Dermatologist";
            detailList.Add(hari);


            //sanil as a farmer
            PersonalDetail sanil = new PersonalDetail(detailList);
            sanil.FirstName = "Sanil Desemaru";
            sanil.Address = "Dudhpati, Bhaktapur";
            sanil.Age = 24;
            sanil.Occupation = "Farmer";
            detailList.Add(sanil);


            //adit as a farmer
            PersonalDetail adit = new PersonalDetail(detailList);
            adit.FirstName = "Adit Dahal";
            adit.Address = "Dudhpati, Bhaktapur";
            adit.Age = 24;
            adit.Occupation = "Farmer";
            detailList.Add(adit);


            //bhanu as a student
            StudentProfile bhanu = new StudentProfile(detailList);
            bhanu.FirstName = "Bhanu Shrestha";
            bhanu.Address = "Dudhpati, Bhaktapur";
            bhanu.Age = 24;
            bhanu.Occupation = "Student";
            // student specific property
            bhanu.College_School = "Bhaktapur Multiple Campus";
            bhanu.Faculty = "Science and Technology";
            detailList.Add(bhanu);


            // saurav as a student
            StudentProfile saurav = new StudentProfile(detailList);
            saurav.FirstName = "Saurav Dhami";
            saurav.Address = "Gothatar, Kathmandu";
            saurav.Age = 56;
            saurav.Occupation = "Student";
            // student specific property
            saurav.College_School = "Bhaktapur Multiple Campus";
            saurav.Faculty = "Science and Technology";
            detailList.Add(saurav);



            //nikita as a student
            StudentProfile nikita = new StudentProfile(detailList);
            nikita.FirstName = "Nikita Shrestha";
            nikita.Address = "Gothatar, Kathmandu";
            nikita.Age = 56;
            nikita.Occupation = "Student";
            // student specific property
            nikita.College_School = "Bhaktapur Multiple Campus";
            nikita.Faculty = "Science and Technology";
            detailList.Add(nikita);

        }


        public IActionResult Index()
        {
            ViewBag.MyKey = _iConfig["MyKey"];
            return View();

        }
        public IActionResult AboutMe()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Persons()
        {
            return View(detailList);
        }
        public IActionResult PersonalDetail(string person)
        {

            //this information can be accessed from database

            //hari
            PersonalDetail hari = new PersonalDetail(detailList);
            hari.FirstName = "Hari Krishna";
            hari.Address = "Gothatar, Kathmandu";
            hari.Age = 56;
            hari.Occupation = "Trader";



            //bhanu
            PersonalDetail bhanu = new PersonalDetail(detailList);
            bhanu.FirstName = "Bhanu Shrestha";
            bhanu.Address = "Dudhpati, Bhaktapur";
            bhanu.Age = 24;
            bhanu.Occupation = "Student";


            PersonalDetail personDetail = new PersonalDetail(detailList);
            if (person == "Hari Krishna")
            {
                personDetail = hari;
            }
            else if (person == "Bhanu Shrestha")
            {
                personDetail = bhanu;
            }
            return View("PersonalDetails", personDetail);
        }


    }
}
