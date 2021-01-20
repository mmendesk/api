using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Context;
using MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesContext _context;

        public MoviesController(MoviesContext context)
        {
            _context = context;
        }

        //Método que carrega toda lista de filmes cadastradas no banco
        //Http GET
        public IActionResult Index()
        {
            IEnumerable<Movie> listMovies = _context.Movies;
            return View(listMovies);
        }
                
        public IActionResult Create()
        {
            return View();
        }

        //HTTP Post
        //Método para criar um novo filme, utilizando o Add seguido de um saveChanges para popular o banco
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if(ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                TempData["mensagem"] = "O Filme foi cadastrado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }
        //Método para fazer a edição dos filmes
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound(); 
            }

            //obtém o filme pelo id
            var movie = _context.Movies.Find(Id);

            if(movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        //HTTP PUT
        //Mesma idéia para fazer a criação do filme, porém, é utilizado
        //o "Update" na linha 76 para efetuar a atualização do filme
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();

                TempData["mensagem"] = "O Filme foi atualizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }
        //HTTP Delete
        //Carrega a pagina com os dados do filme para ter certeza que deseja deletar
        public IActionResult Delete(int? id)
        {

            //obtém o filme pelo id
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                return NotFound();
            }
            return View();
        }
        //HTTP Delete
        //Efetua a exclusão do filme, pegando o mesmo pelo ID
        [HttpPost]
        public IActionResult DeleteMovie(int? id)
        {
            //obter o filme por id
            var movie = _context.Movies.Find(id);

            if(movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            TempData["mensagem"] = "O Filme foi excluído com sucesso!";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteSelected(Movie movies, int? id)
        {
            var movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
