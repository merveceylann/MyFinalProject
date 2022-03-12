using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //bir is sinifi baska bir sinifi newlemez
        //ayni anda birden fazla sonuc dondurmek istersem encapsulation 
        IProductDal _productDal;
        //ILogger _logger;

        //ICategoryDal _categoryDal; bunu yapayiz
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            //_logger = logger;
        }

        //Claim
        [SecuredOperation("admin,editor")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes
            //validation 

            //if (product.ProductName.Length < 2)
            //{
            //    //magic strings
            //    //return new ErrorResult("Urun ismi min 2 karekter olmalidir.");
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}
            //if calisirsa return result olacagi icin else gerek yok 

            //ValidationTool.Validate(new ProductValidator(), product);

            //loglama
            //cacheremove
            //performance
            //transaction
            //yetkilendirme

            //business codes

            //_logger.Log();
            //try
            //{
            //    _productDal.Add(product);

            //    //return new SuccessResult("Urun Eklendi");
            //    return new SuccessResult(Messages.ProductAdded);
            //}
            //catch (Exception exception)
            //{
            //    throw;
            //}
            //return new ErrorResult();

            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            //{
            //    if (CheckIfProductNameExists(product.ProductName).Success)
            //    {
            //        _productDal.Add(product);

            //        //return new SuccessResult("Urun Eklendi");
            //        return new SuccessResult(Messages.ProductAdded);
            //    }
            //}
            //return new ErrorResult();

            //burada polimorphism var
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName), CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());

            if (result != null) //yani kurala uymayan bir durum olustuysa
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //is kodlari
            //return _ProductDal.GetAll();
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //return new DataResult<List<Product>>(_productDal.GetAll(), true, "Urunler Listelendi");
            return new DataResult<List<Product>>(_productDal.GetAll(), true, Messages.ProductListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //bir kategoride en fazla 10 urun olabilir

            //select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult(); //mesaja gerek yok burada cunku kuraldan geciyo
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            //ayni isimde urun eklenemez

            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            //mevcut category sayisi 15i gectiyse sisteme yeni urun eklenemez

            //var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Distinct().Count();
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

    }
}

