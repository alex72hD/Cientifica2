using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cientifica.Shared.Entities
{
    public class Investigador
    {
        public int Id { get; set; }
        [Display(Name ="nombre")]
        [MaxLength(38, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string nombre { get; set; }
        [Display(Name ="especialidad")]
        [MaxLength(65, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]

        public string especialidad { get; set;}
        [Display(Name ="afiliacion")]
        [MaxLength(80, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string afiliacion { get; set;}


        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 Caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [EmailAddress(ErrorMessage = "Digite un Email válido")]
        public string Email { get; set; }



        [JsonIgnore]

        public ICollection<Participacion> Participaciones { get; set; }

    }
}
