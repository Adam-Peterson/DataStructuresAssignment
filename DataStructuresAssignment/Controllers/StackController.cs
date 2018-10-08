using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class StackController : Controller
    {

        public static Stack<string> myStack = new Stack<string>();

        // GET: Stack
        public ActionResult Index()
        {
            foreach (var item in myStack)
            {
                ViewBag.Stack += item;
            }
            return View();
        }

        public ActionResult addOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            return RedirectToAction("Index");
        }

        public void addHuge()
        {
            for (int i = 0; i < 2001; i++)
            {
                myStack.Push("New Entry " + (myStack.Count + 1));
            }
            ViewBag.Stack = myStack;
        }

        public ActionResult displayStack()
        {
            return RedirectToAction("Index");
        }

        public void deleteFromStack()
        {
            ViewBag.Stack = myStack;
            myStack.Pop();
        }

        public void clearStack()
        {
            ViewBag.Stack = myStack;
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