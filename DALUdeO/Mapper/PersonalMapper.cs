using Modelos.Personal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALUdeO.Mapper
{
    class PersonalMapper : MapperBase<PersonalModel>
    {
        protected override PersonalModel Map(IDataRecord registro)
        {
            try
            {
                PersonalModel Personal = new PersonalModel
                {
                    IdPersona = registro["IdPersonal"] == DBNull.Value ? 0 : (int)registro["IdPersonal"],
                    Nombres = registro["Nombres"] == DBNull.Value ? string.Empty : (string)registro["Nombres"],
                    Apellidos = registro["Apellidos"] == DBNull.Value ? string.Empty : (string)registro["Apellidos"],
                    Direccion = registro["Direccion"] == DBNull.Value ? string.Empty : (string)registro["Direccion"],
                    Area = registro["Area"] == DBNull.Value ? string.Empty : (string)registro["Area"],
                    Puesto = registro["Puesto"] == DBNull.Value ? string.Empty : (string)registro["Puesto"],
                    HoraEntrada = registro["HoraEntrada"] == DBNull.Value ? DateTime.Today : (DateTime)registro["HoraEntrada"],
                    HoraSalida = registro["HoraSalida"] == DBNull.Value ? DateTime.Today : (DateTime)registro["HoraSalida"],
                    HoraSalidaComida = registro["HoraSalidaComida"] == DBNull.Value ? DateTime.Today : (DateTime)registro["HoraSalidaComida"],
                    HoraEntradaComida = registro["HoraEntradaComida"] == DBNull.Value ? DateTime.Today : (DateTime)registro["HoraEntradaComida"],
                    



                };
                return Personal;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
