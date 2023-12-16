using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTO;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete;

public class ProductManager:IProductService
{
     IProductDal _productDal;
     ICategoryService _categoryService;
     private ICacheManager _cacheManager;

     public ProductManager(IProductDal productDal, ICategoryService categoryService,ICacheManager cacheManager)
     {
         _productDal = productDal;
         _categoryService = categoryService;
         _cacheManager = cacheManager;
     }
     
    [CacheAspect]
     public IDataResult<List<Product>> GetAll()
    {
        //Buraya iş kodları var ise onlar yazılır
     
       if (DateTime.Now.Hour == 24)
        {
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime!);
        }
        return new SuccessDataResult<List<Product>>( _productDal.GetAll(),Messages.ProductsListed);
    }

     public IDataResult<List<Product>>GetAllByCategoryId(int id)
     {
         return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
     }

     [CacheAspect]
     public IDataResult<Product> GetById(int productId)
     {
         return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
     }
    public IDataResult<List<Product>>GetByUnitPrice(decimal min, decimal max)
     {
         return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
     }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }
    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Update(Product product)
    {
        if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        return new ErrorResult();
    }
   
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Add(Product product) // ben özel bir tip döndürmüyorum demek void.
  
    {
      IResult result =  BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
        CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());
      if (result != null)
      {
          return result;
      }
        return new SuccessResult(Messages.ProductAdded);
            

     
        

        //iş kodları buraya yazılır.
       //validation :Yapısal olarak bizim kurallarımıza uygun olup olmadığıdır.
       // buraya ilerleyen zamanlarda Bussiness kodlar yazacağız.
       // Business kodları ise yönetimden gelen iş kurallarıdır.
       //ilgili nesnemizi doğrulamanın en iyi kod yöntemi bu.
    

       //sen bir istekte bulundun ama ben bundan dolayı ekleyemedim ya da ekledim gibi yapıları burada oluşturuyor olacağız.
    }

   // [TransactionScopeAspect]
    public IResult AddTransactionalTest(Product product)
    {
        throw new NotImplementedException();
    }

    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
        var result = _productDal.GetAll(p => p.CategoryId ==categoryId).Count;
        if (result>=10)
        {
            return new ErrorResult(Messages.ProductCountOfCategoryError);
        }

        return new SuccessResult();
        
    }

    private IResult CheckIfProductNameExist(string productName)
    {
        var result = _productDal.GetAll(p => p.ProductName == productName).Any();
        if (result)

        {
            return new ErrorResult(Messages.ProductNameAlreadyExists);
            
        }

        return new SuccessResult();
    }

    private IResult CheckIfCategoryLimitExceded()
    {
        var result = _categoryService.GetAll();
        if (result.Data.Count>15)
        {
            return new ErrorResult(Messages.CategoryLimitExceded);
        }

        return new SuccessResult();
    }
}