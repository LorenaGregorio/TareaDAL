using DALUdeO.DataClass;
using DALUdeO.Mapper;
using DALUdeO.Utils;
using Modelos.Persona;
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
    class PersonaReader : ObjectReadaWithConnection<PersonaModel>
    {
        private string DefaultCommad = "SELECT * FROM odeodal.persona";
        public PersonaReader()
        {

        }
        public PersonaReader(TipoQuery tipo, PersonaModel personaModel)
        {
            switch (tipo)
            {
                case TipoQuery.Todos:
                    this.DefaultCommad = QueryProcessor.QueryAll(QuerysRepo.SelectAll, "odeodal.persona");
                    break;
                case TipoQuery.PorId:
                    this.DefaultCommad = QueryProcessor.QueryByID(QuerysRepo.SelectByID, "odeodal.persona", "idpersona", personaModel.IdPersona.ToString());
                    break;
                case TipoQuery.TodosConFiltros:
                    this.DefaultCommad = QueryProcessor.QueryAll(QuerysRepo.SelectAll, "odeodal.persona", personaModel);
                    break;
                case TipoQuery.PorIdConFiltro:

                    break;
                default:
                    break;
            }
        }
        protected override string CommandText => DefaultCommad;

        protected override CommandType CommandType => CommandType.Text;

        protected override Collection<IDataParameter> GetParameters(IDbCommand commnad)
        {
            Collection<IDataParameter> collection = new Collection<IDataParameter>();
            return collection;
        }
        protected override MapperBase<PersonaModel> GetMapper()
        {
            MapperBase<PersonaModel> mapper = new PersonaMapper();
            return mapper;
        }
    }
}
