using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MovieDao
{
    public interface IMovieDao : ModelUtil.Dao.IGenericDao<Movie, Int64>
    {
    }
}
