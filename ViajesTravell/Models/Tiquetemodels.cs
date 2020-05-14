using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Entity;

namespace ViajesTravell.Models
{

    public class TiqueteInputModel
    {
        public int codigo { get; set; }
        public string ruta { get; set; }
        public double valor { get; set; }
        public string idCliente { get; set; }
    }

    public class TiqueteViewModel : TiqueteInputModel
    {
        public TiqueteViewModel()
        {

        }
        public TiqueteViewModel(Tiquete tiquete)
        {
            codigo = tiquete.codigo;
            ruta = tiquete.ruta;
            valor = tiquete.valor;
            idCliente = tiquete.idCliente;
        }
    }

    
}