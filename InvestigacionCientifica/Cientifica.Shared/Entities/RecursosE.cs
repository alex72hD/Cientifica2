using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cientifica.Shared.Entities
{
     public class RecursosE
    {
        public int Id { get; set; }
        [Display(Name = "nombre del recurso")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string nombre { get; set; }
        [Display(Name ="cantidad")]
        [MaxLength(35, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public int cantidad { get; set; }
        [Display(Name = "nombre del proveedor")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string proveedor { get; set;}

        [Display(Name = "Fecha de entrega estimada")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]

        public DateTime entrega { get; set; }
        [JsonIgnore]

        public ICollection<Asignacion> Asignaciones { get; set; }



    }
}
