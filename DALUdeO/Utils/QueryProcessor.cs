using Modelos.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DALUdeO.Utils
{
    public static class QueryProcessor
    {
        // LAS VARIABLES TRATA SOBRE LA BASE DE DATOS 
        public static string QueryByID(string query, string NombreTabla, string NombreColumna, string IdCampo)
        {
            return query.Replace("TABLA", NombreTabla).Replace("COLUMNAID", NombreColumna).Replace("ID", IdCampo.ToString());
        }

        public static string QueryAll(string query, string NombreTabla)
        {
            return query.Replace("TABLA", NombreTabla);
        }
        public static string QueryByID(string query, string NombreTabla, string NombreColumna, int IdCampo, object DataModel)
        {
            return query.Replace("TABLA", NombreTabla).Replace("COLUMNAID", NombreColumna).Replace("ID", IdCampo.ToString()) + " WHERE " + ProcessDataModel(DataModel);
        }

        public static string QueryAll(string query, string NombreTabla, object DataModel)
        {
            return query.Replace("TABLA", NombreTabla) + " WHERE " + ProcessDataModel(DataModel);
        }
        private static string ProcessDataModel(object DataModel)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var propertyInfo in DataModel.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(DataModel) != null)
                {
                    sb.Append(propertyInfo.Name + " = " + " '" + propertyInfo.GetValue(DataModel).ToString() + "' AND ");
                }
            }
             

            return sb.ToString().Substring(0, sb.ToString().Length - 4);
        }
    }
}
