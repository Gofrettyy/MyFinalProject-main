using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;


public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
{
        
}
