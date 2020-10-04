using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestingNetNetCore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestingNetNetCore.Controllers
{
    public class NistTutorialController : Controller
    {
        // GET: /<controller>/

        private List<PersonalDetail> people = new List<PersonalDetail>();
        public NistTutorialController()
        {
            people = NistMemory.GetPeople();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult People()
        {
            return View(people);
        }
        public IActionResult AddPerson()
        {
            PersonalDetail pd = new PersonalDetail();
            return View(pd);
        }
        public IActionResult AddPersonDetail(PersonalDetail pd)
        {
            if(ModelState.IsValid)
            {
                int personCount = people.Count;
                personCount++;
                pd.PersonalDetailId = personCount;
                people.Add(pd);
                return RedirectToAction("People");
            }
            else
            {
                return View("AddPerson",pd);
            }
            
        }
        public IActionResult EditPerson(int personDetailId)
        {
            PersonalDetail pd = new PersonalDetail();
            pd = people.Where(item => item.PersonalDetailId == personDetailId).FirstOrDefault();
            return View(pd);
        }
        public IActionResult EditPersonDetail(PersonalDetail pd)
        {
            PersonalDetail personInList = new PersonalDetail();
            personInList = people.Where(item => item.PersonalDetailId == pd.PersonalDetailId).FirstOrDefault();
            personInList.FirstName = pd.FirstName;
            personInList.Occupation = pd.Occupation;
            personInList.Address = pd.Address;
            return RedirectToAction("People");
        }
        public IActionResult DeletePerson(int personDetailId)
        {
            PersonalDetail pd = people.Where(x => x.PersonalDetailId == personDetailId).FirstOrDefault();
            people.Remove(pd);
            return RedirectToAction("People");
        }
    }
}
