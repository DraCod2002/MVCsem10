using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCsem10.Models
{
    public class Producto 
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string descripcion { get; set; }
    }
}