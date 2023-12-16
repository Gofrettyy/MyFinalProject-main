using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;

namespace DataAccess.Abstract;

public interface IProductDal:IEntityRepository<Product>
{
 List<ProductDetailDto> GetProductDetails();

 
}