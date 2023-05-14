using System;
using System.Collections.Generic;
using Template.Core.Models;

// Product, Order, OrderItem, Customer, SalesManager, and Statistics classes
// ...

public class SortItem
{
    //Sap xep khach hang theo id
    public static void SortCustomersByID(List<Customer> customers, bool ascending = true)
    {
        customers.Sort((c1, c2) => ascending ? c1.CustomerId.CompareTo(c2.CustomerId) : c2.CustomerId.CompareTo(c1.CustomerId));
    }

    //Sap xep don hang theo id
    public static void SortOrdersByID(List<Order> customers, bool ascending = true)
    {
        customers.Sort((c1, c2) => ascending ? c1.OrderId.CompareTo(c2.OrderId) : c2.OrderId.CompareTo(c1.OrderId));
    }

    //Sap xep san pham theo id
    public static void SortProductsByID(List<Product> customers, bool ascending = true)
    {
        customers.Sort((c1, c2) => ascending ? c1.Id.CompareTo(c2.Id) : c2.Id.CompareTo(c1.Id));
    }

    //Sap xep san pham theo ten
    public static void SortProductsByName(List<Product> products, bool ascending = true)
    {
        products.Sort((p1, p2) => ascending ? string.Compare(p1.Name, p2.Name, StringComparison.OrdinalIgnoreCase) : string.Compare(p2.Name, p1.Name, StringComparison.OrdinalIgnoreCase));
    }

    //Sap xep san pham theo tien
    public static void SortProductsByPrice(List<Product> products, bool ascending = true)
    {
        products.Sort((p1, p2) => ascending ? p1.Price.CompareTo(p2.Price) : p2.Price.CompareTo(p1.Price));
    }

    //Sap xep khach hang theo ten
    public static void SortCustomersByName(List<Customer> customers, bool ascending = true)
    {
        customers.Sort((c1, c2) => ascending ? string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase) : string.Compare(c2.Name, c1.Name, StringComparison.OrdinalIgnoreCase));
    }

    //Sap xep khach hang theo email
    public static void SortCustomersByEmail(List<Customer> customers, bool ascending = true)
    {
        customers.Sort((c1, c2) => ascending ? string.Compare(c1.Email, c2.Email, StringComparison.OrdinalIgnoreCase) : string.Compare(c2.Email, c1.Email, StringComparison.OrdinalIgnoreCase));
    }

    //Sap xep don hang theo ngay
    public static void SortOrdersByDate(List<Order> orders, bool ascending = true)
    {
        orders.Sort((o1, o2) => ascending ? o1.OrderDate.CompareTo(o2.OrderDate) : o2.OrderDate.CompareTo(o1.OrderDate));
    }


    public static void SortOrdersByTotalAmount(List<Order> orders, bool ascending = true)
    {
        orders.Sort((o1, o2) => ascending ? o1.TotalAmount.CompareTo(o2.TotalAmount) : o2.TotalAmount.CompareTo(o1.TotalAmount));
    }
}
