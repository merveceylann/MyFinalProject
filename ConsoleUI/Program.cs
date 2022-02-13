using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

//Open Closed Principle
//ProductManager productManager = new ProductManager(new InMemoryProductDal());

//DTO Data Transformation Object
//ProductTest();
ProductTest1();
//CategoryTest();

static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var item in productManager.GetByUnitPrice(40, 100).Data)
    {
        Console.WriteLine(item.ProductName);
    }
}
static void ProductTest1()
{
    ProductManager productManager = new ProductManager(new EfProductDal());
    var result = productManager.GetProductDetails();
    if (result.Success)
    {
        foreach (var item in result.Data)
        {
            Console.WriteLine(item.ProductName + " / " + item.CategoryName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
    //foreach (var item in productManager.GetProductDetails().Data)
    //{
    //    Console.WriteLine(item.ProductName + " / " + item.CategoryName);
    //}
}
static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}


