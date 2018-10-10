using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class StackController : Controller
    {

        // GET: Stack
        public static Stack<string> myStack = new Stack<string>();
        public static string sFound;
        public static string sTime;
        public static bool bFirst;

        public ActionResult Index()
        {
            foreach (var item in myStack)
            {
                ViewBag.Stack += "<p>" + item + "</p>";
            }

            if (bFirst == true)
            {
                ViewBag.StopWatch = "<p>" + sFound + " in " + sTime + " miliseconds" + "</p>";
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
            for (int i = 0; i < 2000; i++)
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
            bFirst = false;
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
            bFirst = false;
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
            bFirst = true;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myStack.Contains("New Entry 2"))
            {
                sFound = "found";
            }
            else
            {
                sFound = "not found";
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            sTime = ts.ToString();


            return RedirectToAction("Index");

        }
    }
}