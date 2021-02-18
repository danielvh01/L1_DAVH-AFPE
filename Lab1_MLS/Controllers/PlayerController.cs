﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1_MLS.Models.Data;
using System.IO;
using Lab1_MLS.Models;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

namespace Lab1_MLS.Controllers
{
    public class PlayerController : Controller
    {
        
        int cont = 0;
        Stopwatch conteo = new Stopwatch();
        private readonly IHostingEnvironment hostingEnvironment;
        public PlayerController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: PlayerController
        public ActionResult Index()
        {
            return View(Singleton.Instance.PlayersList);
            //return View(Handcraftted list);
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

        

        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(FileModel model)
        {
            if (ModelState.IsValid)
            {
                conteo.Start();
                string uniqueFileName = null;
                string filePath = null;
                if (model.File != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.File.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                var lectorlinea = new StreamReader(model.File.OpenReadStream());
                string linea = lectorlinea.ReadToEnd();
                string[] players = linea.Split("\n");
                for (int i = 1; i < players.Length; i++)
                {
                    string[] newPlayer = players[i].Split(',');
                    if (newPlayer.Length == 6)
                    {
                        var PlayerAded = new Models.PlayerModel
                        {
                            Id = cont,
                            Club = newPlayer[0],
                            LastName = newPlayer[1],
                            Name = newPlayer[2],
                            Position = newPlayer[3],
                            Salary = Double.Parse(newPlayer[4]),
                            Compensation = Double.Parse(newPlayer[5])

                        };
                        Singleton.Instance.PlayersList.Add(PlayerAded);
                    }
                    else
                    {
                        newPlayer = players[i].Split(';');
                        if (newPlayer.Length == 6)
                        {
                            var PlayerAded = new Models.PlayerModel
                            {
                                Id = cont,
                                Club = newPlayer[0],
                                LastName = newPlayer[1],
                                Name = newPlayer[2],
                                Position = newPlayer[3],
                                Salary = Double.Parse(newPlayer[4]),
                                Compensation = Double.Parse(newPlayer[5])

                            };
                            Singleton.Instance.PlayersList.Add(PlayerAded);
                        }
                    }
                    cont++;
                }

            }
            conteo.Stop();
            string timeElapsed = Convert.ToString(conteo.Elapsed);
            //Necessary return time data to index
            return RedirectToAction(nameof(Index));

        }

        public ActionResult Import_File()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import_File(FileModel model)
        {
            if (ModelState.IsValid)
            {
                conteo.Start();
                string uniqueFileName = null;
                string filePath = null;
                if (model.File != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.File.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                var lectorlinea = new StreamReader(model.File.OpenReadStream());
                string linea = lectorlinea.ReadToEnd();
                string[] players = linea.Split("\n");
                for (int i = 1; i < players.Length; i++)
                {
                    string[] newPlayer = players[i].Split(',');
                    if (newPlayer.Length == 6)
                    {
                        var PlayerAded = new Models.PlayerModel
                        {
                            Id = cont,
                            Club = newPlayer[0],
                            LastName = newPlayer[1],
                            Name = newPlayer[2],
                            Position = newPlayer[3],
                            Salary = Double.Parse(newPlayer[4]),
                            Compensation = Double.Parse(newPlayer[5])

                        };
                       //Agregar a double linked list
                    }
                    else
                    {
                        newPlayer = players[i].Split(';');
                        if (newPlayer.Length == 6)
                        {
                            var PlayerAded = new Models.PlayerModel
                            {
                                Id = cont,
                                Club = newPlayer[0],
                                LastName = newPlayer[1],
                                Name = newPlayer[2],
                                Position = newPlayer[3],
                                Salary = Double.Parse(newPlayer[4]),
                                Compensation = Double.Parse(newPlayer[5])

                            };
                            //Agregar a double linked list
                        }
                    }
                    cont++;
                }

            }
            conteo.Stop();
            string timeElapsed = Convert.ToString(conteo.Elapsed);
            //Necessary return time data to index
            return RedirectToAction(nameof(Index));

        }
    }
}
