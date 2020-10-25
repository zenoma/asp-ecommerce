using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MusicDao
{
    interface IMusicDao : IGenericDao<Music, Int64>
    {
        List<Music> FindByAlbum(String album);

        List<Music> FindByArtist(String artist);
    }
}
