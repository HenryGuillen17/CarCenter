using Models.Dao;
using Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Models.Factory
{
    public static class MecanicoFactory
    {
        public static Mecanico ToMecanicoDao(this MecanicoDto model)
        {
            return new Mecanico
            {
                Celular = model.Celular,
                Direccion = model.Direccion,
                Documento = model.Documento,
                Email = model.Email,
                Estado = model.Estado,
                PrimerApellido = model.PrimerApellido,
                PrimerNombre = model.PrimerNombre,
                SegundoApellido = model.SegundoApellido,
                SegundoNombre = model.SegundoNombre,
                TipoDocumento = model.TipoDocumento
            };
        }

        public static IEnumerable<MecanicoDto> ToMecanicoDto(this IEnumerable<Mecanico> list)
        {
            return list.Select(model => new MecanicoDto
            {
                Celular = model.Celular,
                Direccion = model.Direccion,
                Documento = model.Documento,
                Email = model.Email,
                Estado = model.Estado,
                PrimerApellido = model.PrimerApellido,
                PrimerNombre = model.PrimerNombre,
                SegundoApellido = model.SegundoApellido,
                SegundoNombre = model.SegundoNombre,
                TipoDocumento = model.TipoDocumento
            });
        }
    }
}
