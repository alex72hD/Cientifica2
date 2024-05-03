using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cientifica.Shared.Entities
{
    public class ActividadesDeInvestigacion
    {

        public int Id { get; set; }
        [Display(Name = "Nombre ")]
        [MaxLength(50, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción de la actividad")]
        [MaxLength(500, ErrorMessage = "El {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de inicio ")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]

        public DateTime FechaDeInicio { get; set; }

        [Display(Name = "Fecha de finalización")]
        [Required(ErrorMessage = "Este campo es obligatorio!")]

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeFinalizacion { get; set; }


        [JsonIgnore]
        public Asignacion Asignaciones { get; set; }
        public int AsignacionId { get; set; }

    }
}
