using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebT.Models;   // пространство имен моделей и контекста данных
using Microsoft.EntityFrameworkCore;

namespace WebT.Controllers
{
    public class HomeController : Controller
    {
        /*Для взаимодействия с базой данных 
         * в контроллере определяется переменная 
         * контекст данных EventContext db*/
        private EventContext db;
        public HomeController(EventContext context)
        {
            db = context;
        }

        /*добавим в контроллер три метода, 
         * которые будут добавлять новый объект 
         * в базу данных и выводить из нее все объекты*/

        public async Task<IActionResult> Index()
        {
            /*С помощью метода db.Events.ToListAsnc() 
             * будем получать объекты из бд, 
             * создавать из них список и передавать в представление.*/
            return View(await db.Events.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event events)
        {
            /*при помощи метода db.Events.Add() для данных
             * из объекта phone формируется sql-выражение INSERT, 
             * а метод db.SaveChangesAsync() выполняет это выражение, 
             * тем самым добавляя данные в базу данных.*/
            db.Events.Add(events);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /*public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
