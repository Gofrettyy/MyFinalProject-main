using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

//NuGetten .Net Framework Core Sql Server indirdik.
//Artık dataacces üzerinde entity framework core kodu yazabiliriz.
public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
{
    private IProductDal _productDalImplementation;

    public List<ProductDetailDto> GetProductDetails()
    {
        using (NorthwindContext context = new NorthwindContext())
        {
            var result = from p in context.Products
                join c in context.Categories
                    on p.CategoryId equals c.CategoryId
                select new ProductDetailDto
                {
                    ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock =
                    p.UnitsInStock };
                    return result.ToList();
               
        }
    }

   

   
}