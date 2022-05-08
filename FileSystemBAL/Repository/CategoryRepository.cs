using FileSystemBAL.Category.Models;
using FileSystemBAL.Data;
using FileSystemBAL.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemBAL.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly DatabaseContext moDatabaseContext;
        public CategoryRepository(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
        }
        public List<CategoryListResult> GetCategoriesList()
        {
            return moDatabaseContext.Set<CategoryListResult>().FromSqlInterpolated($"EXEC getCategoriesList ").ToList();
        }

        public Category GetCategory(Guid unCategoryId)
        {

            return moDatabaseContext.Set<Category>().FromSqlInterpolated($"EXEC getCategoryDetail @unCategoryId={unCategoryId}").AsEnumerable().FirstOrDefault();

        }

        public void SaveCategory(Category.Models.Category foCategory, int fiUserId,out int fiSuccesss)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC saveCategory @inCategoryId={foCategory.inCategoryId},@inParentCategoryId={foCategory.inParentCategoryId},@stCategoryName={foCategory.stCategoryName},@flgIsActive={foCategory.flgIsActive},@inCreatedBy={fiUserId},@inSuccess={loSuccess} OUT");
            fiSuccesss = Convert.ToInt32(loSuccess.Value);
        }
    }
}
