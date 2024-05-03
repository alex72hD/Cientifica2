using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cientifica.Shared.Entities
{
    public class Asignacion
    {

        public int Id { get; set; }
        [JsonIgnore]
        public ProyectoDeInvestigacion ProyectoDeInvestigacion { get; set; }
        public int ProyectoDeInvestigacionId { get; set; }
        [JsonIgnore]
        public RecursosE RecursosE { get; set; }
        public int RecursosEId { get; set; }

        [JsonIgnore]
       

        public ICollection<ActividadesDeInvestigacion>? ActividadesDeInvestigaciones { get; set; }

        


    }
}
