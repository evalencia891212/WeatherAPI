using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using APIWeather.Business;
using APIWeather.Entities;

namespace APIWeather.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Cities
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cities/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cities/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Cities/getCitiesList
        [HttpGet]
        public JsonResult getCitiesList()
        {
            Object JsonArray;
            try
            {
                List<ECity> ListeCities = new BCity().GetCities();
                JsonArray = ListeCities;
            }
            catch(Exception ex)
            {
                JsonArray = "Error" + ex.Message;
            }
           
            return Json(new { JsonArray },JsonRequestBehavior.AllowGet);



        }

        // GET: Cities/getCityWeatherRecord/1,asd,asd
        [HttpGet]
        public JsonResult getCityWeatherRecord(int ID,string BeginDate , string EndDate)     
        {
            Object JsonArray;
           
            try
            {
                string BeginDateSQL = Convert.ToDateTime(BeginDate).ToString("yyyy-MM-dd");
                string EndDateSQL = Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd");
                List<ERecord> listERecord = new BRecord().GetRecords(ID, BeginDateSQL, EndDateSQL);
                JsonArray = listERecord;
            }
            catch(Exception ex)
            {
                JsonArray = "Error " + ex.Message;
            }
          
            //listERecord.Add(eRecord);

            return Json(new { JsonArray }, JsonRequestBehavior.AllowGet);


        }
    }
}
