using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entity;

namespace Logica {
    public class TiqueteService {
        private readonly ConnectionManager _conexion;
        private readonly TiqueteRepository _repositorio;

        public TiqueteService (string ConnectionString) {
            _conexion = new ConnectionManager (ConnectionString);
            _repositorio = new TiqueteRepository (_conexion);
        }

        public GuardarTiqueteResponse Guardar (Tiquete tiquete) {
            try {
                _conexion.Open ();
                _repositorio.Guardar (tiquete);
                _conexion.Close ();
                return new GuardarTiqueteResponse (tiquete);
            } catch (Exception e) {
                return new GuardarTiqueteResponse ($"Error de la Aplicacion: {e.Message}");
            } finally { _conexion.Close (); }
        }

        public List<Tiquete> ConsultarTodos () {
            _conexion.Open ();
            List<Tiquete> tiquetes = _repositorio.ConsultarTodos ();
            _conexion.Close ();
            return tiquetes;
        }

    }

    public class GuardarTiqueteResponse {
        public GuardarTiqueteResponse (Tiquete tiquete) {
            Error = false;
            _tiquete = tiquete;
        }
        public GuardarTiqueteResponse (string mensaje) {
            Error = true;
            Mensaje = mensaje;
        }
        public GuardarTiqueteResponse (bool error, string mensaje, Tiquete _tiquete) {
            this.Error = error;
            this.Mensaje = mensaje;
            this._tiquete = _tiquete;

        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Tiquete _tiquete { get; set; }
        public object Tiquete { get; set; }
    }
}