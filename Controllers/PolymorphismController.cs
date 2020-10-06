using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestingNetNetCore.Controllers
{
    public class PolymorphismController : Controller
    {
        public IActionResult Index()
        {
            Calculator cal = new Calculator();
            int thirdAddMethod = cal.Add(155, Convert.ToDecimal(100.5));
            int firstAddMethod = cal.Add(150, 100);
            int secondAddMethod = cal.Add(150, 100, 50);

            return Json(new { firstAddMethod = firstAddMethod, secondadd = secondAddMethod, thirdadd = thirdAddMethod });
        }

        public IActionResult Override()
        {
            ScientificCalculator sc = new ScientificCalculator();
            int result = sc.GetDifference(100, 200);
            return Json(result);
        }
    }
    public class Calculator
    {
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public int Add(int firstNumber, int secondNumber, int thirdNumber)
        {
            return firstNumber + secondNumber;
        }
        public int Add(decimal firstNumber, decimal secondNumber)
        {
            return Convert.ToInt32(firstNumber + secondNumber);
        }

    }
    public class GeneralCalculator
    {
        public virtual int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public virtual int GetDifference(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }
    }

    public class ScientificCalculator : GeneralCalculator
    {
        public override int Add(int firstNumber, int secondNumber)
        {
            return Convert.ToInt32(firstNumber + secondNumber);
        }

        public override int GetDifference(int firstNumber, int secondNumber)
        {
            int result;
            if (firstNumber >= secondNumber)
            {
                result = base.GetDifference(firstNumber, secondNumber);
            }
            else
            {
                result = secondNumber - firstNumber;
            }
            return result;
        }
    }
}