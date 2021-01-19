using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesApi.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public List<Movie> Movies { get; set; }
        public string NameMovie { get; set; }
        [Display(Name = "CPF do Cliente")]
        [Required(ErrorMessage = "O CPF deve ser informado!")]
        public int CpfClient { get; set; }
        [Required(ErrorMessage = "A data é obrigatória!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Locação")]
        public DateTime DTLocation { get; set; }
    }
}