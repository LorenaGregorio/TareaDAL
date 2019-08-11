using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Persona;
namespace DALUdeO.Mapper
{
    class PersonaMapper : MapperBase<PersonaModel>
    {
        protected override PersonaModel Map(IDataRecord registro)
        {
            try
            {
                PersonaModel Persona = new PersonaModel
                {
                    IdPersona = registro["idpersona"] == DBNull.Value ? 0 : (int)registro["idpersona"],
                    Nombre = registro["Nombre"] == DBNull.Value ? string.Empty : (string)registro["Nombre"],
                    Apellido = registro["Apellido"] == DBNull.Value ? string.Empty : (string)registro["Apellido"],
                    Direccion = registro["Direccion"] == DBNull.Value ? string.Empty : (string)registro["Direccion"]
                };
                return Persona;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
