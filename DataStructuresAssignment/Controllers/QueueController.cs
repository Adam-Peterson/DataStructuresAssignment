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
        public static bool bError = false;
        public static string sErrorMessage;

        public ActionResult Index()
        {
            foreach (var item in myQueue)
            {
                ViewBag.Queue += "<p>" + item + "</p>";
            }

            if (bError == true)
            {
                ViewBag.Error = sErrorMessage;
            }

            if (bFirst == true)
            {
                ViewBag.StopWatch = "<p>" + sFound + " in " + sTime + " miliseconds" + "</p>";
            }


            return View();
        }

        public ActionResult addOne()
        {
            bError = false;
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            return RedirectToAction("Index");
        }

        public ActionResult addHuge()
        {
            bError = false;
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
            bError = false;
            return RedirectToAction("Index");
        }

        public ActionResult deleteFromQueue()
        {
            bFirst = false;
            if (myQueue.Count != 0)
            {
                if (myQueue.Count != 1)
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
                }
                else
                {
                    myQueue.Dequeue();
                }

                return RedirectToAction("Index");
            }
            else
            {
                bError = true;
                sErrorMessage = "<p>There is no content to delete</p>";
                ViewBag.Error = sErrorMessage;
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
                bError = true;
                sErrorMessage = "<p>There is no content to delete</p>";
                ViewBag.Error = sErrorMessage;
                return RedirectToAction("Index");
            }
        }




        public ActionResult searchQueue()
        {
            bError = false;
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