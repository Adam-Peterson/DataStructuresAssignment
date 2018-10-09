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
                ViewBag.Stack += "<p>" + item + "</p>";
                ViewBag.StopWatch += "<p>" + item + "</p>";
            }
            return View();
        }

        public ActionResult addOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            return RedirectToAction("Index");
        }

        public ActionResult addHuge()
        {
            for (int i = 0; i <2000; i++)
            {  
                myStack.Push("New Entry " + (myStack.Count + 1));
            }
            return RedirectToAction("Index");
        }

        public ActionResult displayStack()
        {
            return RedirectToAction("Index");
        }

        public ActionResult deleteFromStack()
        {
            if (myStack.Count != 0)
            {
                myStack.Pop();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult clearStack()
        {
            if (myStack.Count != 0)
            {
                myStack.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult searchStack()
        {
            string sFound;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myStack.Contains("*2*"))
            {
                sFound = "found";
            }
            else
            {
                sFound = "not found";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts;
            ViewBag.StopWatch += sFound;

            return RedirectToAction("Index");

        }
    }
}