using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALUdeO.DataClass
{
    
    public static class QuerysRepo
    {
     


        public const string SelectAll = "SELECT * FROM odeodal.persona";
        public const string SelectByID = "SELECT * FROM odeodal.persona WHERE idpersona = ID";
        public const string SelectAllByFilters = "SELECT * FROM odeodal.persona ";
        public const string SelectByIDByFilters = "SELECT * FROM odeodal.persona WHERE idpersona = ID";

        public enum TipoQuery { Todos, PorId, TodosConFiltros, PorIdConFiltro, ConFiltros }

        public const string InsertAll = "insert into personaltbl (Nombres, Apellidos, Direccion, Area, Puesto,HoraEntrada, HoraSalida, HoraSalidaComida,HoraEntradaComida) " +
            "values ('Juan', 'Morales', 'Zona 12 por el Tren', 'Cocina', 'Compradora',' 2019-05-10 07:59:00', '2019-05-10 17:59:25 ', '2019-05-10 12:59:25', '2019-05-10 13:59:25' ) ";


        public static object InsertByID { get; internal set; }

        public enum TipoQuery2 { Todos, PorId, TodosConFiltros, PorIdConFiltro }

    }
}
