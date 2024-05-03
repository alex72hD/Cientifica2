using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cientifica.Shared.Entities
{
     public class Participacion
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Investigador Investigadores { get; set; }
        public int InvestigadorId { get; set; }
        [JsonIgnore]
        public ProyectoDeInvestigacion ProyectoDeInvestigaciones { get; set; }
        public int ProyectoDeInvestigacionId { get; set; }  



    }
}
