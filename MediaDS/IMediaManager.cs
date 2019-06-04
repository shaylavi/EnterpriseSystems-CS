using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDS
{
    interface IMediaManager
    {
        DataSet ReadMovies(string datasetName);
        int CreateMovie(object title, object genre, object director, object language, object publishYear, object budget);
        int UpdateMovie(string updateField, object updateValue, string updateFieldCondition, object updateValueCondition);
        int DeleteMovie(string deleteFieldCondition, object deleteValueCondition);
    }
}
