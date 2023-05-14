using System.Text;
using Template.Core.Models;
using Newtonsoft.Json;
using Template.Core.Contracts.Services;

namespace SalesManagerCore;

public class Data
{
    public static Statistics statistics = new(new SalesManager());
    public static string productsPath = "";
    public static string customersPath = "";
    public static string ordersPath = "";

    public static void Save(List<Order> list)
    {        
        statistics.SalesManager.Orders.Clear();

        foreach (Order order in list)
        {
            statistics.SalesManager.CreateOrder(order);
        }

        if (string.IsNullOrWhiteSpace(ordersPath))
        {
            return;
        }
        var orderDictionary = new Dictionary<string, List<Order>>
        {
            { "Orders", statistics.SalesManager.Orders.Values.ToList() }
        };

        string json = JsonConvert.SerializeObject(orderDictionary, Formatting.Indented);
        File.WriteAllText(ordersPath, json);
    }

    public static void Save(List<Product> list)
    {       
        statistics.SalesManager.Products.Clear();
        
        foreach (var order in list)
        {
            statistics.SalesManager.AddProduct(order);
        }

        if (string.IsNullOrWhiteSpace(productsPath))
        {
            return;
        }
        var productDictionary = new Dictionary<string, List<Product>>
        {
            { "Products",  statistics.SalesManager.Products.Values.ToList() }
        };

        string json = JsonConvert.SerializeObject(productDictionary, Formatting.Indented);
        File.WriteAllText(productsPath, json);
    }

    public static void Save(List<Customer> list)
    {     
        statistics.SalesManager.Customers.Clear();

        foreach (var order in list)
        {
            statistics.SalesManager.AddCustomer(order);
        }

        if (string.IsNullOrWhiteSpace(customersPath))
        {
            return;
        }
        var customerDictionary = new Dictionary<string, List<Customer>>
        {
            { "Customers", statistics.SalesManager.Customers.Values.ToList() }
        };

        string json = JsonConvert.SerializeObject(customerDictionary, Formatting.Indented);
        File.WriteAllText(customersPath, json);
    }

    public static List<Product> ReadProductsFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        Dictionary<string, List<Product>> products = JsonConvert.DeserializeObject<Dictionary<string, List<Product>>>(json);
        return products["Products"];
    }
    public static List<Order> ReadOrdersFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        Dictionary<string, List<Order>> orders = JsonConvert.DeserializeObject<Dictionary<string, List<Order>>>(json);
        return orders["Orders"];
    }
    public static List<Customer> ReadCustomersFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        Dictionary<string, List<Customer>> customers = JsonConvert.DeserializeObject<Dictionary<string, List<Customer>>>(json);
        return customers["Customers"];
    }
    public static void LoadDataFromFile(string productsPath, string customersPath, string ordersPath)
    {
        // Read products
        foreach (var line in ReadProductsFromJson(productsPath))
        {
            statistics.SalesManager.AddProduct(line);
        }

        // Read customers
        foreach (var line in ReadCustomersFromJson(customersPath))
        {
            statistics.SalesManager.AddCustomer(line);
        }

        // Read orders
        foreach (var line in ReadOrdersFromJson(ordersPath))
        {
            statistics.SalesManager.CreateOrder(line);
        }
    }

    public string ConvertProductsToCSV(List<Product> products)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Id|Name|Category|Price|Stock|Image");

        foreach (var product in products)
        {
            sb.AppendLine($"{product.Id},{product.Name},{product.Category},{product.Price},{product.Stock},{product.Image}");
        }

        return sb.ToString();
    }
}
