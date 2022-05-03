using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcPracticaAWS.Models;
using MvcPracticaAWS.Repositories;
using MvcPracticaAWS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPracticaAWS.Controllers
{
    public class ChampionsController : Controller
    {
        private RepositoryChampions repo;
        private ServiceAwsS3 service;
        public ChampionsController(RepositoryChampions repo, ServiceAwsS3 service)
        {
            this.repo = repo;
            this.service = service;
        }


        public IActionResult Equipos()
        {
            List<Equipo> equipos = this.repo.GetEquipos();
            return View(equipos);
        }

        public IActionResult Jugadores()
        {
            List<Jugador> jugadores = this.repo.GetJugadores();
            return View(jugadores);
        }

        public IActionResult Apuestas()
        {
            List<Apuesta> apuestas = this.repo.GetApuestas();
            return View(apuestas);
        }
        public IActionResult InsertJugador()
        {

            List<Equipo> equipos = this.repo.GetEquipos();
            return View(equipos);
        }
        [HttpPost]
        public async Task<IActionResult> InsertJugadorAsync(Jugador jug, IFormFile Imagen)
        {
            int idjug = this.repo.GetMaxIdJugador();
            jug.IdJugador = idjug;
            jug.Imagen = Imagen.FileName;
            using (Stream stream = Imagen.OpenReadStream())
            {
                await this.service.UploadFileAsync(stream, Imagen.FileName);
            }
            this.repo.InsertJugador(jug);

            return RedirectToAction("Jugadores");
        }

        public IActionResult InsertApuesta()
        {

            List<Equipo> equipos = this.repo.GetEquipos();
            return View(equipos);
        }
        [HttpPost]
        public IActionResult InsertApuesta(Apuesta ap)
        {
            int idap = this.repo.GetMaxIdApuesta();
            ap.IdApuesta = idap;
            this.repo.InsertApuesta(ap);
            return RedirectToAction("Apuestas");
          
        }
    }
}
