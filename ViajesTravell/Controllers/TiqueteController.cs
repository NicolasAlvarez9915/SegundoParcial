using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ViajesTravell.Models;

namespace ViajesTravell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiqueteController: ControllerBase
    {
        private readonly TiqueteService _tiqueteService;
        public IConfiguration Configuration { get; }
        public TiqueteController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _tiqueteService = new TiqueteService(connectionString);
        }
        // GET: api/Persona
        [HttpGet]
        public IEnumerable<TiqueteViewModel> Gets()
        {
            var tiquetes = _tiqueteService.ConsultarTodos().Select(p=> new TiqueteViewModel(p));
            return tiquetes;
        }

        

        // POST: api/Persona
        [HttpPost]
        public ActionResult<TiqueteViewModel> Post(TiqueteInputModel tiqueteInput)
        {
            Tiquete tiquete = MapearTiquete(tiqueteInput);
            var response = _tiqueteService.Guardar(tiquete);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Tiquete);
        }

        private Tiquete MapearTiquete(TiqueteInputModel tiqueteInput)
        {
            var tiquete = new Tiquete
            {
                codigo = tiqueteInput.codigo,
                ruta = tiqueteInput.ruta,
                valor = tiqueteInput.valor,
                idCliente = tiqueteInput.idCliente
            };
            return tiquete;
        }

        // PUT: api/Persona/5
        [HttpPut("{identificacion}")]
        public ActionResult<string> Put(string identificacion, Persona persona)
        {
            throw new NotImplementedException();
        }


    }
}