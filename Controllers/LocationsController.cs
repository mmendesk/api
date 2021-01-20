using Microsoft.AspNetCore.Mvc;
using MoviesApi.Context;
using MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    public class LocationsController : Controller
    {
        private readonly MoviesContext _context;

        public LocationsController(MoviesContext context)
        {
            _context = context;
        }

        //Método que carrega toda lista de locações cadastradas no banco
        //Http GET
        public IActionResult Index()
        {
            IEnumerable<Location> listMovies = _context.Locations;
            return View(listMovies);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        //HTTP Post
        //Método para criar uma nova locação, utilizando o Add seguido de um saveChanges para popular o banco
        [HttpPost]
        public IActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Add(location);
                _context.SaveChanges();

                TempData["mensagem"] = "A locação foi cadastrado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }
        //Método para fazer a edição dos generos
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            //obtém o genero pelo id
            var location = _context.Locations.Find(Id);

            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }
        //HTTP PUT
        //Mesma idéia para fazer a criação dss locações, porém, é utilizado
        //o "Update" na linha 75 para efetuar a atualização do locação
        [HttpPost]
        public IActionResult Edit(Location loca)
        {
            if (ModelState.IsValid)
            {
                _context.Locations.Update(loca);
                _context.SaveChanges();

                TempData["mensagem"] = "O Gênero foi atualizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }
        //HTTP Delete
        //Carrega a pagina com os dados da locação para ter certeza que deseja deletar
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            //obtém o locação pelo id
            var location = _context.Locations.Find(Id);

            if (location == null)
            {
                return NotFound();
            }
            return View();
        }
        //HTTP Delete
        //Efetua a entrega do filme, pegando o mesmo pelo ID
        [HttpPost]
        public IActionResult DeleteLocation(int? id)
        {
            //obter o gênero por id
            var location = _context.Locations.Find(id);

            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            _context.SaveChanges();

            TempData["mensagem"] = "O Filme foi entregue com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
