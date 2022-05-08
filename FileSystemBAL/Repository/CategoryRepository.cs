using FileSystemBAL.Category.Models;
using FileSystemBAL.Data;
using FileSystemBAL.Repository.IRepository;
using FileSystemUtility.Models;
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
            return moDatabaseContext.Set<CategoryListResult>().FromSqlInterpolated($"EXEC getCategoryList").ToList();
        }

        public FileSystemBAL.Category.Models.Category GetCategory(Guid unCategoryId)
        {

            return moDatabaseContext.Set<FileSystemBAL.Category.Models.Category>().FromSqlInterpolated($"EXEC getCategoryDetail @unCategoryId={unCategoryId}").AsEnumerable().FirstOrDefault();

        }

        public List<Select2> GetCategoryDropDown()
        {
            return moDatabaseContext.Set<Select2>().FromSqlInterpolated($"EXEC getCategoryDropDown").ToList();
        }

        public void SaveCategory(Category.Models.Category foCategory, int fiUserId,out int fiSuccesss)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC saveCategory @unCategoryId={foCategory.unCategoryId}, @inCategoryId={foCategory.inCategoryId},@inDepartmentId={foCategory.inDepartmentId},@inStatus={foCategory.inStatus},@inParentCategoryId={foCategory.inParentCategoryId},@stCategoryName={foCategory.stCategoryName},@inCreatedBy={fiUserId},@inSuccess={loSuccess} OUT");
            fiSuccesss = Convert.ToInt32(loSuccess.Value);
        }
    }
}
