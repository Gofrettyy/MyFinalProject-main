using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfOrderDal:EfEntityRepositoryBase<Order ,NorthwindContext> ,IOrderDal 
{
    public Order GetAll(Expression<Func<Order, bool>> filter)
    {
        throw new NotImplementedException();
    }
}