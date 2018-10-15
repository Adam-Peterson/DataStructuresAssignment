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
        public static string sFound;
        public static string sTime;
        public static bool bFirst;

        public ActionResult Index()
        {
            foreach (var item in myQueue)
            {
                ViewBag.Queue += "<p>" + item + "</p>";
            }

            if (bFirst == true)
            {
                ViewBag.StopWatch = "<p>" + sFound + " in " + sTime + " miliseconds" + "</p>";
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
            if (myQueue.Count != 0)
            {
                myQueue.Clear();
                for (int i = 0; i < 2000; i++)
                {
                    myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
                }
                return RedirectToAction("Index");
            }
            else
            {
                for (int i = 0; i < 2000; i++)
                {
                    myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult displayQueue()
        {
            return RedirectToAction("Index");
        }

        public ActionResult deleteFromQueue()
        {
            bFirst = false;
            if (myQueue.Count != 0)
            {
                string first = myQueue.Peek();
                string current = null;
                while (true)
                {
                    current = myQueue.Dequeue();
                    if (myQueue.Peek() == first)
                    {
                        break;
                    }
                    myQueue.Enqueue(current);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult clearQueue()
        {
            bFirst = false;
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




        public ActionResult searchQueue()
        {
            bFirst = true;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            if (myQueue.Contains("New Entry 2"))
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