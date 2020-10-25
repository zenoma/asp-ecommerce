using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.MusicDao
{
    class MusicDaoEntityFramework :
        GenericDaoEntityFramework<Music, Int64>, IMusicDao
    {
        List<Music> IMusicDao.FindByAlbum(String album)
        {
            DbSet<Music> music = Context.Set<Music>();

            List<Music> result = (from m in music
                                  where m.album.Contains(album)
                                  orderby m.album
                                  select m).ToList();

            return result;
        }

        public List<Music> FindByArtist(string artist)
        {
            DbSet<Music> music = Context.Set<Music>();

            List<Music> result = (from m in music
                                  where m.artist.Contains(artist)
                                  orderby m.artist
                                  select m).ToList();

            return result;
        }
    }
}
