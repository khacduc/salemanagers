using System.Xml.Linq;
using SalesManagerCore;
using Template.Core.Contracts.Services;
using Template.Core.Models;

namespace Template.Core.Services;

// This class holds sample data used by some generated pages to show how they can be used.
// TODO: The following classes have been created to display sample data. Delete these files once your app is using real data.
// 1. Contracts/Services/ISampleDataService.cs
// 2. Services/SampleDataService.cs
// 3. Models/SampleCompany.cs
// 4. Models/SampleOrder.cs
// 5. Models/SampleOrderDetail.cs
public class OrderData : IOrder
{
    private List<Order> _all = null;
    public OrderData()
    {
    }

    private static IEnumerable<Order> All()
    {
        // The following is order summary data
        return GetAllData();
    }
    private static IEnumerable<Order> GetAllData()
    {
        return Data.statistics.SalesManager.Orders.Values;
    }
    public async Task<IEnumerable<Order>> GetContentGridDataAsync()
    {
        _all = Data.statistics.SalesManager.Orders.Values.ToList();

        await Task.CompletedTask;
        return _all;
    }

    public async Task<IEnumerable<Order>> GetGridDataAsync()
    {
        _all ??= new List<Order>(All());

        await Task.CompletedTask;
        return _all;
    }
    public ICollection<Order> Orders
    {
        get; set;
    }
}