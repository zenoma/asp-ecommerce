using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MovieDao
{
    public class MovieDaoEntityFramework : GenericDaoEntityFramework<Movie, Int64>, IMovieDao
    {
    }
}
