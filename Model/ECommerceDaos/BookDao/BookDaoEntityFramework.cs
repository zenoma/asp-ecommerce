using Es.Udc.DotNet.ModelUtil.Dao;
using Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.ProductDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.BookDao
{
    public class BookDaoEntityFramework : GenericDaoEntityFramework<Book, Int64>, IBookDao
    {
    }
}
