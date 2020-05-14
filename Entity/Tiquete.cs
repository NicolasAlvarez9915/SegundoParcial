using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Tiquete
    {
        public int codigo { get; set; }
        public string ruta { get; set; }
        public double valor { get; set; }
        public string idCliente { get; set; }
    }
}