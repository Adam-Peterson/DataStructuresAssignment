using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class DictionaryController : Controller
    {
        // GET: Dictionary
        // GET: Queue
        public static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        // GET: Stack
        public ActionResult Index()
        {
            foreach (var item in myDictionary)
            {
                ViewBag.Dictionary += "<p>" + item + "</p>";
                ViewBag.StopWatch += "<p>" + item + "</p>";
            }
            return View();
        }

        public ActionResult addOne()
        {
            myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count+1));
            return RedirectToAction("Index");
        }

        public ActionResult addHuge()
        {
            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add("New Entry " + (myDictionary.Count + 1), (myDictionary.Count + 1));
            }
            return RedirectToAction("Index");
        }

        public ActionResult displayStack()
        {
            return RedirectToAction("Index");
        }

        public ActionResult deleteFromStack()
        {
            if (myDictionary.Count != 0)
            {
                myDictionary.Remove(myDictionary.Keys.Last());
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult clearStack()
        {
            if (myDictionary.Count != 0)
            {
                myDictionary.Clear();
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

            if (myDictionary.ContainsKey("2"))
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