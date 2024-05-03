using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cientifica.Shared.Entities
{
     public class Publicacion
    {
        public int Id { get; set; }
        [Display(Name ="titulo")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string titulo { get; set; }
        [Display(Name = "autor(es)")]
        [MaxLength(150, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string autores { get; set; }
        [Display(Name = "Fecha de publicacion")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]

        [DisplayFormat(DataFormatString = "{yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime fechapu { get; set; }
        [JsonIgnore]

        public ProyectoDeInvestigacion ProyectoDeInvestigaciones { get; set; }
        public int ProyectoDeinvestigacion { get; set; }


    }
}
