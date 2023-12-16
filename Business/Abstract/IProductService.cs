using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO;


namespace Business.Abstract;

public interface IProductService
{
    IDataResult<List<Product>> GetAll();
    IDataResult<List<Product>> GetAllByCategoryId(int id);
    IDataResult<Product> GetById(int productId);
    IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
    IDataResult<List<ProductDetailDto>> GetProductDetails();
    IResult Update(Product product);
    IResult Add(Product product);
    IResult AddTransactionalTest(Product product);

}