using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Datos
{
    public class TiqueteRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Tiquete> _tiquetes = new List<Tiquete>();

        public TiqueteRepository(ConnectionManager connection){
            _connection = connection._conexion;
        }

        public void Guardar(Tiquete tiquete)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into tiquete (codigo, ruta, valor, idCliente) 
                                        values (@codigo, @ruta, @valor, @idcliente)";
                command.Parameters.AddWithValue("@codigo", tiquete.codigo);
                command.Parameters.AddWithValue("@ruta", tiquete.ruta);
                command.Parameters.AddWithValue("@valor", tiquete.valor);
                command.Parameters.AddWithValue("@idCliente", tiquete.idCliente);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<Tiquete> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Tiquete> tiquetes = new List<Tiquete>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from tiquete ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Tiquete tiquete = DataReaderMapToPerson(dataReader);
                        tiquetes.Add(tiquete);
                    }
                }
            }
            return tiquetes;
        }

        

        private Tiquete DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Tiquete tiquete = new Tiquete();
            tiquete.codigo = (int)dataReader["codigo"];
            tiquete.ruta = (string)dataReader["ruta"];
            tiquete.valor = (double)dataReader["valor"];
            tiquete.idCliente = (string)dataReader["idCliente"];
            return tiquete;
        }
    }
}