using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestingNetNetCore.Controllers
{
    public class AsyncController : Controller
    {

        List<string> NameList = new List<string>();
        int counter = 0;
        public IActionResult Index()
        {
            FirstFunction();
            SecondFunction();
            return View(NameList);
        }

        public async void FirstFunction()
        {

            await Task.Run(() =>
            {
                for (; counter <= 100000; counter++)
                {
                    NameList.Add("first function executed");
                }
            }

            );

        }
        public void SecondFunction()
        {
            for (; counter <= 100000; counter++)
            {
                NameList.Add("second function executed");
            }
        }
    }
}