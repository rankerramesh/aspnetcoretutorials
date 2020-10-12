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
            ICalculator cal = new Calculator();
            int firstAddMethod = cal.Add(150, 100);
            int secondAddMethod = cal.Add(150, 100, 50);
            int thirdAddMethod = cal.Add(155, Convert.ToDecimal(100.5));
            return Json(new { firstAddMethod = firstAddMethod, secondadd = secondAddMethod, thirdadd = thirdAddMethod });
            
        }
        public IActionResult AbstractIndex()
        {
            
            AbstractCalculator cal = new NormalClass();
            int abstractMethod = cal.Add(150, 100);
            int nonAbstractMethod = cal.add(100, 200, 300);
            return Json(new { abstractMethodResult = abstractMethod, nonAbstractMethodResult= nonAbstractMethod });
        }

        public IActionResult Override()
        {
            ScientificCalculator sc = new ScientificCalculator();
            int result = sc.GetDifference(100, 200);
            int addResult = sc.Add(10, 12);
            return Json(result);
        }
    }

    public interface ICalculator
    {
        int Add(int firstNumber, int secondNumber);
        int Add(int firstNumber, int secondNumber, int thirdNumber);
        int Add(decimal firstNumber, decimal secondNumber);
    }
    public class Calculator : ICalculator
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
        public GeneralCalculator()
        {

        }
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
        public ScientificCalculator() : base()
        {

        }
        public override int Add(int firstNumber, int secondNumber)
        {
            var result = base.Add(firstNumber, secondNumber);
            var secondResult = base.GetDifference(firstNumber, secondNumber);
            return Convert.ToInt32(result);
        }

        //public  int Add(int firstNumber, int secondNumber)
        //{
        //    return firstNumber + secondNumber;
        //}

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
    public abstract class AbstractCalculator
    {
        public abstract  int Add(int firstN, int secondN);
        public int add(int x,int y, int z)
        {
            return x + y + z;
        }
        
    }
    public class NormalClass:AbstractCalculator
    {
        public override  int Add(int firstN, int secondN)
        {
            return firstN + secondN;
        }
        //public override int add(int x, int y, int z)
        //{
        //    return base.add(x, y, z);
        //}
    }
}