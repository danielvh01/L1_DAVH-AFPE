﻿    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1_MLS.Models.Data;

namespace Lab1_MLS.Controllers
{
    public class PlayerController : Controller
    {
        int cont = 0;
        // GET: PlayerController
        public ActionResult Index()
        {
            return View(Singleton.Instance.PlayersList);
        }

        // GET: PlayerController/Details/5
        public ActionResult Details(int id)
        {
            var detailsPlayer = Singleton.Instance.PlayersList.Find(x => x.Id == id);
            return View(detailsPlayer);
        }

        // GET: PlayerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newPlayer = new Models.PlayerModel
                {
                    Id = cont,
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Position = collection["Position"],
                    Salary = Double.Parse( collection["Salary"] ),
                    Club = collection["Club"]
                    
                };
                Singleton.Instance.PlayersList.Add(newPlayer);
                cont++;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerController/Edit/5
        public ActionResult Edit(int id)
        {
            var editPlayer = Singleton.Instance.PlayersList.Find(x => x.Id == id);

            return View(editPlayer);
        }

        // POST: PlayerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                int index = Singleton.Instance.PlayersList.IndexOf(Singleton.Instance.PlayersList.Find(x => x.Id == id));
                var PlayerEdited = new Models.PlayerModel
                {
                    Id = cont,
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Position = collection["Position"],
                    Salary = Double.Parse(collection["Salary"]),
                    Club = collection["Club"]
                };
                Singleton.Instance.PlayersList[index] = PlayerEdited;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerController/Delete/5
        public ActionResult Delete(int id)
        {
            var Player = Singleton.Instance.PlayersList.Find(x => x.Id == id);
            return View(Player);
        }

        // POST: PlayerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Singleton.Instance.PlayersList.Remove(Singleton.Instance.PlayersList.Find(x => x.Id == id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Import_File()
        {
            return View();
        }

        // POST: PlayerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Import_File(IFormCollection collection)
        {
            try
            {
                //var newPlayer = new Models.PlayerModel
                //{
                //    Id = cont,
                //    Name = collection["Name"],
                //    LastName = collection["LastName"],
                //    Position = collection["Position"],
                //    Salary = Double.Parse(collection["Salary"]),
                //    Club = collection["Club"]

                //};
                //Singleton.Instance.PlayersList.Add(newPlayer);
                //cont++;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
