using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresAssignment.Controllers
{
    public class QueueController : Controller
    {
        // GET: Queue
        public static Queue<string> myQueue = new Queue<string>();

        // GET: Stack
        public ActionResult Index()
        {
            foreach (var item in myQueue)
            {
                ViewBag.Queue += "<p>" + item + "</p>";
                ViewBag.StopWatch += "<p>" + item + "</p>";
            }
            return View();
        }

        public ActionResult addOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            return RedirectToAction("Index");
        }

        public ActionResult addHuge()
        {
            for (int i = 0; i < 2000; i++)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            }
            return RedirectToAction("Index");
        }

        public ActionResult displayStack()
        {
            return RedirectToAction("Index");
        }

        public ActionResult deleteFromStack()
        {
            if (myQueue.Count != 0)
            {
                myQueue.Dequeue();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult clearStack()
        {
            if (myQueue.Count != 0)
            {
                myQueue.Clear();
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

            if (myQueue.Contains("*2*"))
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