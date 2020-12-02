using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.ECommerceServices.CategoryService
{
    public class CategoryBlock
    {
        public List<Category> Categories { get; private set; }
        public bool ExistMoreCategories{ get; private set; }

        public CategoryBlock(List<Category> categories, bool existMoreCategories)
        {
            this.Categories = categories;
            this.ExistMoreCategories = existMoreCategories;
        }
    }
}
