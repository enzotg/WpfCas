using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCas.Models
{
    public class Equipo
    {
        
        public long EquipoId { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string MacAddress1 { get; set; }

        [MaxLength(50)]
        public string MacAddress2 { get; set; }
        
        [MaxLength(50)]
        public string Serial { get; set; }

        [MaxLength(50)]
        public string Pantalla { get; set; }

    }
}
