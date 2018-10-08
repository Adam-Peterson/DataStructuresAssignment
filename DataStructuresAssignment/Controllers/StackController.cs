using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class StackController : Controller
    {

        Stack<string> myStack = new Stack<string>();

        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }

        public void addOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            Index();
        }

        public void addHuge()
        {
            for (int i = 0; i < 2001; i++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            }
        }

        /*add display method*/

        public void deleteFromStack()
        {
            myStack.Pop();
        }

        public void clearStack()
        {
            myStack.Clear();
        }

        public void searchStack()
        {
            bool bFound;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myStack.Contains("2"))
            {
                bFound = true;
            }
            else
            {
                bFound = false;
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts;
            ViewBag.StopWatch += bFound;
        }
    }
}