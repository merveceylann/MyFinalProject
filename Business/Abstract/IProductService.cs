﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        //List<Product> GetAll();
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);  //bunlarin tamamini birer istek haline getirecegim
        IResult Update(Product product); 

        //RESTFUL --> HTTP / TCP
        //(http: bir kaynaga ulasmak icin izledigimiz yol)
    }
}
