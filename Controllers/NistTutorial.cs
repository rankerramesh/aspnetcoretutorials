using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TestingNetNetCore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestingNetNetCore.Controllers
{
    public class NistTutorialController : Controller
    {
        // GET: /<controller>/

        IWebHostEnvironment _env;

        private List<PersonalDetail> people = new List<PersonalDetail>();
        public NistTutorialController(IWebHostEnvironment env)
        {
            _env = env;
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
                if(Request.Form.Files["profile-image"]!=null)
                {
                    string fileSavingPath = Path.Combine(_env.WebRootPath, "uploadedfiles", Request.Form.Files["profile-image"].FileName);
                    FileStream fs = new FileStream(fileSavingPath, FileMode.Create);
                    Request.Form.Files["profile-image"].CopyTo(fs);
                    pd.ImageLocation = Path.Combine("uploadedfiles", Request.Form.Files["profile-image"].FileName); ;
                }
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

        public IActionResult StingManipulation()
        {
            return View();

        }

        public IActionResult OverLoading()
        {
            int result = Add(10, 20,30,40);
            return Json(result);
        }
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Add(int x, int y,int z)
        {
            return x + y+z;
        }

        public int Add(int x, int y, int z,int a)
        {
            return x + y + z+a;
        }

    }
}
