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
        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            _iConfig = iConfig;





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
            return View(PersonMemory.GetPersons());
        }
        public ObjectResult PersonalDetail(int personDetailId)
        {
            PersonalDetail pdetail = new PersonalDetail();
            pdetail = PersonMemory.GetPersons().Where(x => x.PersonalDetailId == personDetailId).FirstOrDefault();
            //return View("PersonalDetails",pdetail);
            return new ObjectResult(pdetail);
        }
        public ViewResult PersonalDetailEdit(int personDetailId)
        {
            PersonalDetail pdetail = new PersonalDetail();
            pdetail = PersonMemory.GetPersons().Where(x => x.PersonalDetailId == personDetailId).FirstOrDefault();
            return View(pdetail);
        }

        [HttpPost]
        public ActionResult PersonalDetailEdit(PersonalDetail pd)
        {
            if (ModelState.IsValid)
            {
                //reference type variable
                var personInList = PersonMemory.GetPersons().Where(x => x.PersonalDetailId == pd.PersonalDetailId).FirstOrDefault();
                personInList.FirstName = pd.FirstName;
                personInList.Occupation = pd.Occupation;
                personInList.Age = pd.Age;
                personInList.Address = pd.Address;
                return RedirectToAction("Persons");
            }
            else
            {
                return View(pd);
            }

        }
        public IActionResult CretePersonDetail()
        {
            PersonalDetail pd = new PersonalDetail();
            return View(pd);
        }

        [HttpPost]
        public ActionResult CretePersonDetail(PersonalDetail pd)
        {
            var persondetailList = PersonMemory.GetPersons();
            int currentPersonCount = persondetailList.Count;
            currentPersonCount = currentPersonCount + 1;
            pd.PersonalDetailId = currentPersonCount;
            persondetailList.Add(pd);
            return RedirectToAction("Persons");
        }
        public IActionResult PersonalDetailDelete(int personDetailId)
        {
            var person = PersonMemory.GetPersons().Where(x => x.PersonalDetailId == personDetailId).FirstOrDefault();
            PersonMemory.GetPersons().Remove(person);
            return RedirectToAction("Persons");
        }
    }

}

