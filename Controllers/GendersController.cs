using Microsoft.AspNetCore.Mvc;
using MoviesApi.Context;
using MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    public class GendersController : Controller
    {
        private readonly MoviesContext _context;

        public GendersController(MoviesContext context)
        {
            _context = context;
        }

        //Método que carrega toda lista de generos cadastradas no banco
        //Http GET
        public IActionResult Index()
        {
            IEnumerable<Gender> listGenders = _context.Genders;
            return View(listGenders);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        //HTTP Post
        //Método para criar um novo Gênero, utilizando o Add seguido de um saveChanges para popular o banco
        [HttpPost]
        public IActionResult Create(Gender gender)
        {
            if (ModelState.IsValid)
            {
                _context.Genders.Add(gender);
                _context.SaveChanges();

                TempData["mensagem"] = "O Gênero foi cadastrado com sucesso!";

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
            var gender = _context.Genders.Find(Id);

            if (gender == null)
            {
                return NotFound();
            }
            return View(gender);
        }
        //HTTP PUT
        //Mesma idéia para fazer a criação dos generos, porém, é utilizado
        //o "Update" na linha 77 para efetuar a atualização do genero
        [HttpPost]
        public IActionResult Edit(Gender gender)
        {
            if (ModelState.IsValid)
            {
                _context.Genders.Update(gender);
                _context.SaveChanges();

                TempData["mensagem"] = "O Gênero foi atualizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }
        //HTTP Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            //obtém o gênero pelo id
            var gender = _context.Genders.Find(Id);

            if (gender == null)
            {
                return NotFound();
            }
            return View();
        }
        //HTTP Delete
        //Efetua a exclusão do gênero, pegando o mesmo pelo ID
        [HttpPost]
        public IActionResult DeleteGenders(int? id)
        {
            //obter o gênero por id
            var gender = _context.Genders.Find(id);

            if (gender == null)
            {
                return NotFound();
            }

            _context.Genders.Remove(gender);
            _context.SaveChanges();

            TempData["mensagem"] = "O Gênero foi excluído com sucesso!";

            return RedirectToAction("Index");
        }
    }
}
