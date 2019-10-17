using Models.Dao;
using Persistence.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Persistence.SqlServer.Repositories
{
    public class MecanicoRepository : RepositorySqlServer, IMecanicoRepository
    {

        public MecanicoRepository(SqlConnection context, SqlTransaction transaction) : base(context, transaction)
        {
        }

        public IEnumerable<Mecanico> GetAll()
        {
            var result = new List<Mecanico>();

            var command = CreateCommand("EXEC mecanicos_sp_leer_todos");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Mecanico
                    {
                        Celular = Convert.ToString(reader["celular"]),
                        Direccion = Convert.ToString(reader["direccion"]),
                        Documento = Convert.ToInt32(reader["documento"]),
                        Email = Convert.ToString(reader["email"]),
                        Estado = Convert.ToString(reader["estado"]),
                        PrimerApellido = Convert.ToString(reader["primer_apellido"]),
                        PrimerNombre = Convert.ToString(reader["primer_nombre"]),
                        SegundoApellido = Convert.ToString(reader["segundo_apellido"]),
                        SegundoNombre = Convert.ToString(reader["segundo_nombre"]),
                        TipoDocumento = Convert.ToString(reader["tipo_documento"]),
                    });
                }
            }

            return result;
        }

        public Mecanico Get(Mecanico model)
        {
            throw new NotImplementedException();
        }

        public void Create(Mecanico model)
        {
            const string query = @"
            EXEC mecanicos_sp_crear
                 @tipo_documento,
                 @documento,
                 @primer_nombre,
                 @segundo_nombre,
                 @primer_apellido,
                 @segundo_apellido,
                 @celular,
                 @direccion,
                 @email,
                 @estado
            ";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@tipo_documento", model.TipoDocumento);
            command.Parameters.AddWithValue("@documento", model.Documento);
            command.Parameters.AddWithValue("@primer_nombre", model.PrimerNombre);
            command.Parameters.AddWithValue("@segundo_nombre", (object)model.SegundoNombre ?? DBNull.Value);
            command.Parameters.AddWithValue("@primer_apellido", model.PrimerApellido);
            command.Parameters.AddWithValue("@segundo_apellido", (object)model.SegundoApellido ?? DBNull.Value);
            command.Parameters.AddWithValue("@celular", model.Celular);
            command.Parameters.AddWithValue("@direccion", model.Direccion);
            command.Parameters.AddWithValue("@email", model.Email);
            command.Parameters.AddWithValue("@estado", model.Estado);

            command.ExecuteNonQuery();
        }

        public void Update(Mecanico model)
        {
            const string query = @"
            EXEC mecanicos_sp_actualizar
                 @tipo_documento,
                 @documento,
                 @primer_nombre,
                 @segundo_nombre,
                 @primer_apellido,
                 @segundo_apellido,
                 @celular,
                 @direccion,
                 @email,
                 @estado
            ";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@tipo_documento", model.TipoDocumento);
            command.Parameters.AddWithValue("@documento", model.Documento);
            command.Parameters.AddWithValue("@primer_nombre", model.PrimerNombre);
            command.Parameters.AddWithValue("@segundo_nombre", (object)model.SegundoNombre ?? DBNull.Value);
            command.Parameters.AddWithValue("@primer_apellido", model.PrimerApellido);
            command.Parameters.AddWithValue("@segundo_apellido", (object)model.SegundoApellido ?? DBNull.Value);
            command.Parameters.AddWithValue("@celular", model.Celular);
            command.Parameters.AddWithValue("@direccion", model.Direccion);
            command.Parameters.AddWithValue("@email", model.Email);
            command.Parameters.AddWithValue("@estado", model.Estado);

            command.ExecuteNonQuery();
        }

        public void Remove(Mecanico model)
        {
            const string query = @"
            EXEC mecanicos_sp_eliminar
                 @tipo_documento,
                 @documento
            ";
            var command = CreateCommand(query);

            command.Parameters.AddWithValue("@tipo_documento", model.TipoDocumento);
            command.Parameters.AddWithValue("@documento", model.Documento);

            command.ExecuteNonQuery();
        }
    }
}
