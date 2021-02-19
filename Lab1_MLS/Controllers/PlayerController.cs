using Microsoft.AspNetCore.Http;
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
        string log;
        private readonly IHostingEnvironment hostingEnvironment;
        string session;
        ListOperations operations;
        public PlayerController(IHostingEnvironment hostingEnvironment)
        {
            session = "Times.log";
            operations = new ListOperations();
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: PlayerController
        public ActionResult Index()
        {
            conteo.Restart();
            if (Singleton.Instance.usingHandmadeList)
            {
                conteo.Stop();
                log += "[" + DateTime.Now + "]- Details - Time Lapsed: " + conteo.Elapsed + "ms using the handcrafted list\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                return View(Singleton.Instance.HandcraftedList);
            }
            else
            {
                conteo.Stop();
                log += "[" + DateTime.Now + "]- Details - Time Lapsed: " + conteo.Elapsed + "ms using the handcrafted list\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                return View(Singleton.Instance.PlayersList);
            }
            
        }

        
        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            conteo.Restart();
            string filter = collection["search"];
            if (Singleton.Instance.usingHandmadeList)
            {
                conteo.Stop();
                log += "[" + DateTime.Now + "]- Details - Time Lapsed: " + conteo.Elapsed + "ms using the handcrafted list\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                return View(operations.Search(Singleton.Instance.HandcraftedList, x => x.Name.ToUpper().Contains(filter.ToUpper()) || x.LastName.ToUpper().Contains(filter.ToUpper())
                || x.Position.ToUpper().Contains(filter.ToUpper()) || x.Club.ToUpper().Contains(filter.ToUpper())));
            }
            else
            {
                conteo.Stop();
                log += "[" + DateTime.Now + "]- Details - Time Lapsed: " + conteo.Elapsed + "ms using the handcrafted list\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                return View(operations.Search(Singleton.Instance.PlayersList, x => x.Name.ToUpper().Contains(filter.ToUpper()) || x.LastName.ToUpper().Contains(filter.ToUpper())
                || x.Position.ToUpper().Contains(filter.ToUpper()) || x.Club.ToUpper().Contains(filter.ToUpper())));
            }
        }
        
        // GET: PlayerController/Details/5
        public ActionResult Details(int id)
        {
            if (Singleton.Instance.usingHandmadeList)
            {
                conteo.Restart();
                PlayerModel detailsPlayer = null;
                for (int i = 0; i < Singleton.Instance.HandcraftedList.Length; i++)
                {
                    detailsPlayer = Singleton.Instance.HandcraftedList.Get(i);
                    if (detailsPlayer.Id == id)
                    {
                        break;
                    }
                }
                conteo.Stop();
                log += "[" + DateTime.Now + "]- Details - Time Lapsed: " + conteo.Elapsed + "ms using the handcrafted list\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                return View(detailsPlayer);
            }
            else
            {
                conteo.Restart();
                var detailsPlayer = Singleton.Instance.PlayersList.Find(x => x.Id == id);
                conteo.Stop();
                log += "[" + DateTime.Now + "]- Details - Time Lapsed: " + conteo.Elapsed + "ms using the .NET list\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                return View(detailsPlayer);
            }
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
                conteo.Restart();
                var newPlayer = new Models.PlayerModel
                {
                    Id = cont,
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Position = collection["Position"],
                    Salary = Double.Parse(collection["Salary"]),
                    Club = collection["Club"]

                };
                if (Singleton.Instance.usingHandmadeList)
                {
                    Singleton.Instance.HandcraftedList.InsertAtEnd(newPlayer);
                }
                else
                {
                    Singleton.Instance.PlayersList.Add(newPlayer);
                }
                cont++;
                conteo.Stop();
                if(Singleton.Instance.usingHandmadeList)
                {
                    log += "[" + DateTime.Now + "]- Details - Time Lapsed: " + conteo.Elapsed + "ms using the handcrafted list\n";
                    TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms using the handcrafted list";
                }
                else
                {
                    log += "[" + DateTime.Now + "]- Details - Time Lapsed: " + conteo.Elapsed + "ms using the .NET list\n";
                    TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + "ms using the .NET list ";
                }
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                
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
            if (Singleton.Instance.usingHandmadeList)
            {
                conteo.Restart();
                PlayerModel editPlayer = null;
                for (int i = 0; i < Singleton.Instance.HandcraftedList.Length; i++)
                {
                    editPlayer = Singleton.Instance.HandcraftedList.Get(i);
                    if (editPlayer.Id == id)
                    {
                        break;
                    }
                }
                conteo.Stop();
                log += "[" + DateTime.Now + "]- Edit(GET) - Time Lapsed: " + conteo.Elapsed + "ms\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                return View(editPlayer);
            }
            else
            {
                conteo.Restart();
                var editPlayer = Singleton.Instance.PlayersList.Find(x => x.Id == id);
                conteo.Stop();
                log += "[Edit(GET)] - Time Lapsed: " + conteo.Elapsed + "ms\n";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                return View(editPlayer);
            }
        }

        // POST: PlayerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                conteo.Restart();
                PlayerModel PlayerEdited;
                if (Singleton.Instance.usingHandmadeList)
                {
                    int index = -1;
                    for (int i = 0; i < Singleton.Instance.HandcraftedList.Length; i++)
                    {
                        PlayerEdited = Singleton.Instance.HandcraftedList.Get(i);
                        if (PlayerEdited.Id == id)
                        {
                            index = i;
                            break;
                        }
                    }
                    if(index > -1)
                    {
                        PlayerEdited = Singleton.Instance.HandcraftedList.Get(index);
                        PlayerEdited.Salary = Double.Parse(collection["Salary"]);
                        PlayerEdited.Club = collection["Club"];
                        Singleton.Instance.HandcraftedList.Delete(index);
                        Singleton.Instance.HandcraftedList.Insert(PlayerEdited, index);
                    }
                }
                else
                {
                    PlayerEdited = Singleton.Instance.PlayersList.Find(x => x.Id == id);
                    int index = Singleton.Instance.PlayersList.IndexOf(PlayerEdited);
                    if(index > -1)
                    {
                        PlayerEdited.Salary = Double.Parse(collection["Salary"]);
                        PlayerEdited.Club = collection["Club"];
                        Singleton.Instance.PlayersList[index] = PlayerEdited;
                    }
                }
                conteo.Stop();
                log += "[" + DateTime.Now + "]- Edit(POST) - Time Lapsed: " + conteo.Elapsed + "ms\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
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
            if (Singleton.Instance.usingHandmadeList)
            {
                conteo.Restart();
                PlayerModel player = null;
                for (int i = 0; i < Singleton.Instance.HandcraftedList.Length; i++)
                {
                    player = Singleton.Instance.HandcraftedList.Get(i);
                    if (player.Id == id)
                    {
                        break;
                    }
                }
                conteo.Stop();
                log += "[" + DateTime.Now + "]- Delete(GET) - Time Lapsed: " + conteo.Elapsed + "ms\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                return View(player);
            }
            else
            {
                conteo.Restart();
                var player = Singleton.Instance.PlayersList.Find(x => x.Id == id);
                conteo.Stop();
                log += "[" + DateTime.Now + "]- Delete(GET) - Time Lapsed: " + conteo.Elapsed + "ms\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                StreamWriter file = new StreamWriter(session, true);
                file.Write(log);
                file.Close();
                return View(player);
            }
        }

        // POST: PlayerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (Singleton.Instance.usingHandmadeList)
                {
                    conteo.Restart();
                    PlayerModel player = null;
                    for (int i = 0; i < Singleton.Instance.HandcraftedList.Length; i++)
                    {
                        player = Singleton.Instance.HandcraftedList.Get(i);
                        if (player.Id == id)
                        {
                            Singleton.Instance.HandcraftedList.Delete(i);
                            break;
                        }
                    }
                    conteo.Stop();
                    log += "[" + DateTime.Now + "]- Delete(POST) - Time Lapsed: " + conteo.Elapsed + "ms\n";
                    TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                    StreamWriter file = new StreamWriter(session, true);
                    file.Write(log);
                    file.Close();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    conteo.Restart();
                    Singleton.Instance.PlayersList.Remove(Singleton.Instance.PlayersList.Find(x => x.Id == id));
                    conteo.Stop();
                    log += "[" + DateTime.Now + "]- Delete(POST) - Time Lapsed: " + conteo.Elapsed + "ms\n";
                    TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms ";
                    StreamWriter file = new StreamWriter(session, true);
                    file.Write(log);
                    file.Close();
                    return RedirectToAction(nameof(Index));
                }
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
                conteo.Restart();
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
                        if (Singleton.Instance.usingHandmadeList)
                        {
                            Singleton.Instance.HandcraftedList.InsertAtEnd(PlayerAded);
                        }
                        else
                        {
                            Singleton.Instance.PlayersList.Add(PlayerAded);
                        }
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
                            if (Singleton.Instance.usingHandmadeList)
                            {
                                Singleton.Instance.HandcraftedList.InsertAtEnd(PlayerAded);
                            }
                            else
                            {
                                Singleton.Instance.PlayersList.Add(PlayerAded);
                            }
                        }
                    }
                    cont++;
                }

            }
            conteo.Stop();
            if (Singleton.Instance.usingHandmadeList)
            {
                log += "[" + DateTime.Now + "]- Import - Time Lapsed: " + conteo.Elapsed + "ms using the Handcrafted List\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms using the Handcrafted List";
            }
            else
            {
                log += "[" + DateTime.Now + "]- Import - Time Lapsed: " + conteo.Elapsed + "ms using the .NET List\n";
                TempData["testmsg"] = " Time Lapsed: " + conteo.Elapsed + " ms using the .NET List";
            }
            StreamWriter file = new StreamWriter(session, true);
            file.Write(log);
            file.Close();
            //Necessary return time data to index
            return RedirectToAction(nameof(Index));
        }
    }
}