using Model.EF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public class CategoryRequest
    {

        public long? categoryId { get; set; }

        public string categoryName { get; set; }

        public List<CategoryRequest> childrens { get; set; }


        public static List<CategoryRequest> GenTreeView(List<Category> categories)
        {
            return CategoryRequest.GenTreeView(categories, null);
        }

        public static List<CategoryRequest> GenTreeView(List<Category> categories, long? parentId)
        {
            List<CategoryRequest> listLvX = new List<CategoryRequest>();
            CategoryRequest node;
            foreach (Category item in categories)
            {
                if ((((item.ParentID == null) && (parentId == null))
                            || ((item.ParentID != null) && (item.ParentID == parentId))))
                {
                    node = new CategoryRequest()
                    {
                        categoryId = item.ParentID,
                        categoryName = item.Typename,
                        childrens = (CategoryRequest.GenTreeView(categories, item.CategoryID))
                    };

                    listLvX.Add(node);
                }

            }

            return listLvX;
        }
    }
}