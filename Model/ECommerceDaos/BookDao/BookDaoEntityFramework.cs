using Es.Udc.DotNet.ModelUtil.Dao;
using System;

namespace Es.Udc.DotNet.PracticaMaD.Model.Model1Daos.BookDao
{
    public class BookDaoEntityFramework : GenericDaoEntityFramework<Book, Int64>, IBookDao
    {
    }
}
