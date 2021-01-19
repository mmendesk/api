using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesApi.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do filme é obrigatório!")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no minimo {2} e no máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Filme")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A data é obrigatória!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Criação")]
        public DateTime DTCreate { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Ativo?")]
        public TypeFilter Active { get; set; }
        [Display(Name = "Gênero")]
        public Gender Genders { get; set; }
        public int GenderId { get; set; }
    }
}