using MediaDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Controller to proxy requests for the data access layer for media data
    /// </summary>
    public class MediaManager : IMediaManager
    {
        MediaDAO dal;
        public MediaManager()
        {
            dal = new MediaDAO();
        }

        public DataSet QueryMovies()
        {
            return dal.ReadMovies("Movies");
        }
        public int CreateMovie(object title, object genre, object director, object language, object publishYear, object budget)
        {
            return dal.CreateMovie(title, genre, director, language, publishYear, budget);
        }
        public int UpdateMovie(string updateField, object updateValue, string updateFieldCondition, object updateValueCondition)
        {
            return dal.UpdateMovie(updateField, updateValue, updateFieldCondition, updateValueCondition);
        }
        public int DeleteMovie(string deleteFieldCondition, object deleteValueCondition)
        {
            return dal.DeleteMovie(deleteFieldCondition, deleteValueCondition);
        }
    }
}
