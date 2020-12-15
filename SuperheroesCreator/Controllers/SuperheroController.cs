using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperheroesCreator.Data;
using SuperheroesCreator.Models;

namespace SuperheroesCreator.Controllers
{
    public class SuperheroController : Controller
    {   //in order to add to data table, create private member variable and constructor
        private ApplicationDbContext _context;
        //constructor is using built-in dependency injection to inject applicationDBcontext
        //into this constroller to be used
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SuperheroController
        public ActionResult Index()
        {
            List<Superhero> heroList = new List<Superhero>();
            return View(heroList);
        }

        // GET: SuperheroController/Details/5
        public ActionResult Details(int id)
        {
            Superhero heroDetails = _context.Superheroes.Find(id);
            return View(heroDetails);
        }

        // GET: SuperheroController/Create
        public ActionResult Create()
        {
       
            return View();
        }

        // POST: SuperheroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                //todo: add insert logic here
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = _context.Superheroes.Find(id);
            if (superhero == null)
            {
                return HttpNotFound();
            }
            return View(superhero);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                //linq alternative:
                //var hero = _context.Superheroes.Where(s => s.Id == superhero.Id).FirstOrDefault();
                //_context.Superheroes.Remove(hero);
                //_context.Superheroes.Add(superhero);

                _context.Superheroes.Update(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superhero = _context.Superheroes.Find(id);

            if (superhero == null)
            {
                return HttpNotFound();
            }
            return View(superhero);
        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                //linq alternative:
                //var heroToDelete = _context.Superheroes.Where(s => s.Id == id).ToList();
                //foreach (var hero in heroToDelete)
                //{
                //    _context.Superheroes.Remove(hero);
                //}
                   
                var heroToDelete = _context.Superheroes.Find(id);
                _context.Superheroes.Remove(heroToDelete);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
