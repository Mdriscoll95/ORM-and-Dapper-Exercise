using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using ORM_Dapper;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);


var repo = new DapperProductRepository(conn);

Console.WriteLine("what is the name of your new product");
var prodName = Console.ReadLine();

Console.WriteLine("what is the price");
var prodPrice = double.Parse(Console.ReadLine());


Console.WriteLine("what is the catagory id?");
var prodCat = int.Parse(Console.ReadLine());

repo.CreateProduct(prodName, prodPrice, prodCat);


ReadData();


Console.WriteLine("what is the Product ID you want to update");
var prodID = int.Parse(Console.ReadLine());

Console.WriteLine("what is the new product name");
var newName = Console.ReadLine();

repo.UpdateProduct(prodID, newName);

ReadData();
Console.WriteLine("what is the product ID you want to delete?");
prodID = int.Parse(Console.ReadLine());
repo.DeleteProduct(prodID);
ReadData();



Console.ReadLine();































void ReadData()
{
    var prodList = repo.GetAllProducts();

    foreach (var prod in prodList)
    {
        Console.WriteLine($"{prod.ProductID} - {prod.Name}");
    }
}