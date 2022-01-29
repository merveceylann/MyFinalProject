using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
//using DataAccess.Concrete.InMemory;
//Open Closed Principle
//ProductManager productManager = new ProductManager(new InMemoryProductDal());
ProductManager productManager = new ProductManager(new EfProductDal());

foreach (var item in productManager.GetByUnitPrice(40,100))
{
    Console.WriteLine(item.ProductName);
}