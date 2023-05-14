using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using SalesManagerCore;
using Template.Core.Contracts.Services;

namespace Template.Core.Models;

public class Product
{
    public int Id
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public string Category
    {
        get; set;
    }
    public float Price
    {
        get; set;
    }
    public int Stock
    {
        get; set;
    }
    //De o dang base 64
    public string Image
    {
        get; set;
    }

    public string tostring => $"ID: {Id} | Name: {Name} | Category: {Category} | Price: {Price} | Stock: {Stock}";
}

public class Order
{
    public int OrderId
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public Customer Customer
    {
        get; set;
    }

    public string tostring
    {
        get
        {
            if (Customer == null)
            {
                return "";
            }

            return $"ID: {OrderId} | Name: {Name} | Date: {OrderDate.ToShortDateString()} | Item: {OrderItemsToString}";
        }
    } 
    public string CustumerToString
    {
        get
        {
            if(Customer == null)
            {
                return "";
            }

            return $"ID: {Customer.CustomerId} Name: {Customer.Name}";
        }
    } 

    public DateTime OrderDate
    {
        get; set;
    }
    public List<OrderItem> OrderItems = new List<OrderItem>();
    public string OrderItemsToString
    {
        get
        {
            if (OrderItems == null)
                return "";

            return string.Join(",", OrderItems.Select(i => $"Name: {i.Product.Name} | Count: {i.Quantity}"));
        }
    } 
    public float TotalAmount
    {
        get
        {
            float totalAmount = 0;

            if (OrderItems != null)
            {
                foreach (var orderItem in OrderItems)
                {
                    totalAmount += orderItem.Product.Price * orderItem.Quantity;
                }
            }

            return totalAmount;
        }
    }
}

public class OrderItem
{
    public Product Product
    {
        get; set;
    }
    public int Quantity
    {
        get; set;
    }
}

public class Customer
{
    public int CustomerId
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public string Email
    {
        get; set;
    }
    public string PhoneNumber
    {
        get; set;
    }
    //De o dang base 64
    public string Image
    {
        get; set;
    }

    public string getorder
    {
        get
        {
            var all = Search.SearchOrdersByCustomerID(Data.statistics.SalesManager.Orders.Values.ToList(), CustomerId.ToString());

            if (all.Count > 0)
            {

                StringBuilder builder = new StringBuilder();

                foreach (var item in all.Select(i => i.tostring))
                {
                    builder.Append(item);
                    builder.Append(", ");
                }

                // Remove the trailing comma and space.
                if (builder.Length > 0)
                {
                    builder.Remove(builder.Length - 2, 2);
                }


                return builder.ToString();
            }

            return "";
        }
    }

    public string tostring => $"CustomerId: {CustomerId} | Name: {Name} | Email: {Email} | PhoneNumber: {PhoneNumber}";
}

public class SalesManager
{
    public Dictionary<int, Product> Products
    {
        get; set;
    }
    public Dictionary<int, Customer> Customers
    {
        get; set;
    }
    public Dictionary<int, Order> Orders
    {
        get; set;
    }

    public SalesManager()
    {
        Products = new Dictionary<int, Product>();
        Customers = new Dictionary<int, Customer>();
        Orders = new Dictionary<int, Order>();

        AddTestData();
    }

    public void AddTestData()
    {
    //    // Add products to the list
    //    AddProduct(new Product
    //    {
    //        Id = 1,
    //        Name = "iPhone 13",
    //        Category = "Phone",
    //        Price = 699,
    //        Stock = 100,
    //        Image = ""
    //    });

    //    AddProduct(new Product
    //    {
    //        Id = 2,
    //        Name = "iPad Pro",
    //        Category = "Tablet",
    //        Price = 799,
    //        Stock = 50,
    //        Image = ""
    //    });

    //    AddProduct(new Product
    //    {
    //        Id = 3,
    //        Name = "MacBook Pro",
    //        Category = "Laptop",
    //        Price = 1299,
    //        Stock = 20,
    //        Image = ""
    //    });

    //    // Add customers to the list
    //    AddCustomer(new Customer
    //    {
    //        CustomerId = 1,
    //        Name = "John Doe",
    //        Email = "johndoe@gmail.com",
    //        PhoneNumber = "123-456-7890",
    //        Image = ""
    //    });

    //    AddCustomer(new Customer
    //    {
    //        CustomerId = 2,
    //        Name = "Jane Doe",
    //        Email = "janedoe@gmail.com",
    //        PhoneNumber = "987-654-3210",
    //        Image = ""
    //    });

    //    // Add orders to the list
    //    CreateOrder(new Order
    //    {
    //        OrderId = 1,
    //        Name = "Order 1",
    //        Customer = Customers[1],
    //        OrderDate = DateTime.Now,
    //        OrderItems = new List<OrderItem>
    //{
    //    new OrderItem
    //    {
    //        Product = Products[1],
    //        Quantity = 1
    //    },
    //    new OrderItem
    //    {
    //        Product = Products[1],
    //        Quantity = 2
    //    }
    //},
    //    });

    //    CreateOrder(new Order
    //    {
    //        OrderId = 2,
    //        Name = "Order 2",
    //        Customer = Customers[1],
    //        OrderDate = DateTime.Now,
    //        OrderItems = new List<OrderItem>
    //{
    //    new OrderItem
    //    {
    //        Product = Products[2],
    //        Quantity = 1
    //    }
    //},
    //    });
    }

    // Them san pham
    public void AddProduct(Product product)
    {
        if (Products.ContainsKey(product.Id))
            return;

        Products.Add(product.Id, product);
    }

    //Xoa san pham
    public void RemoveProduct(int productId)
    {
        Products.Remove(productId);
    }

    //Cap nhat san pham
    public void UpdateProduct(Product updatedProduct)
    {
        if(!Products.ContainsKey(updatedProduct.Id))
            return;

        Products[updatedProduct.Id] = updatedProduct;
    }

    // Them khach hang
    public void AddCustomer(Customer customer)
    {
        if (Customers.ContainsKey(customer.CustomerId))
            return;

        Customers.Add(customer.CustomerId, customer);
    }

    //Xoa khach hang
    public void RemoveCustomer(int customerId)
    {
        Customers.Remove(customerId);
    }

    //Cap nhat khach hang
    public void UpdateCustomer(Customer updatedCustomer)
    {
        if (!Customers.ContainsKey(updatedCustomer.CustomerId))
            return;

        Customers[updatedCustomer.CustomerId] = updatedCustomer;
    }

    // Tao don hang
    public void CreateOrder(Order order)
    {
        if (Orders.ContainsKey(order.OrderId))
            return;

        Orders.Add(order.OrderId, order);
    }

    //Huy don hang
    public void CancelOrder(int orderId)
    {
        Orders.Remove(orderId);
    }

    //Cap nhat don hang
    public void UpdateOrder(Order updatedOrder)
    {
        if (!Orders.ContainsKey(updatedOrder.OrderId))
            return;

        Orders[updatedOrder.OrderId] = updatedOrder;
    }
}

public class Statistics : INotifyPropertyChanged
{
    public float TotalRevenue => CalculateTotalRevenue();
    public float AverageOrderValue => CalculateAverageOrderValue();
    public float RevenueForProduct = 0;
    public string TopSellingProducts
    {
        get
        {
            var topsellings = GetTopSellingProducts(1);
            if (topsellings.Count() == 0)
                return "";

            var topselling = topsellings.FirstOrDefault();
            RevenueForProduct = CalculateRevenueForProduct(topselling);
            return topselling.tostring;
        }
    }
    public string RevenuePerCategory
    {
        get
        {
            var all = CalculateRevenuePerCategory();
            var stringbuild = "";

            foreach (var item in all)
            {
                stringbuild += $"{item.Key} : {item.Value} {Environment.NewLine}";
            }

            return stringbuild;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public SalesManager SalesManager
    {
        get; set;
    }

    public Statistics(SalesManager salesManager)
    {
        SalesManager = salesManager;
    }

    //Tinh tong doanh thu tao ra tu cac don hang
    public float CalculateTotalRevenue()
    {
        float totalRevenue = 0;

        foreach (var order in SalesManager.Orders)
        {
            totalRevenue += order.Value.TotalAmount;
        }

        return totalRevenue;
    }

    //Tinh gia tri don hang trung binh
    public float CalculateAverageOrderValue()
    {
        if (SalesManager.Orders.Count == 0)
        {
            return 0;
        }

        var totalRevenue = CalculateTotalRevenue();
        return totalRevenue / SalesManager.Orders.Count;
    }

    //Tong so luong san pham
    public Dictionary<Product, int> CalculateProductSales()
    {
        Dictionary<Product, int> productSales = new Dictionary<Product, int>();

        foreach (var order in SalesManager.Orders)
        {
            foreach (var orderItem in order.Value.OrderItems)   
            {
                if (productSales.ContainsKey(orderItem.Product))
                {
                    productSales[orderItem.Product] += orderItem.Quantity;
                }
                else
                {
                    productSales[orderItem.Product] = orderItem.Quantity;
                }
            }
        }

        return productSales;
    }

    //Danh sach san pham ban chay
    public List<Product> GetTopSellingProducts(int numberOfTopProducts)
    {
        Dictionary<Product, int> productSales = CalculateProductSales();
        List<Product> topSellingProducts = new List<Product>();

        for (var i = 0; i < numberOfTopProducts; i++)
        {
            Product topProduct = null;
            var maxSales = 0;

            foreach (var product in productSales.Keys)
            {
                if (!topSellingProducts.Contains(product) && productSales[product] > maxSales)
                {
                    topProduct = product;
                    maxSales = productSales[product];
                }
            }

            if (topProduct != null)
            {
                topSellingProducts.Add(topProduct);
            }
        }

        return topSellingProducts;
    }

    //Tong doanh thu tu 1 san pham
    public float CalculateRevenueForProduct(Product product)
    {
        float productRevenue = 0;

        foreach (var order in SalesManager.Orders)
        {
            foreach (var orderItem in order.Value.OrderItems)
            {
                if (orderItem.Product == product)
                {
                    productRevenue += orderItem.Product.Price * orderItem.Quantity;
                }
            }
        }

        return productRevenue;
    }

    //Tong doanh thu cho moi muc san pham
    public Dictionary<string, float> CalculateRevenuePerCategory()
    {
        Dictionary<string, float> categoryRevenue = new Dictionary<string, float>();

        foreach (var order in SalesManager.Orders)
        {
            foreach (var orderItem in order.Value.OrderItems)
            {
                var category = orderItem.Product.Category;

                if (categoryRevenue.ContainsKey(category))
                {
                    categoryRevenue[category] += orderItem.Product.Price * orderItem.Quantity;
                }
                else
                {
                    categoryRevenue[category] = orderItem.Product.Price * orderItem.Quantity;
                }
            }
        }

        return categoryRevenue;
    }
}
