using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesApi.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do gênero é obrigatório!")]
        [StringLength(100, ErrorMessage = "O {0} deve ter no minimo {2} e no máximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Gênero")]
        public string NameGender { get; set; }
        [Required(ErrorMessage = "A data é obrigatória!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Criação")]
        public DateTime DTCreate { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Ativo")]
        public TypeFilter Active { get; set; }
    }
}