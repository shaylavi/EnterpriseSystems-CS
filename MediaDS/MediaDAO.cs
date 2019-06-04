using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDS
{
    /// <summary>
    /// Proxy the actions against the database to specific actions for the media data
    /// </summary>
    public class MediaDAO : IMediaManager
    {
        CRUDManager crud;
        public MediaDAO()
        {
            crud = new CRUDManager();
        }

        public DataSet ReadMovies(string datasetName)
        {
            DataSet results = (DataSet)crud.ExecuteSqlStatement("SELECT * FROM ViewMedia", "Movies");
            return results;
        }
        public int CreateMovie(object title, object genre, object director, object language, object publishYear, object budget)
        {
            Dictionary<string, object> sqlParams = new Dictionary<string, object>();
            sqlParams.Add("@title", title);
            sqlParams.Add("@genre", genre);
            sqlParams.Add("@director", director);
            sqlParams.Add("@language", language);
            sqlParams.Add("@publishyear", publishYear);
            sqlParams.Add("@budget", budget);
            return (int)crud.ExecuteSqlStatement("INSERT INTO TabMedia VALUES (?,?,?,?,?,?)", "Movie", sqlParams);
        }
        public int UpdateMovie(string updateField, object updateValue, string updateFieldCondition, object updateValueCondition)
        {
            Dictionary<string, object> sqlParams = new Dictionary<string, object>();
            sqlParams.Add("@var1", updateValue);
            sqlParams.Add("@var2", updateValueCondition);
            string conditionVariableType = (updateValueCondition is double) ? updateValueCondition.ToString() : (updateValueCondition is int) ? updateValueCondition.ToString() : "'" + updateValueCondition + "'";
            string valueVariableType = (updateValue is double) ? updateValue.ToString() : (updateValue is int) ? updateValue.ToString() : "'" + updateValue + "'";
            return (int)crud.ExecuteSqlStatement(string.Format("UPDATE TabMedia SET [{0}]= {1} WHERE [{2}]= {3}", updateField, valueVariableType, updateFieldCondition, conditionVariableType), "Movie", sqlParams);
        }
        public int DeleteMovie(string deleteFieldCondition, object deleteValueCondition)
        {
            Dictionary<string, object> sqlParams = new Dictionary<string, object>();
            string variableType = (deleteValueCondition is double) ? deleteValueCondition.ToString() : (deleteValueCondition is int) ? deleteValueCondition.ToString() : "'%" + deleteValueCondition + "%'";
            return (int)crud.ExecuteSqlStatement(string.Format("DELETE FROM TabMedia WHERE {0} LIKE {1}", deleteFieldCondition, variableType), "Movie");
        }
    }
}
