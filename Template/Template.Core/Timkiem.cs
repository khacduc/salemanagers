using System;
using System.Collections.Generic;
using System.Linq;
using Template.Core.Models;

// Product, Order, OrderItem, Customer, SalesManager, and Statistics classes
// ...

public class Search
{
    //Tim san pham bang ten
    public static List<Product> SearchProductsByName(List<Product> products, string searchTerm)
    {
        return products.Where(p => p.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    //Tim san pham bang loai
    public static List<Product> SearchProductsByCategory(List<Product> products, string searchTerm)
    {
        return products.Where(p => p.Category.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    //Tim san pham bang ID
    public static List<Product> SearchProductsID(List<Product> products, string searchTerm)
    {
        return products.Where(p => p.Id.ToString() == searchTerm).ToList();
    }

    //Tim khach hang bang id
    public static List<Customer> SearchCustomersByID(List<Customer> customers, string searchTerm)
    {
        return customers.Where(c => c.CustomerId.ToString() == searchTerm).ToList();
    }

    //Tim khach hang bang ten
    public static List<Customer> SearchCustomersByName(List<Customer> customers, string searchTerm)
    {
        return customers.Where(c => c.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    //Tim khach hang bang email
    public static List<Customer> SearchCustomersByEmail(List<Customer> customers, string searchTerm)
    {
        return customers.Where(c => c.Email.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    //Tim don hang bang ID
    public static List<Order> SearchOrdersByID(List<Order> orders, string searchTerm)
    {
        return orders.Where(o => o.OrderId.ToString() == searchTerm).ToList();
    }
    //Tim don hang bang ID khach hang
    public static List<Order> SearchOrdersByCustomerID(List<Order> orders, string searchTerm)
    {
        return orders.Where(o => o.Customer != null && o.Customer.CustomerId.ToString() == searchTerm).ToList();
    }

    //Tim don hang bang ten
    public static List<Order> SearchOrdersByName(List<Order> orders, string searchTerm)
    {
        return orders.Where(o => o.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    //Tim don hang bang ten khach hang
    public static List<Order> SearchOrdersByCustomerName(List<Order> orders, string searchTerm)
    {
        return orders.Where(o => o.Customer.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    //Tim don hang bang san pham
    public static List<Order> SearchOrdersByProductName(List<Order> orders, string searchTerm)
    {
        return orders.Where(o => o.OrderItems.Any(oi => oi.Product.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
    }

    //Tim don hang theo khoang thoi gian
    public static List<Order> FilterOrdersByDateRange(List<Order> orders, DateTime startDate, DateTime endDate)
    {
        return orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).ToList();
    }

    //Tim san pham theo khoang tien
    public static List<Product> FilterProductsByPriceRange(List<Product> products, float minPrice, float maxPrice)
    {
        return products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
    }
}
