using DALUdeO.DataClass;
using DALUdeO.Mapper;
using DALUdeO.Utils;
using Modelos.Personal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DALUdeO.DataClass.QuerysRepo;

namespace DALUdeO.Reader
{
    class PersonalReader : ObjectReadaWithConnection<PersonalModel>
    {
        private string DefaultCommad = "insert into personaltbl(IdPersonal, Nombre,Apellidos, Direccion,Area,Puesto )"; //modifique

        //revisar
        public PersonalReader()
        {

        }
        public PersonalReader(TipoQuery2 tipo, PersonalModel personalModel)
        {
            switch (tipo)
            {
                case TipoQuery2.Todos:
                    this.DefaultCommad = QueryProcessor.QueryAll(QuerysRepo.InsertAll, "odeodal.personaltbl");
                    break;
                case TipoQuery2.PorId:
                    this.DefaultCommad = QueryProcessor.QueryByID(QuerysRepo.InsertByID, "odeodal.personaltbl", "IdPersonal", personalModel.IdPersonal.ToString());
                    break;
                case TipoQuery2.TodosConFiltros:
                    this.DefaultCommad = QueryProcessor.QueryAll(QuerysRepo.InsertAll, "odeodal.personatbl", personalModel);
                    break;
                case TipoQuery2.PorIdConFiltro:

                    break;
                default:
                    break;
            }
        }




        protected override string CommandText => DefaultCommad;

        protected override CommandType CommandType => CommandType.Text;

        protected override MapperBase<PersonalModel> GetMapper()
        {
            MapperBase<PersonalModel> mapper = new PersonalMapper();
            return mapper;
        }

    

        protected override Collection<IDataParameter> GetParameters(IDbCommand commnad)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
    }
}
