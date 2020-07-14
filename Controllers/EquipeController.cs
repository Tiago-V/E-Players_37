using System;
using E_Players_AspNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_37.Controllers
{
    public class EquipeController : Controller
    {

        Equipe equipeModel = new Equipe();

        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse( form["idEquipe"] );
            novaEquipe.Nome = form["Nome"];
            novaEquipe.Imagem = form["Imagem"];

            equipeModel.Create(novaEquipe);
            
            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe");
        }
    }
}